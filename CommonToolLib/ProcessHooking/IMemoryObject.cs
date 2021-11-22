using CommonToolLib.Generics;
using System;

namespace CommonToolLib.ProcessHooking
{
    public interface IMemoryObject : IBinaryObject
    {
        IntPtr pThis { get; set; }
        IntPtr hProcess { get; set; }

        [Obsolete("This method is no longer supported. Please use pThis and hProcess instead.")]
        void SetLocation(IntPtr hProcess, IntPtr address);

        /// <summary>
        /// Reloads values from memory with the data provided by SetLocation.
        /// </summary>
        void ReloadFromMemory();
    }
}
