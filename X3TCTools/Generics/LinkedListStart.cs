using Common.Memory;
using System;

namespace X3TCTools.Generics
{
    /// <summary>
    /// Top of a linked list for objects. Holds pointers to both the first and last object in a list.
    /// Notabaly used for children of an object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListStart<T> : MemoryObject where T : IMemoryObject, new()
    {
        // Pointer to the first object.
        public MemoryObjectPointer<T> pFirst = new MemoryObjectPointer<T>();
        // Null value used when no objects are in the list.
        public int NullValue;
        // Pointer to the last object.
        public MemoryObjectPointer<T> pLast = new MemoryObjectPointer<T>();

        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(pFirst);
            collection.Append(NullValue);
            collection.Append(pLast);
            return collection.GetBytes();
        }

        public const int ByteSizeConst = 12;
        public override int ByteSize => ByteSizeConst;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);
            pFirst = collection.PopIMemoryObject<MemoryObjectPointer<T>>();
            NullValue = collection.PopInt();
            pLast = collection.PopIMemoryObject<MemoryObjectPointer<T>>();
        }
        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pFirst.SetLocation(hProcess, address);
            pLast.SetLocation(hProcess, address + 8);
        }
    }
}
