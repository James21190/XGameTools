using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// Base class used to hook into another process.
    /// </summary>
    public class ApplicationHook
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
            memoryObject.hProcess = hProcess;
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
    }
}
