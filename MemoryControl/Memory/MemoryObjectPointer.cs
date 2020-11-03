﻿using System;

namespace Common.Memory
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
            m_hProcess = hProcess;
            this.address = address;
        }

        public MemoryObjectPointer(IntPtr hProcess)
        {
            m_hProcess = hProcess;
            address = IntPtr.Zero;
        }

        public MemoryObjectPointer()
        {
            m_hProcess = IntPtr.Zero;
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
                obj.SetLocation(m_hProcess, address);
                obj.ReloadFromMemory();
                return obj;
            }
            set => MemoryControl.Write(m_hProcess, address, value.GetBytes());
        }

        public T this[int index]
        {
            get
            {
                return GetObjectInArray(index);
            }
        }

        public A GetObjAsType<A>() where A : IMemoryObject, new()
        {
            A obj = new A();
            obj.SetLocation(m_hProcess, address);
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
            IntPtr newAddress = address + (Index * obj.GetByteSize());
            obj.SetLocation(m_hProcess, newAddress);
            obj.ReloadFromMemory();
            return obj;
        }

        /// <summary>
        /// Sets the object at the address with a given offset.
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="obj"></param>
        public void SetObjectInArray(int Index, T obj)
        {
            MemoryControl.Write(m_hProcess, address + (Index * 4), obj.GetBytes());
        }

        #region IMemoryObject
        public override int GetByteSize()
        {
            return 4;
        }

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
