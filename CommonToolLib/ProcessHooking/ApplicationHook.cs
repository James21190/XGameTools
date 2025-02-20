using CommonToolLib.Generics.BinaryObjects;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static CommonToolLib.ProcessHooking.ApplicationHook;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// Base class used to hook into another process.
    /// </summary>
    public class ApplicationHook : IMemoryBlockManager
    {
        #region Process Hooking
        /// <summary>
        /// Handle to the attached process.
        /// </summary>
        public IntPtr hProcess { private set; get; }

        public Process Process { get; private set; }

        public bool IsReadOnly
        {
            get;
        } = false;

        public bool ProcessRunning
        {
            get
            {
                return !Process.HasExited;
            }
        }

        /// <summary>
        /// Hooks into a process and stores the handle in the hProcess field.
        /// </summary>
        /// <param name="process"></param>
        public void HookIntoProcess(Process process)
        {
            Process = process;
            HookIntoProcess((uint)Process.Id);
        }

        public void HookIntoProcess(uint processID)
        {
            IntPtr openProcessResult = MemoryControl.OpenProcess((uint)MemoryControl.ProcessAccessFlags.All, 0, processID);
            
            if(openProcessResult == IntPtr.Zero)
            {
                var lastError = MemoryControl.GetLastError();
                throw new Exception("OpenProcess failed! Error code 0x" + lastError.ToString("X"));
            }
            else
            {
                hProcess = openProcessResult;
            }
        }

        public void HookIntoProcess(string processName)
        {
            Process process = Process.GetProcessesByName(processName).FirstOrDefault();
            HookIntoProcess(process);
        }
        /// <summary>
        /// Unhooks from the process.
        /// </summary>
        public void Unhook()
        {
            MemoryControl.CloseHandle(hProcess);
        }
        #endregion

        #region Process data
        /// <summary>
        /// Allocates a number of bytes in the process data.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>A pointer to the allocated data.</returns>
        public IntPtr AllocNewMemory(int bytes)
        {
            return MemoryControl.AllocateMemory(hProcess, bytes);
        }

        /// <summary>
        /// Allocates data for an IMemoryObject.
        /// The object's hProcess and pThis are updated.
        /// The contents of the object is not written to the process data.
        /// </summary>
        /// <param name="memoryObject"></param>
        public void AllocNewMemory(ref IMemoryObject memoryObject)
        {
            memoryObject.pThis = AllocNewMemory(memoryObject.ByteSize);
        }

        /// <summary>
        /// Frees a number of bytes as the given address in the process data.
        /// </summary>
        public void FreeMemory(IntPtr pdata, int bytes)
        {
            MemoryControl.FreeMemory(hProcess, pdata, bytes);
        }

        /// <summary>
        /// Frees the IMemoryObject in the process data.
        /// </summary>
        /// <param name="memoryObject"></param>
        public void FreeMemory(ref IMemoryObject memoryObject)
        {
            FreeMemory(memoryObject.pThis, memoryObject.ByteSize);
            memoryObject.pThis = IntPtr.Zero;
        }
        public byte[] ReadBytes(IntPtr address, int lenght)
        {
            return MemoryControl.Read(hProcess, address, lenght);
        }

        public T ReadBinaryObject<T>(IntPtr address, int maxObjectSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE) where T : IBinaryObject, new()
        {
            var result = new T();
            var bytes = ReadBytes(address, maxObjectSize);
            int bytesConsumed;
            result.SetData(bytes, out bytesConsumed);
            return result;
        }

        public T ReadMemoryObject<T>(IntPtr address, int maxObjectSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE) where T : IMemoryObject, new()
        {
            var result = ReadBinaryObject<T>(address, maxObjectSize);
            result.ParentMemoryBlock = this;
            return result;
        }

        public void WriteBytes(IntPtr address, byte[] bytes)
        {
            if (IsReadOnly) throw new Exception("Memory block is read only.");
            MemoryControl.Write(hProcess, address, bytes);
        }

        public void WriteBinaryObject(IntPtr address, IBinaryObject binaryObject)
        {
            if (IsReadOnly) throw new Exception("Memory block is read only.");
            MemoryControl.Write(hProcess, address, binaryObject.GetBytes());
        }
        #endregion

        public IntPtr InjectDll(string absolutePath)
        {
            IntPtr pPath = MemoryControl.AllocateMemory(hProcess, absolutePath.Length + 1);
            IntPtr plibaddr = MemoryControl.GetProcAddress(MemoryControl.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            MemoryControl.Write(hProcess, pPath, Encoding.Default.GetBytes(absolutePath));
            IntPtr hInjection = MemoryControl.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, plibaddr, pPath, 0, IntPtr.Zero);
            return hInjection;
        }


        static object focusRequired = new object();

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        public void PressKey(Keys key, bool up)
        {
            lock (focusRequired)
            {
                var active = GetForegroundWindow();
                bool needsSwitch = active != Process.MainWindowHandle;
                if (needsSwitch)
                    FocusWindow();
                const int KEYEVENTF_EXTENDEDKEY = 0x1;
                const int KEYEVENTF_KEYUP = 0x2;
                if (up)
                {
                    keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
                }
                else
                {
                    keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                }
            }
        }

        public void HoldKey(Keys key, int duration)
        {
            lock (focusRequired)
            {
                PressKey(key, false);
                Thread.Sleep(duration);
                PressKey(key, true);
                Thread.Sleep(200);
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, out rec lpRect);

        struct rec
        {
            public int Left, Top, Right, Bottom;
            public int X => Left;
            public int Y => Top;
            public int Width => Right - Left;
            public int Height => Bottom - Top;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public void MoveWindowPosition(int x, int y)
        {
            rec rect = new rec();
            GetWindowRect(Process.MainWindowHandle, out rect);

            MoveWindow(Process.MainWindowHandle, x, y, rect.Width, rect.Height, true);
        }

        public void FocusWindow()
        {
            lock (focusRequired)
            {
                SetForegroundWindow(Process.MainWindowHandle);
                Thread.Sleep(120);
            }
        }

        [DllImport("User32.dll")]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("User32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hwnd);

        public Bitmap Screenshot()
        {
#if true
            lock (focusRequired)
            {
                var active = GetForegroundWindow();
                rec r;
                GetWindowRect(Process.MainWindowHandle, out r);
                Bitmap bmp = new Bitmap(r.Width, r.Height);
                var graphics = Graphics.FromImage(bmp);
                FocusWindow();
                graphics.CopyFromScreen(new Point(r.X, r.Y), new Point(0, 0), new Size(r.Width, r.Height));
                SetForegroundWindow(active);
                return bmp;
            }
#else
            var windHDC = GetWindowDC(Process.MainWindowHandle);
            rec r;
            GetWindowRect(Process.MainWindowHandle, out r);
            Bitmap bmp = new Bitmap(r.Width, r.Height);
            using(var graphics  = Graphics.FromImage(bmp))
            {
                var hdc = graphics.GetHdc();
                PrintWindow(Process.MainWindowHandle, hdc, 0);
                graphics.ReleaseHdc(hdc);
            }
            bmp.Save("test.bmp");
            return bmp;
#endif
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

    }
}
