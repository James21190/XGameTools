using CommonToolLib.Generics;
using System;
using System.Runtime.CompilerServices;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// Basic IMemoryObject with additional functionality.
    /// MemoryObjects copy memory from another processes memory.
    /// </summary>
    public abstract class MemoryObject : IMemoryObject
    {

        #region IMemoryObject


        /// <summary>
        /// The size of the object in bytes.
        /// </summary>
        /// <returns></returns>
        public abstract int ByteSize { get; }

        
        public virtual IntPtr pThis { get; set; }
        public virtual IMemoryBlockManager ParentMemoryBlock { get; set; }

        /// <summary>
        /// Sets the values of the fields of this object with the values stored in a binary array.
        /// </summary>
        /// <param name="Memory"></param>
        public virtual SetDataResult SetData(byte[] Memory)
        {
            return SetDataFromMemoryObjectConverter(new MemoryObjectConverter(Memory, ParentMemoryBlock, pThis));
        }
        /// <summary>
        /// Converts the values within the object into bytes.
        /// </summary>
        /// <returns></returns>
        public abstract byte[] GetBytes();
        #endregion

        /// <summary>
        /// Abstracted version of SetData using an MemoryObjectConverter. Called from SetData unless overrided.
        /// </summary>
        /// <param name="objectByteList"></param>
        protected abstract SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList);

        /// <summary>
        /// Reload values from memory.
        /// </summary>
        public void ReloadFromMemory()
        {
            SetData(ParentMemoryBlock.ReadBytes(pThis,ByteSize));
        }

        /// <summary>
        /// Writes all values to memory.
        /// </summary>
        public void WriteToMemory()
        {
            ParentMemoryBlock.WriteBinaryObject(pThis, this);
        }

        /// <summary>
        /// Writes all values that are considered safe to edit to memory.
        /// Values such as pointers are excluded.
        /// </summary>
        public virtual void WriteSafeToMemory()
        {
            ParentMemoryBlock.WriteBinaryObject(pThis, this);
        }

    }
}
