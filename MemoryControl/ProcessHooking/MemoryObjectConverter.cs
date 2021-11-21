using CommonToolLib.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// A byte array that can combine IMemoryObjects and seperate them.
    /// </summary>
    public class MemoryObjectConverter : BinaryObjectConverter, IMemoryObject
    {

        public MemoryObjectConverter() : base()
        {
            pThis = IntPtr.Zero;
            hProcess = IntPtr.Zero;
        }
        public MemoryObjectConverter(byte[] data) : base(data)
        {
            pThis = IntPtr.Zero;
            hProcess = IntPtr.Zero;
        }
        public MemoryObjectConverter(byte[] data, IntPtr hProcess, IntPtr pThis) : base(data)
        {
            this.pThis = pThis;
            this.hProcess = hProcess;
        }

        #region IMemoryObject
        public IntPtr pThis { get; set; }
        public IntPtr hProcess { get; set; }
        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pThis = address;
            this.hProcess = hProcess;
        }
        public void ReloadFromMemory()
        {
            throw new NotSupportedException();
        }
        #endregion

        #region Appends
        #endregion

        #region Pops
        public T PopIMemoryObject<T>() where T : IMemoryObject, new()
        {
            T memoryObject = new T();

            memoryObject.hProcess = hProcess;
            memoryObject.pThis = pThis + _DataPointer;
            memoryObject.SetData(PopBytes(memoryObject.ByteSize));

            return memoryObject;
        }
        public T PopIMemoryObject<T>(int GoToOffset) where T : IMemoryObject, new()
        {
            Seek(GoToOffset);
            return PopIMemoryObject<T>();
        }

        public T[] PopIMemoryObjects<T>(int Count) where T : IMemoryObject, new()
        {
            T[] memoryObjects = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                memoryObjects[i] = new T();
                memoryObjects[i].hProcess = hProcess;
                memoryObjects[i].pThis = pThis + _DataPointer;
                memoryObjects[i].SetData(PopBytes(memoryObjects[i].ByteSize));
            }

            return memoryObjects;
        }
        public T[] PopIMemoryObjects<T>(int Count, int GoToOffset) where T : IMemoryObject, new()
        {
            Seek(GoToOffset);
            return PopIMemoryObjects<T>(Count);
        }
        #endregion

    }
}
