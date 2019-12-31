using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools
{
    public class HashTable :IMemoryObject
    {

        public struct Entry : IMemoryObject
        {
            public const int ByteSize = 16;

            public IntPtr pNext;
            public int ObjectID;
            public IntPtr pObject;

            public Entry(byte[] Memory)
            {
                pNext = IntPtr.Zero;
                ObjectID = 0;
                pObject = IntPtr.Zero;
                SetData(Memory);
            }

            public byte[] GetBytes()
            {
                var collection = new ObjectByteList();
                collection.Append(pNext);
                collection.Append(ObjectID);
                collection.Append(pObject);
                return collection.GetBytes();
            }

            public int GetByteSize()
            {
                return ByteSize;
            }

            public void SetData(byte[] Memory)
            {
                var collection = new ObjectByteList();
                collection.Append(Memory);
                collection.PopFirst(ref pNext);
                collection.PopFirst(ref ObjectID);
                collection.PopFirst(ref pObject);
            }
        }

        public const int ByteSize = 16;
        private IntPtr m_pThis;
        private IntPtr m_hProcess;

        public IntPtr pTable;
        public int Length;
        public int LastUsedID;
        public int Count;


        public HashTable(IntPtr hProcess, IntPtr address)
        {
            m_hProcess = hProcess;
            m_pThis = address;
            SetData(MemoryControl.Read(m_hProcess, address, ByteSize));
        }

        /// <summary>
        /// Returns the address of an object with a given id.
        /// Returns null if the object is not found.
        /// </summary>
        /// <param name="ObjectID"></param>
        /// <returns></returns>
        public IntPtr GetAddressOfObject(int ObjectID)
        {
            var arrayIndex = GetIndex(ObjectID);
            var table = MemoryControl.ReadInt(m_hProcess, m_pThis);

            var entry = new Entry(MemoryControl.Read(m_hProcess, (IntPtr)(table + (arrayIndex * 4)), Entry.ByteSize));

            // Loop until object is found
            while (entry.ObjectID != ObjectID)
            {
                // If object is not in list, throw exception
                if (entry.pNext == IntPtr.Zero)
                {
                    return IntPtr.Zero;
                }
                entry = new Entry(MemoryControl.Read(m_hProcess, entry.pNext, Entry.ByteSize));
            }

            if (entry.pObject == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            return entry.pObject;
        }

        private int GetIndex(int ID)
        {
            return (Length - 1) & ID;
        }

        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(pTable);
            collection.Append(Length);
            collection.Append(LastUsedID);
            collection.Append(Count);

            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.Append(Memory);
            collection.PopFirst(ref pTable);
            collection.PopFirst(ref Length);
            collection.PopFirst(ref LastUsedID);
            collection.PopFirst(ref Count);
        }
    }
}
