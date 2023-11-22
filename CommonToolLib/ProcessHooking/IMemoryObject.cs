using CommonToolLib.Generics;
using System;

namespace CommonToolLib.ProcessHooking
{
    public interface IMemoryObject : IBinaryObject
    {
        /// <summary>
        /// Pointer to where this object is stored in ParentMemoryBlock.
        /// </summary>
        IntPtr pThis { get; set; }
        /// <summary>
        /// The memory block that holds this object.
        /// </summary>
        IMemoryBlockManager ParentMemoryBlock { get; set; }

        /// <summary>
        /// Reloads values from memory with the data provided by SetLocation.
        /// </summary>
        void ReloadFromMemory();
    }
}
