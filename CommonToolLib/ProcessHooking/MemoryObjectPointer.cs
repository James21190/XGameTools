using System;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// A pointer that points to an IMemoryObject in a process's memory.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class MemoryObjectPointer<T> : MemoryObject where T : IMemoryObject, new()
    {

        #region Constructors
        public MemoryObjectPointer(IntPtr hProcess, IntPtr address)
        {
            this.hProcess = hProcess;
            this.address = address;
        }

        public MemoryObjectPointer(IntPtr hProcess)
        {
            this.hProcess = hProcess;
            address = IntPtr.Zero;
        }

        public MemoryObjectPointer()
        {
            hProcess = IntPtr.Zero;
            address = IntPtr.Zero;
        }

        #endregion
        /// <summary>
        /// The address that is pointed to.
        /// </summary>
        public IntPtr address;

        /// <summary>
        /// The object at the address.
        /// Returns a new object from the process memory.
        /// Sets to the process memory.
        /// </summary>
        public T obj
        {
            get
            {
                T obj = new T();
                obj.SetLocation(hProcess, address);
                obj.ReloadFromMemory();
                return obj;
            }
            set => MemoryControl.Write(hProcess, address, value.GetBytes());
        }

        public T this[int index] => GetObjectInArray(index);

        public A GetObjAsType<A>() where A : IMemoryObject, new()
        {
            A obj = new A();
            obj.SetLocation(hProcess, address);
            obj.ReloadFromMemory();
            return obj;
        }

        public A GetObjInArrayAsType<A>(int Index) where A : IMemoryObject, new()
        {
            A obj = new A();
            obj.SetLocation(hProcess, address + (obj.ByteSize * Index));
            obj.ReloadFromMemory();
            return obj;
        }

        /// <summary>
        /// Is false when the pointer is null.
        /// </summary>
        public bool IsValid => (address != IntPtr.Zero);

        public override string ToString()
        {
            return "0x" + address.ToString("X");
        }

        /// <summary>
        /// Returns the object at the address with a given offset.
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public T GetObjectInArray(int Index)
        {
            T obj = new T();
            IntPtr newAddress = address + (Index * obj.ByteSize);
            obj.SetLocation(hProcess, newAddress);
            obj.ReloadFromMemory();
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
            MemoryControl.Write(hProcess, address + (Index * 4), obj.GetBytes());
        }

        #region IMemoryObject
        public override int ByteSize => 4;

        public override void SetData(byte[] Memory)
        {
            address = (IntPtr)BitConverter.ToInt32(Memory, 0);
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes((int)address);
        }

        #endregion
    }
}
