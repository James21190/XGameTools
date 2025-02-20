using System;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// A pointer that points to an IMemoryObject in a process's data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class MemoryObjectPointer<T> : MemoryObject where T : IMemoryObject, new()
    {

        #region Constructors
        public MemoryObjectPointer(IMemoryBlockManager parentdataBlock, IntPtr address)
        {
            ParentMemoryBlock = parentdataBlock;
            this.PointedAddress = address;
        }

        public MemoryObjectPointer(IMemoryBlockManager parentdataBlock)
        {
            ParentMemoryBlock = parentdataBlock;
            PointedAddress = IntPtr.Zero;
        }

        public MemoryObjectPointer()
        {
            ParentMemoryBlock = null;
            PointedAddress = IntPtr.Zero;
        }

        #endregion
        /// <summary>
        /// The address that is pointed to.
        /// </summary>
        public IntPtr PointedAddress;

        /// <summary>
        /// The object at the address.
        /// Returns a new object from the process data.
        /// Sets to the process data.
        /// </summary>
        public T obj
        {
            get
            {
                if (!IsValid)
                {
                    throw new NullReferenceException();
                }
                T obj = new T();
                obj.ParentMemoryBlock = ParentMemoryBlock;
                obj.pThis = PointedAddress;
                obj.ReloadFromMemory(obj.ByteSize);
                return obj;
            }
            set => ParentMemoryBlock.WriteBytes(PointedAddress, value.GetBytes());
        }

        public T this[int index] => GetObjectInArray(index);

        public A GetObjAsType<A>() where A : IMemoryObject, new()
        {
            A obj = new A();
            obj.ParentMemoryBlock = ParentMemoryBlock;
            obj.pThis = PointedAddress;
            obj.ReloadFromMemory(obj.ByteSize);
            return obj;
        }

        public A GetObjInArrayAsType<A>(int index) where A : IMemoryObject, new()
        {
            A obj = new A();
            obj.ParentMemoryBlock = ParentMemoryBlock;
            obj.pThis = PointedAddress + (obj.ByteSize * index);
            obj.ReloadFromMemory(obj.ByteSize);
            return obj;
        }

        /// <summary>
        /// Is false when the pointer is null.
        /// </summary>
        public bool IsValid => (PointedAddress != IntPtr.Zero);

        public override string ToString()
        {
            return "0x" + PointedAddress.ToString("X");
        }

        /// <summary>
        /// Returns the object at the address with a given offset.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetObjectInArray(int index)
        {
            T obj = new T();
            obj.ParentMemoryBlock = ParentMemoryBlock;
            obj.pThis = PointedAddress + (index * obj.ByteSize);
            obj.ReloadFromMemory(obj.ByteSize);
            return obj;
        }

        public T[] ToArray(int length)
        {
            T[] arr = new T[length];
            for(int i = 0; i < length; i++)
            {
                arr[i] = GetObjectInArray(i);
            }
            return arr;
        }

        /// <summary>
        /// Sets the object at the address with a given offset.
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="obj"></param>
        public void SetObjectInArray(int Index, T obj)
        {
            ParentMemoryBlock.WriteBinaryObject(PointedAddress + (Index * 4), obj);
        }

        #region IBinaryObject
        public const int BYTE_SIZE = 4;
        public override int ByteSize => BYTE_SIZE;

        public override void SetData(byte[] data, out int bytesConsumed)
        {
            PointedAddress = (IntPtr)BitConverter.ToInt32(data, 0);
            bytesConsumed = BYTE_SIZE;
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes((int)PointedAddress);
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
