using System;

namespace Common.Memory
{
    /// <summary>
    /// Basic IMemoryObject with additional functionality.
    /// </summary>
    public abstract class MemoryObject : IMemoryObject
    {
        protected IntPtr m_hProcess;
        public IntPtr pThis { protected set; get; }

        #region IMemoryObject

        /// <summary>
        /// Converts the values within the object into bytes.
        /// </summary>
        /// <returns></returns>
        public abstract byte[] GetBytes();

        /// <summary>
        /// The size of the object in bytes.
        /// </summary>
        /// <returns></returns>
        public abstract int ByteSize { get; }

        /// <summary>
        /// Sets the values of the fields of this object with the values stored in a binary array.
        /// </summary>
        /// <param name="Memory"></param>
        public virtual void SetData(byte[] Memory)
        {
            SetDataFromObjectByteList(new ObjectByteList(Memory, m_hProcess, pThis));
        }

        #endregion

        /// <summary>
        /// Abstracted version of SetData using an ObjectByteList. Called from SetData unless overrided.
        /// </summary>
        /// <param name="objectByteList"></param>
        protected virtual void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the context of the object.
        /// Essential for keeping newly created objects from pointers in context.
        /// The memory is not automatically reloaded.
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
            SetData(MemoryControl.Read(m_hProcess, pThis, ByteSize ));
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
