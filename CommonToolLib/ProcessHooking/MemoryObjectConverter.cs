using CommonToolLib.Generics.BinaryObjects;
using System;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// A byte array that can combine IMemoryObject and seperate them.
    /// </summary>
    public class MemoryObjectConverter : BinaryObjectConverter, IMemoryObject
    {

        public MemoryObjectConverter() : base()
        {
            pThis = IntPtr.Zero;
            ParentMemoryBlock = null;
        }
        public MemoryObjectConverter(byte[] data) : base(data)
        {
            pThis = IntPtr.Zero;
            ParentMemoryBlock = null;
        }
        public MemoryObjectConverter(byte[] data, IMemoryBlockManager dataBlock, IntPtr pThis) : base(data)
        {
            this.pThis = pThis;
            this.ParentMemoryBlock = dataBlock;
        }

        #region IMemoryObject
        public IntPtr pThis { get; set; }
        public IMemoryBlockManager ParentMemoryBlock { get; set; }
        public void ReloadFromMemory(int maxObjectSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE)
        {
            throw new NotImplementedException();
        }
        public int ByteSize => Size;
        #endregion

        #region Pops
        public T PopIMemoryObject<T>(int maxSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE) where T : IMemoryObject, new()
        {
            T memoryObject = PopIBinaryObject<T>(maxSize);

            memoryObject.ParentMemoryBlock = ParentMemoryBlock;
            memoryObject.pThis = pThis + DataPointer;

            return memoryObject;
        }

        public T[] PopIMemoryObjects<T>(int Count, int maxSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE) where T : IMemoryObject, new()
        {
            T[] dataObjects = PopIBinaryObjects<T>(Count, maxSize);

            for (int i = 0; i < Count; i++)
            {
                dataObjects[i].ParentMemoryBlock = ParentMemoryBlock;
                dataObjects[i].pThis = pThis + DataPointer;
            }

            return dataObjects;
        }
        #endregion

    }
}
