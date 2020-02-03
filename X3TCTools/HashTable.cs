using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools
{
    /// <summary>
    /// The object used for traversing and fetching objects from a hash table
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashTable<T> : IMemoryObject where T : IMemoryObject, new()
    {
        #region Classes
        public class Entry<t> : IMemoryObject where t : IMemoryObject, new()
        {
            public const int ByteSize = 12;

            private IntPtr m_hProcess;

            public MemoryObjectPointer<Entry<t>> pNext;
            public int ObjectID;
            public MemoryObjectPointer<t> pObject;

            #region Constructors

            public Entry()
            {
                pNext = new MemoryObjectPointer<Entry<t>>(m_hProcess);
                ObjectID = 0;
                pObject = new MemoryObjectPointer<t>(m_hProcess);
            }

            #endregion

            #region IMemoryObject
            public byte[] GetBytes()
            {
                var collection = new ObjectByteList();
                collection.Append(pNext.address);
                collection.Append(ObjectID);
                collection.Append(pObject.address);
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
                collection.PopFirst(ref pNext.address);
                collection.PopFirst(ref ObjectID);
                collection.PopFirst(ref pObject.address);
            }

            public void SetLocation(IntPtr hProcess, IntPtr address)
            {
                m_hProcess = hProcess;
                pNext.SetLocation(hProcess, address);
                pObject.SetLocation(hProcess, address);
            }
            #endregion
        }
        #endregion
        #region Constants
        public const int ByteSize = 16;
        #endregion
        #region Fields
        public MemoryObjectPointer<MemoryObjectPointer<Entry<T>>> ppEntry;
        public int Length;
        public int LastUsedID;
        public int Count;
        #endregion

        public HashTable()
        {
            ppEntry = new MemoryObjectPointer<MemoryObjectPointer<Entry<T>>>();
        }

        public T GetObject(int ID)
        {
            return GetEntry(ID).obj;
        }

        public IntPtr GetAddress(int ID)
        {
            return GetEntry(ID).address;
        }

        private MemoryObjectPointer<T> GetEntry(int ID)
        {
            var index = GetIndex(ID);

            var pEntry = ppEntry.GetObjectInArray(index);

            if(!pEntry.IsValid)
                throw new Exception("Object not found in hash table");

            var entry = pEntry.obj;
            while (entry.ObjectID != ID)
            {
                if (!entry.pNext.IsValid)
                    throw new Exception("Object not found in hash table");
                entry = entry.pNext.obj;
            }
            return entry.pObject;
        }

        private int GetIndex(int ID)
        {
            return (Length - 1) & ID;
        }

        #region IMemoryObject
        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(ppEntry.address);
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
            collection.PopFirst(ref ppEntry);
            collection.PopFirst(ref Length);
            collection.PopFirst(ref LastUsedID);
            collection.PopFirst(ref Count);
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            ppEntry.SetLocation(hProcess, address);
        }
        #endregion
    }
}
