using Common.Memory;
using System;
using X3TCTools.Generics;

namespace X3TCTools.Sector_Objects
{
    /// <summary>
    /// Main object that holds references to all active SectorObjects.
    /// </summary>
    public class SectorObjectManager : MemoryObject
    {
        #region Memory Fields
        public int Unknown_1;
        public int Unknown_2;
        public IntPtr pFirst;
        public int Unknown_3;
        public IntPtr pLast;
        public MemoryObjectPointer<HashTable<SectorObject>> pObjectHashTable;
        public int Unknown_4;
        public int Unknown_5;
        public int Unknown_6;
        public int Unknown_7;
        public int Unknown_8;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        public MemoryObjectPointer<SectorObject> pPlayerShip;
        public int Unknown_12;
        public int Unknown_13;
        public int Unknown_14;
        public int Unknown_15;
        public int Unknown_16;
        public int Unknown_17;
        public int Unknown_18;
        public int Unknown_19;
        public int Unknown_20;
        public int Unknown_21;
        public int Unknown_22;
        #endregion

        #region Constructors

        public SectorObjectManager()
        {
            pObjectHashTable = new MemoryObjectPointer<HashTable<SectorObject>>();
            pPlayerShip = new MemoryObjectPointer<SectorObject>();
        }
        #endregion

        /// <summary>
        /// Gets the space SectorObject.
        /// Returns null if not found.
        /// </summary>
        /// <returns></returns>
        public SectorObject GetSpace()
        {
            SectorObject so = GetSectorObject(pFirst);
            while (so.ObjectType.MainTypeEnum != SectorObject.Main_Type.Sector)
            {
                if (so.pNext.address == IntPtr.Zero)
                {
                    return null;
                }

                so = so.pNext.obj;
            }
            return so;
        }

        public SectorObject GetPlayerObject()
        {
            if (!pPlayerShip.IsValid)
            {
                throw new Exception("Player ship not found!");
            }

            return pPlayerShip.obj;
        }

        #region Sector Object Primary

        #region Via Address

        /// <summary>
        /// Returns a SectorObject at the given address.
        /// Unsafe method, use the object's ID instead.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public SectorObject GetSectorObject(IntPtr address)
        {
            SectorObject value = new SectorObject();
            value.SetLocation(m_hProcess, address);
            value.ReloadFromMemory();
            return value;
        }
        #endregion

        #region Via ID
        /// <summary>
        /// Returns the SectorObject with a given ID.
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public SectorObject GetSectorObject(int objectID)
        {
            HashTable<SectorObject> table = pObjectHashTable.obj;
            SectorObject value = table.GetObject(objectID);
            return value;

        }

        #endregion


        #endregion

        #region Memory
        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(Unknown_1);
            collection.Append(Unknown_2);
            collection.Append(pFirst);
            collection.Append(Unknown_3);
            collection.Append(pLast);
            collection.Append(pObjectHashTable.address);
            collection.Append(Unknown_4);
            collection.Append(Unknown_5);
            collection.Append(Unknown_6);
            collection.Append(Unknown_7);
            collection.Append(Unknown_8);
            collection.Append(Unknown_9);
            collection.Append(Unknown_10);
            collection.Append(Unknown_11);
            collection.Append(pPlayerShip.address);
            collection.Append(Unknown_12);
            collection.Append(Unknown_13);
            collection.Append(Unknown_14);
            collection.Append(Unknown_15);
            collection.Append(Unknown_16);
            collection.Append(Unknown_17);
            collection.Append(Unknown_18);
            collection.Append(Unknown_19);
            collection.Append(Unknown_20);
            collection.Append(Unknown_21);
            collection.Append(Unknown_22);

            return collection.GetBytes();
        }

        public override int ByteSize => 0x68;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList();
            collection.SetData(Memory);

            collection.PopFirst(ref Unknown_1);
            collection.PopFirst(ref Unknown_2);
            collection.PopFirst(ref pFirst);
            collection.PopFirst(ref Unknown_3);
            collection.PopFirst(ref pLast);
            collection.PopFirst(ref pObjectHashTable.address);
            collection.PopFirst(ref Unknown_4);
            collection.PopFirst(ref Unknown_5);
            collection.PopFirst(ref Unknown_6);
            collection.PopFirst(ref Unknown_7);
            collection.PopFirst(ref Unknown_8);
            collection.PopFirst(ref Unknown_9);
            collection.PopFirst(ref Unknown_10);
            collection.PopFirst(ref Unknown_11);
            collection.PopFirst(ref pPlayerShip.address);
            collection.PopFirst(ref Unknown_12);
            collection.PopFirst(ref Unknown_13);
            collection.PopFirst(ref Unknown_14);
            collection.PopFirst(ref Unknown_15);
            collection.PopFirst(ref Unknown_16);
            collection.PopFirst(ref Unknown_17);
            collection.PopFirst(ref Unknown_18);
            collection.PopFirst(ref Unknown_19);
            collection.PopFirst(ref Unknown_20);
            collection.PopFirst(ref Unknown_21);
            collection.PopFirst(ref Unknown_22);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pObjectHashTable.SetLocation(hProcess, address + 0x14);
            pPlayerShip.SetLocation(hProcess, address + 0x38);
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
