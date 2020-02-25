using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Memory
{
    /// <summary>
    /// A pointer that points to an IMemoryObject in a process's memory.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class MemoryObjectPointer<T> :MemoryObject where T : IMemoryObject, new()
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
            this.address = IntPtr.Zero;
        }

        public MemoryObjectPointer()
        {
            m_hProcess = IntPtr.Zero;
            this.address = IntPtr.Zero;
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
                var obj = new T();
                obj.SetLocation(m_hProcess, address);
                obj.ReloadFromMemory();
                return obj;
            }
            set
            {
                MemoryControl.Write(m_hProcess, address, value.GetBytes());
            }
        }

        /// <summary>
        /// Is false when the pointer is null.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return (address != IntPtr.Zero);
            }
        }

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
            var obj = new T();
            var newAddress = address + (Index * obj.GetByteSize());
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
