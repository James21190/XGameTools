using CommonToolLib.Generics;
using CommonToolLib.Generics.BinaryObjects;
using System;
using System.Runtime.CompilerServices;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// Basic IBinaryObject with additional functionality.
    /// dataObjects copy data from another processes data.
    /// </summary>
    public abstract class MemoryObject : IMemoryObject
    {

        #region IBinaryObject
       
        public virtual IntPtr pThis { get; set; }
        public virtual IMemoryBlockManager ParentMemoryBlock { get; set; }

        public abstract int ByteSize { get; }

        /// <summary>
        /// Sets the values of the fields of this object with the values stored in a binary array.
        /// </summary>
        /// <param name="data"></param>
        public virtual void SetData(byte[] data, out int bytesConsumed)
        {
            var moc = new MemoryObjectConverter(data, ParentMemoryBlock, pThis);
            SetDataFromMemoryObjectConverter(moc);
            bytesConsumed = moc.DataPointer;
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
        /// <param name="memoryObjectConverter"></param>
        protected abstract void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter);

        /// <summary>
        /// Reload values from data.
        /// </summary>
        public void ReloadFromMemory(int maxObjectSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE)
        {
            int bytesConsumed;
            SetData(ParentMemoryBlock.ReadBytes(pThis, maxObjectSize), out bytesConsumed);
        }

        /// <summary>
        /// Writes all values to data.
        /// </summary>
        public void WriteToMemory()
        {
            ParentMemoryBlock.WriteBinaryObject(pThis, this);
        }

        /// <summary>
        /// Writes all values that are considered safe to edit to data.
        /// Values such as pointers are excluded.
        /// </summary>
        public virtual void WriteSafeToMemory()
        {
            ParentMemoryBlock.WriteBinaryObject(pThis, this);
        }

    }
}
