using CommonToolLib.Generics;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// Base class used to hook into another process.
    /// </summary>
    public class ApplicationHook : IMemoryBlockManager
    {
        /// <summary>
        /// Handle to the attached process.
        /// </summary>
        public IntPtr hProcess { private set; get; }

        private Process _Process;

        public bool IsReadOnly
        {
            get;
        } = false;

        public bool ProcessRunning
        {
            get
            {
                return !_Process.HasExited;
            }
        }

        /// <summary>
        /// Hooks into a process and stores the handle in the hProcess field.
        /// </summary>
        /// <param name="process"></param>
        public void HookIntoProcess(Process process)
        {
            _Process = process;
            HookIntoProcess((uint)_Process.Id);
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
        /// Allocates a number of bytes in the process memory.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>A pointer to the allocated memory.</returns>
        public IntPtr AllocNewMemory(int bytes)
        {
            return MemoryControl.AllocateMemory(hProcess, bytes);
        }

        /// <summary>
        /// Allocates memory for an IMemoryObject.
        /// The object's hProcess and pThis are updated.
        /// The contents of the object is not written to the process memory.
        /// </summary>
        /// <param name="memoryObject"></param>
        public void AllocNewMemory(ref IMemoryObject memoryObject)
        {
            memoryObject.pThis = AllocNewMemory(memoryObject.ByteSize);
        }

        /// <summary>
        /// Frees a number of bytes as the given address in the process memory.
        /// </summary>
        public void FreeMemory(IntPtr pMemory, int bytes)
        {
            MemoryControl.FreeMemory(hProcess, pMemory, bytes);
        }

        /// <summary>
        /// Frees the IMemoryObject in the process memory.
        /// </summary>
        /// <param name="memoryObject"></param>
        public void FreeMemory(ref IMemoryObject memoryObject)
        {
            FreeMemory(memoryObject.pThis, memoryObject.ByteSize);
            memoryObject.pThis = IntPtr.Zero;
        }

        /// <summary>
        /// Unhooks from the process.
        /// </summary>
        public void Unhook()
        {
            MemoryControl.CloseHandle(hProcess);
        }

        public byte[] ReadBytes(IntPtr address, int lenght)
        {
            return MemoryControl.Read(hProcess, address, lenght);
        }

        public T ReadBinaryObject<T>(IntPtr address) where T : IBinaryObject, new()
        {
            var result = new T();
            result.SetData(ReadBytes(address, result.ByteSize));
            return result;
        }

        public T ReadMemoryObject<T>(IntPtr address) where T : IMemoryObject, new()
        {
            var result = new T();
            result.ParentMemoryBlock = this;
            result.SetData(ReadBytes(address, result.ByteSize));
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
    }
}
