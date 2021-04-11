using Common.Memory;
using System;
using System.Security.Policy;
using X3Tools.RAM.Generics;

namespace X3Tools.RAM.Bases.Sector
{
    /// <summary>
    /// Main object that holds references to all active SectorObjects.
    /// </summary>
    public class SectorBase : MemoryObject
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

        public SectorBase()
        {
            pObjectHashTable = new MemoryObjectPointer<HashTable<SectorObject>>();
            pPlayerShip = new MemoryObjectPointer<SectorObject>();
        }
        #endregion

        /// <summary>
        /// Gets the space SectorObject.
        /// Returns null if not found or invalid.
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
            if (!so.IsValid) return null;
            return so;
        }

        /// <summary>
        /// Gets the player ship SectorObject.
        /// Returns null if not found or invalid.
        /// </summary>
        /// <returns></returns>
        public SectorObject GetPlayerObject()
        {
            if (!pPlayerShip.IsValid) return null;
            if (!pPlayerShip.obj.IsValid) return null;

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
            value.SetLocation(hProcess, address);
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

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            Unknown_1 = objectByteList.PopInt();
            Unknown_2 = objectByteList.PopInt();
            pFirst = objectByteList.PopIntPtr();
            Unknown_3 = objectByteList.PopInt();
            pLast = objectByteList.PopIntPtr();
            pObjectHashTable = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<SectorObject>>>();
            Unknown_4 = objectByteList.PopInt();
            Unknown_5 = objectByteList.PopInt();
            Unknown_6 = objectByteList.PopInt();
            Unknown_7 = objectByteList.PopInt();
            Unknown_8 = objectByteList.PopInt();
            Unknown_9 = objectByteList.PopInt();
            Unknown_10 = objectByteList.PopInt();
            Unknown_11 = objectByteList.PopInt();
            pPlayerShip = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            Unknown_12 = objectByteList.PopInt();
            Unknown_13 = objectByteList.PopInt();
            Unknown_14 = objectByteList.PopInt();
            Unknown_15 = objectByteList.PopInt();
            Unknown_16 = objectByteList.PopInt();
            Unknown_17 = objectByteList.PopInt();
            Unknown_18 = objectByteList.PopInt();
            Unknown_19 = objectByteList.PopInt();
            Unknown_20 = objectByteList.PopInt();
            Unknown_21 = objectByteList.PopInt();
            Unknown_22 = objectByteList.PopInt();
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
