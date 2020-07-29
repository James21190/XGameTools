﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools
{
    /// <summary>
    /// Represents a hash table.
    /// Provides methods for traversing and finding objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashTable<T> : MemoryObject where T : IMemoryObject, new()
    {
        public class Entry<t> : MemoryObject where t : IMemoryObject, new()
        {
            public const int ByteSize = 12;


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
            public override byte[] GetBytes()
            {
                var collection = new ObjectByteList();
                collection.Append(pNext.address);
                collection.Append(ObjectID);
                collection.Append(pObject.address);
                return collection.GetBytes();
            }

            public override int GetByteSize()
            {
                return ByteSize;
            }

            public override void SetData(byte[] Memory)
            {
                var collection = new ObjectByteList();
                collection.Append(Memory);
                collection.PopFirst(ref pNext.address);
                collection.PopFirst(ref ObjectID);
                collection.PopFirst(ref pObject.address);
            }

            public override void SetLocation(IntPtr hProcess, IntPtr address)
            {
                pNext.SetLocation(hProcess, address);
                pObject.SetLocation(hProcess, address + 0x8);
                base.SetLocation(hProcess, address);
            }
            #endregion
        }

        /// <summary>
        /// The size of the object in bytes.
        /// </summary>
        public const int ByteSize = 16;

        #region Fields
        /// <summary>
        /// Pointer to an array of pointers for entries.
        /// </summary>
        public MemoryObjectPointer<MemoryObjectPointer<Entry<T>>> ppEntry = new MemoryObjectPointer<MemoryObjectPointer<Entry<T>>>();
        /// <summary>
        /// The length of the array of pointers.
        /// </summary>
        public int Length;
        /// <summary>
        /// The next available ID for future entries.
        /// </summary>
        public int NextAvailableID;
        /// <summary>
        /// The number of entries currently in the table.
        /// </summary>
        public int Count;
        #endregion

        /// <summary>
        /// Returns the object with a given ID.
        /// Throws an exception if the object is not found.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetObject(int ID)
        {
            return GetEntry(ID).obj;
        }

        /// <summary>
        /// Returns the address of an object with a given ID.
        /// Throws an exception if the object is not found.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IntPtr GetAddress(int ID)
        {
            return GetEntry(ID).address;
        }

        #region Scans

        /// <summary>
        /// Returns all ID's stored in the hash table.
        /// </summary>
        /// <returns></returns>
        public int[] ScanContents()
        {
            int temp;
            return ScanContents(out temp);
        }

        /// <summary>
        /// Returns all ID's stored in the hash table and the number of null pointers.
        /// </summary>
        /// <param name="NumOfNulls"></param>
        /// <returns></returns>
        public int[] ScanContents(out int NumOfNulls)
        {
            NumOfNulls = 0;
            List<int> results = new List<int>();
            for (int i = 0; i < Length; i++)
            {
                var pEntry = ppEntry.GetObjectInArray(i);
                if (pEntry.IsValid)
                {

                    var entry = pEntry.obj;
                    while (true)
                    {
                        if (entry.pObject.IsValid)
                        {
                            results.Add(entry.ObjectID);
                        }
                        else
                        {
                            NumOfNulls++;
                        }

                        if (!entry.pNext.IsValid) break;
                        entry = entry.pNext.obj;
                    }

                }

            }

            results.Sort();

            return results.ToArray();
        }

        #endregion

        /// <summary>
        /// Returns the entry with a given id. Throws an exception if not found.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
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

        protected override void SetDataFromObjectByteList(ObjectByteList collection)
        {
            ppEntry = collection.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<Entry<T>>>>();
            Length = collection.PopInt();
            NextAvailableID = collection.PopInt();
            Count = collection.PopInt();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            ppEntry.SetLocation(hProcess, address);
        }
        #endregion
    }
}
