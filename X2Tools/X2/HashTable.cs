using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolLib;
using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;


namespace X2Tools.X2
{
    /// <summary>
    /// Main hash table interface.
    /// </summary>
    public class HashTable<T> : MemoryObject where T:MemoryObject, new()
    {
        /// <summary>
        /// The size of this object in bytes.
        /// </summary>
        public override int ByteSize => 16;

        #region Memory Fields

        /// <summary>
        /// Pointer to the main hash table array.
        /// </summary>
        public MemoryObjectPointer<Entry<T>> pHashTable = new MemoryObjectPointer<Entry<T>>();
        /// <summary>
        /// The length of the hash table array.
        /// </summary>
        public int TableLength;
        /// <summary>
        /// The last used ID that was placed into the table.
        /// </summary>
        public int LastUsedID;
        /// <summary>
        /// The number of objects currently in the table.
        /// </summary>
        public int ObjectCount;
        #endregion

        /// <summary>
        /// Returns the address of the object with a given ID.
        /// Returns a null pointer if the object is not found.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetObjectWithID(int ID)
        {
            int index = (TableLength - 1 & ID);

            var pEntry = pHashTable.GetObjectInArray(index);

            while (pEntry.pNext.IsValid)
            {
                if (pEntry.ID == ID) return pEntry.pObject.obj;
                pEntry = pEntry.pNext.obj;
            }
            return null;
        }

        #region IMemoryObject
        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter moc)
        {
            pHashTable = moc.PopIMemoryObject<MemoryObjectPointer<Entry<T>>>();
            TableLength = moc.PopInt();
            LastUsedID = moc.PopInt();
            ObjectCount = moc.PopInt();

            return SetDataResult.Success;
        }
        public override byte[] GetBytes()
        {
            var collection = new BinaryObjectConverter();

            collection.Append(pHashTable);
            collection.Append(TableLength);
            collection.Append(LastUsedID);
            collection.Append(ObjectCount);

            return collection.GetBytes();
        }
        #endregion

        /// <summary>
        /// The object that is stored that points to the next entry, or to the attached object.
        /// </summary>
        public class Entry<W> : MemoryObject where W:MemoryObject, new()
        {

            public override int ByteSize => 12;

            /// <summary>
            /// Pointer to the next entry.
            /// </summary>
            public MemoryObjectPointer<Entry<W>> pNext = new MemoryObjectPointer<Entry<W>>();
            /// <summary>
            /// ID of the attached object.
            /// </summary>
            public int ID;
            /// <summary>
            /// Pointer to the object.
            /// </summary>
            public MemoryObjectPointer<W> pObject = new MemoryObjectPointer<W>();

            #region IMemoryObject
            public override byte[] GetBytes()
            {
                var collection = new BinaryObjectConverter();
                collection.Append(pNext);
                collection.Append(ID);
                collection.Append(pObject);
                return collection.GetBytes();
            }

            protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
            {
                pNext = objectByteList.PopIMemoryObject<MemoryObjectPointer<Entry<W>>>();
                ID = objectByteList.PopInt();
                pObject = objectByteList.PopIMemoryObject<MemoryObjectPointer<W>>();
                return SetDataResult.Success;
            }
            #endregion
        }

    }
}
