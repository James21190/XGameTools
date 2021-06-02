using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CommonToolLib.Memory
{
    /// <summary>
    /// Base class used to hook into another process.
    /// </summary>
    public abstract class ApplicationHook
    {
        /// <summary>
        /// Handle to the attached process.
        /// </summary>
        public IntPtr hProcess { private set; get; }

        /// <summary>
        /// Hooks into a process and stores the handle in the hProcess field.
        /// </summary>
        /// <param name="process"></param>
        public void HookIntoProcess(Process process)
        {
            HookIntoProcess((uint)process.Id);
        }

        public void HookIntoProcess(uint processID)
        {
            hProcess = MemoryControl.OpenProcess((uint)MemoryControl.ProcessAccessFlags.All, 0, processID);
        }

        public void HookIntoProcess(string processName)
        {
            Process process = Process.GetProcessesByName(processName).FirstOrDefault();
            HookIntoProcess(process);
        }

        public IntPtr InjectDll(string absolutePath)
        {
            IntPtr pPath = MemoryControl.AllocateMemory(hProcess, absolutePath.Length + 1);
            IntPtr plibaddr = MemoryControl.GetProcAddress(MemoryControl.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            MemoryControl.Write(hProcess, pPath, Encoding.Default.GetBytes(absolutePath));
            IntPtr hInjection = MemoryControl.CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, plibaddr, pPath, 0, IntPtr.Zero);
            return hInjection;
        }

        /// <summary>
        /// Allocates new memory for the object in the hooked process.
        /// The contents of the object are not written.
        /// </summary>
        /// <param name="obj"></param>
        public void AllocNewMemory(IMemoryObject obj)
        {
            obj.hProcess = hProcess;
            obj.pThis = MemoryControl.AllocateMemory(hProcess, obj.ByteSize);
        }

        /// <summary>
        /// Frees an object's memory in the hooked process.
        /// </summary>
        /// <param name="obj"></param>
        public void FreeMemory(IMemoryObject obj)
        {
            MemoryControl.FreeMemory(hProcess, obj.pThis, obj.ByteSize);
            obj.hProcess = obj.pThis = IntPtr.Zero;
        }

        /// <summary>
        /// Unhooks from the process.
        /// </summary>
        public void Unhook()
        {
            MemoryControl.CloseHandle(hProcess);
        }
    }
}
