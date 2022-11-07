using CommonToolLib.Generics;
using System;

namespace CommonToolLib.ProcessHooking
{
    public interface IMemoryObject : IBinaryObject
    {
        IntPtr pThis { get; set; }
        IntPtr hProcess { get; set; }

        /// <summary>
        /// Reloads values from memory with the data provided by SetLocation.
        /// </summary>
        void ReloadFromMemory();
    }
}
