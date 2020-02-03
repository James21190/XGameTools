using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Common.Memory
{
    public abstract class ApplicationHook
    {
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

        }

        /// <summary>
        /// Unhooks from the process.
        /// </summary>
        public void Unhook()
        {

        }
    }
}
