﻿using CommonToolLib.Memory;
using System;
using System.Collections.Generic;

namespace X3Tools.RAM.Bases.Story.Scripting
{
    /// <summary>
    /// The object used for traversing and fetching objects from a hash table
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ScriptTableObject_Inner : MemoryObject
    {
        #region Classes
        public class Entry : MemoryObject
        {
            public MemoryObjectPointer<Entry> pNext;
            public DynamicValue id;
            public DynamicValue value;

            #region Constructors

            public Entry()
            {
                pNext = new MemoryObjectPointer<Entry>(hProcess);
                id = new DynamicValue();
                value = new DynamicValue();
            }

            #endregion

            #region IMemoryObject
            public override byte[] GetBytes()
            {
                ObjectByteList collection = new ObjectByteList();
                collection.Append(pNext.address);
                collection.Append(id);
                collection.Append(value);
                return collection.GetBytes();
            }

            public override int ByteSize => 14;

            public override void SetData(byte[] Memory)
            {
                ObjectByteList collection = new ObjectByteList(Memory);
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
        #region Fields
        public MemoryObjectPointer<MemoryObjectPointer<Entry>> ppEntry;
        public int Length;
        public int NextAvailableID;
        public int Count;
        #endregion

        public ScriptTableObject_Inner()
        {
            ppEntry = new MemoryObjectPointer<MemoryObjectPointer<Entry>>();
        }

        public bool ContainsObject(DynamicValue ID)
        {
            try
            {
                GetObject(ID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                MemoryObjectPointer<Entry> pEntry = ppEntry.GetObjectInArray(i);
                if (pEntry.IsValid)
                {

                    Entry entry = pEntry.obj;
                    while (true)
                    {
                        results.Add(entry.id);

                        if (!entry.pNext.IsValid)
                        {
                            break;
                        }

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
            int index = GetIndex(ID.Value);

            MemoryObjectPointer<Entry> pEntry = ppEntry.GetObjectInArray(index);

            if (!pEntry.IsValid)
            {
                throw new Exception("Object not found in hash table");
            }

            Entry entry = pEntry.obj;
            while (entry.id != ID)
            {
                if (!entry.pNext.IsValid)
                {
                    throw new Exception("Object not found in hash table");
                }

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
            ObjectByteList collection = new ObjectByteList();
            collection.Append(ppEntry.address);
            collection.Append(Length);
            collection.Append(NextAvailableID);
            collection.Append(Count);

            return collection.GetBytes();
        }

        public override int ByteSize => 16;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);
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
