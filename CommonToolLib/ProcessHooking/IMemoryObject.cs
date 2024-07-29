using CommonToolLib.Generics.BinaryObjects;
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
        /// Reloads values from data with the data provided by SetLocation.
        /// </summary>
        void ReloadFromMemory(int maxObjectSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE);

        /// <summary>
        /// The size of the object. Used when managing objects in another process memory.
        /// </summary>
        int ByteSize { get; }
    }
}
