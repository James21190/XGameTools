using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;

namespace XCommonLib.RAM.Generics
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
            public MemoryObjectPointer<Entry<t>> pNext;
            public int ObjectID;
            public MemoryObjectPointer<t> pObject;

            #region Constructors

            public Entry()
            {
                pNext = new MemoryObjectPointer<Entry<t>>(hProcess);
                ObjectID = 0;
                pObject = new MemoryObjectPointer<t>(hProcess);
            }

            #endregion

            #region IMemoryObject

            public override IntPtr pThis
            {
                get => base.pThis;
                set
                {
                    pNext.pThis = value;
                    pObject.pThis = value + 0x8;
                    base.pThis = value;
                }
            }
            public override IntPtr hProcess
            {
                get => base.hProcess;
                set
                {
                    pNext.hProcess = value;
                    pObject.hProcess = value;
                    base.hProcess = value;
                }
            }
            public override byte[] GetBytes()
            {
                MemoryObjectConverter collection = new MemoryObjectConverter();
                collection.Append(pNext.address);
                collection.Append(ObjectID);
                collection.Append(pObject.address);
                return collection.GetBytes();
            }

            public override int ByteSize => 12;

            protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
            {
                pNext.address = objectByteList.PopIntPtr();
                ObjectID = objectByteList.PopInt();
                pObject.address = objectByteList.PopIntPtr();
            }
            #endregion
        }

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
        /// Gets the address of an element within the table.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>IntPtr to the object or a null pointer</returns>
        public IntPtr GetAddress(int ID)
        {
            var obj = GetEntry(ID);
            if (obj == null)
                return IntPtr.Zero;
            return obj.address;
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
                MemoryObjectPointer<Entry<T>> pEntry = ppEntry.GetObjectInArray(i);
                if (pEntry.IsValid)
                {

                    Entry<T> entry = pEntry.obj;
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

                        if (!entry.pNext.IsValid)
                        {
                            break;
                        }

                        entry = entry.pNext.obj;
                    }

                }

            }

            results.Sort();

            return results.ToArray();
        }

        /// <summary>
        /// Returns the objects stored in the table.
        /// </summary>
        /// <returns></returns>
        public T[] GetAllContents()
        {
            T[] result = new T[Count];

            int[] ids = ScanContents();
            for (int i = 0; i < Count; i++)
            {
                result[i] = GetObject(ids[i]);
            }

            return result;
        }

        #endregion

        /// <summary>
        /// Returns the entry with a given id. Returns null if not found.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private MemoryObjectPointer<T> GetEntry(int ID)
        {
            int index = GetIndex(ID);

            MemoryObjectPointer<Entry<T>> pEntry = ppEntry.GetObjectInArray(index);

            if (!pEntry.IsValid)
            {
                return null;
            }

            Entry<T> entry = pEntry.obj;
            while (entry.ObjectID != ID)
            {
                if (!entry.pNext.IsValid)
                {
                    return null;
                }

                entry = entry.pNext.obj;
            }
            return entry.pObject;
        }

        public int GetIndex(int ID)
        {
            return (Length - 1) & ID;
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            MemoryObjectConverter collection = new MemoryObjectConverter();
            collection.Append(ppEntry.address);
            collection.Append(Length);
            collection.Append(NextAvailableID);
            collection.Append(Count);

            return collection.GetBytes();
        }

        public override int ByteSize => 16;

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter collection)
        {
            ppEntry = collection.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<Entry<T>>>>();
            Length = collection.PopInt();
            NextAvailableID = collection.PopInt();
            Count = collection.PopInt();
        }

        public override IntPtr hProcess
        {
            get => base.hProcess;
            set
            {
                ppEntry.hProcess = value;
                base.hProcess = value;
            }
        }

        public override IntPtr pThis
        {
            get => base.pThis;
            set
            {
                ppEntry.pThis = value;
                base.pThis = value;
            }
        }
        #endregion
    }
}
