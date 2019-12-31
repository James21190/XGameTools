using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Memory;
using Common.Memory;


namespace X2Tools.X2
{
    /// <summary>
    /// Main hash table interface.
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// The size of this object in bytes.
        /// </summary>
        public const int ByteSize = 16;

        /// <summary>
        /// Pointer to the main hash table array.
        /// </summary>
        public IntPtr pHashTable
        {
            get;
            private set;
        }
        /// <summary>
        /// The length of the hash table array.
        /// </summary>
        public int TableLength
        {
            get;
            private set;
        }
        /// <summary>
        /// The last used ID that was placed into the table.
        /// </summary>
        public int LastUsedID
        {
            get;
            private set;
        }
        /// <summary>
        /// The number of objects currently in the table.
        /// </summary>
        public int ObjectCount
        {
            get;
            private set;
        }

        private GameHook m_GameHook;

        public HashTable(GameHook gameHook, byte[] Memory)
        {
            pHashTable = (IntPtr)BitConverter.ToInt32(Memory, 0);
            TableLength = BitConverter.ToInt32(Memory, 4);
            LastUsedID = BitConverter.ToInt32(Memory, 8);
            ObjectCount = BitConverter.ToInt32(Memory, 12);

            m_GameHook = gameHook;
        }

        /// <summary>
        /// Returns the address of the object with a given ID.
        /// Returns a null pointer if the object is not found.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IntPtr GetObjectWithID(int ID)
        {
            int index = (TableLength - 1 & ID);

            var pEntry = (IntPtr)BitConverter.ToInt32(MemoryControl.Read(m_GameHook.hProcess, pHashTable, 4 * TableLength), index * 4);
            var Entry = new Entry(MemoryControl.Read(m_GameHook.hProcess, pEntry, 12));
            while (true)
            {
                if (Entry.ID == ID)
                    return Entry.pObject;
                if (Entry.pNext == IntPtr.Zero)
                    return IntPtr.Zero;
                pEntry = Entry.pNext;
                Entry = new Entry(MemoryControl.Read(m_GameHook.hProcess, pEntry, 12));

            }
        }

        /// <summary>
        /// The object that is stored that points to the next entry, or to the attached object.
        /// </summary>
        private class Entry
        {
            /// <summary>
            /// Pointer to the next entry.
            /// </summary>
            public IntPtr pNext;
            /// <summary>
            /// ID of the attached object.
            /// </summary>
            public int ID;
            /// <summary>
            /// Pointer to the object.
            /// </summary>
            public IntPtr pObject;

            public Entry(byte[] Memory)
            {
                pNext = (IntPtr)BitConverter.ToInt32(Memory, 0);
                ID = BitConverter.ToInt32(Memory, 4);
                pObject = (IntPtr)BitConverter.ToInt32(Memory, 8);
            }
        }

    }
}
