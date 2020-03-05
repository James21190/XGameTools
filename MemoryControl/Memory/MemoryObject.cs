using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Memory
{
    /// <summary>
    /// Basic IMemoryObject with additional functionality.
    /// </summary>
    public abstract class MemoryObject : IMemoryObject
    {
        protected IntPtr m_hProcess;
        public IntPtr pThis { protected set; get; }

        /// <summary>
        /// Converts the values within the object into bytes.
        /// </summary>
        /// <returns></returns>
        public abstract byte[] GetBytes();

        /// <summary>
        /// Returns the size of the object in bytes.
        /// </summary>
        /// <returns></returns>
        public abstract int GetByteSize();

        /// <summary>
        /// Sets the values of the fields of this object with the values stored in a binary array.
        /// </summary>
        /// <param name="Memory"></param>
        public abstract void SetData(byte[] Memory);

        /// <summary>
        /// Sets the context of the object.
        /// Essential for keeping newly created objects from pointers in context.
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="address"></param>
        public virtual void SetLocation(IntPtr hProcess, IntPtr address)
        {
            m_hProcess = hProcess;
            pThis = address;
        }

        /// <summary>
        /// Reload values from memory.
        /// </summary>
        public void ReloadFromMemory()
        {
            SetData(MemoryControl.Read(m_hProcess, pThis, GetByteSize()));
        }

        /// <summary>
        /// Writes all values to memory.
        /// </summary>
        public void WriteToMemory()
        {
            MemoryControl.Write(m_hProcess, pThis, GetBytes());
        }

    }
}
