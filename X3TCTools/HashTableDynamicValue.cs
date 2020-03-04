using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

using X3TCTools.Bases;

namespace X3TCTools
{
    /// <summary>
    /// The object used for traversing and fetching objects from a hash table
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashTableDynamicValue : MemoryObject
    {
        #region Classes
        public class Entry : MemoryObject
        {
            public const int ByteSize = 14;


            public MemoryObjectPointer<Entry> pNext;
            public DynamicValue id;
            public DynamicValue value;

            #region Constructors

            public Entry()
            {
                pNext = new MemoryObjectPointer<Entry>(m_hProcess);
                id = new DynamicValue();
                value = new DynamicValue();
            }

            #endregion

            #region IMemoryObject
            public override byte[] GetBytes()
            {
                var collection = new ObjectByteList();
                collection.Append(pNext.address);
                collection.Append(id);
                collection.Append(value);
                return collection.GetBytes();
            }

            public override int GetByteSize()
            {
                return ByteSize;
            }

            public override void SetData(byte[] Memory)
            {
                var collection = new ObjectByteList(Memory);
                collection.PopFirst(ref pNext.address);
                collection.PopFirst(ref id);
                collection.PopFirst(ref value);
            }

            public override void SetLocation(IntPtr hProcess, IntPtr address)
            {
                pNext.SetLocation(hProcess, address);
                id.SetLocation(hProcess, address + 0x4);
                value.SetLocation(hProcess, address + 0x8);
                base.SetLocation(hProcess, address);
            }
            #endregion
        }
        #endregion
        #region Constants
        public const int ByteSize = 16;
        #endregion
        #region Fields
        public MemoryObjectPointer<MemoryObjectPointer<Entry>> ppEntry;
        public int Length;
        public int NextAvailableID;
        public int Count;
        #endregion

        public HashTableDynamicValue()
        {
            ppEntry = new MemoryObjectPointer<MemoryObjectPointer<Entry>>();
        }

        public DynamicValue GetObject(DynamicValue ID)
        {
            return GetEntry(ID);
        }

        public IntPtr GetAddress(DynamicValue ID)
        {
            return GetEntry(ID).pThis;
        }

        /// <summary>
        /// Returns all ID's stored in the hash table.
        /// </summary>
        /// <returns></returns>
        public DynamicValue[] ScanContents()
        {
            int temp;
            return ScanContents(out temp);
        }

        public DynamicValue[] ScanContents(out int NumOfNulls)
        {
            NumOfNulls = 0;
            List<DynamicValue> results = new List<DynamicValue>();
            for (int i = 0; i < Length; i++)
            {
                var pEntry = ppEntry.GetObjectInArray(i);
                if (pEntry.IsValid)
                {

                    var entry = pEntry.obj;
                    while (true)
                    {
                        results.Add(entry.id);

                        if (!entry.pNext.IsValid) break;
                        entry = entry.pNext.obj;
                    }

                }

            }
            return results.ToArray();
        }

        /// <summary>
        /// Returns the entry with a given id. Throws an exception if not found.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private DynamicValue GetEntry(DynamicValue ID)
        {
            var index = GetIndex(ID.Value);

            var pEntry = ppEntry.GetObjectInArray(index);

            if(!pEntry.IsValid)
                throw new Exception("Object not found in hash table");

            var entry = pEntry.obj;
            while (entry.id != ID)
            {
                if (!entry.pNext.IsValid)
                    throw new Exception("Object not found in hash table");
                entry = entry.pNext.obj;
            }
            return entry.value;
        }

        private int GetIndex(int ID)
        {
            return (Length - 1) & ID;
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(ppEntry.address);
            collection.Append(Length);
            collection.Append(NextAvailableID);
            collection.Append(Count);

            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);
            collection.PopFirst(ref ppEntry);
            collection.PopFirst(ref Length);
            collection.PopFirst(ref NextAvailableID);
            collection.PopFirst(ref Count);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            ppEntry.SetLocation(hProcess, address);
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
