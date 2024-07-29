using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Generics;

namespace X2Lib.RAM.Bases.Sector
{
    public class SectorBase : XCommonLib.RAM.Bases.Sector.SectorBase
    {
        #region Memory Fields
        public int Unknown_1;
        public int Unknown_2;
        /// <summary>
        /// Pointer to the first sector object in a linear list.
        /// </summary>
        public MemoryObjectPointer<SectorObject> pFirst = new MemoryObjectPointer<SectorObject>();
        /// <summary>
        /// Pointer to the last sector object in a linear list.
        /// </summary>
        public int Unknown_3;
        public MemoryObjectPointer<SectorObject> pLast = new MemoryObjectPointer<SectorObject>(); // 0x10
        /// <summary>
        /// Pointer to the hash table containing all SectorObject.
        /// </summary>
        public MemoryObjectPointer<HashTable<SectorObject>> pObjectHashTable = new MemoryObjectPointer<HashTable<SectorObject>>();
        public int Unknown_4;
        public int Unknown_5;
        public int Unknown_6; // 0x20
        public int Unknown_7;
        public int Unknown_8;
        public int Unknown_9;
        public int Unknown_10; // 0x30
        public int Unknown_11;
        /// <summary>
        /// Pointer to the SectorObject the player is currently piloting.
        /// </summary>
        public MemoryObjectPointer<SectorObject> pPlayerShip = new MemoryObjectPointer<SectorObject>();
        public int Unknown_12;
        public int PlayerShotsFired; // 0x40
        public int PlayerMissilesLaunched;
        public int PlayerShotsHit;
        public int PlayerMissilesHit;
        public int PlayerSubDistanceTravelled; // 0x50
        public int PlayerDistanceTraveled;
        public int Unknown_13;
        public int Unknown_14;
        public int Unknown_15; // 0x60
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Sector.SectorObject First => pFirst.obj;
        public override XCommonLib.RAM.Bases.Sector.SectorObject Last => pLast.obj;
        public override XCommonLib.RAM.Bases.Sector.SectorObject Player => pPlayerShip.obj;

        public override XCommonLib.RAM.Bases.Sector.SectorObject GetSectorObject(int id)
        {
            return pObjectHashTable.obj.GetObject(id);
        }
        public override XCommonLib.RAM.Bases.Sector.SectorObject GetSectorObject(IntPtr pAddress)
        {
            var so = new SectorObject();
            so.ParentMemoryBlock = ParentMemoryBlock;
            so.pThis = pAddress;
            so.ReloadFromMemory();
            return so;
        }
        #endregion

        #region IMemoryObject
        public override int ByteSize => 0x64;


        public override byte[] GetBytes()
        {
            MemoryObjectConverter collection = new MemoryObjectConverter();
            collection.Append(Unknown_1);
            collection.Append(Unknown_2);
            collection.Append(pFirst);
            collection.Append(Unknown_3);
            collection.Append(pLast);
            collection.Append(pObjectHashTable);
            collection.Append(Unknown_4);
            collection.Append(Unknown_5);
            collection.Append(Unknown_6);
            collection.Append(Unknown_7);
            collection.Append(Unknown_8);
            collection.Append(Unknown_9);
            collection.Append(Unknown_10);
            collection.Append(Unknown_11);
            collection.Append(pPlayerShip);
            collection.Append(Unknown_12);
            collection.Append(PlayerShotsFired);
            collection.Append(PlayerMissilesLaunched);
            collection.Append(PlayerShotsHit);
            collection.Append(PlayerMissilesHit);
            collection.Append(PlayerSubDistanceTravelled);
            collection.Append(PlayerDistanceTraveled);
            collection.Append(Unknown_13);
            collection.Append(Unknown_14);
            collection.Append(Unknown_15);
            return collection.GetBytes();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {

            Unknown_1 = memoryObjectConverter.PopInt();
            Unknown_2 = memoryObjectConverter.PopInt();
            pFirst = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            Unknown_3 = memoryObjectConverter.PopInt();
            pLast = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            pObjectHashTable = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<HashTable<SectorObject>>>();
            Unknown_4 = memoryObjectConverter.PopInt();
            Unknown_5 = memoryObjectConverter.PopInt();
            Unknown_6 = memoryObjectConverter.PopInt();
            Unknown_7 = memoryObjectConverter.PopInt();
            Unknown_8 = memoryObjectConverter.PopInt();
            Unknown_9 = memoryObjectConverter.PopInt();
            Unknown_10 = memoryObjectConverter.PopInt();
            Unknown_11 = memoryObjectConverter.PopInt();
            pPlayerShip = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            Unknown_12 = memoryObjectConverter.PopInt();
            PlayerShotsFired = memoryObjectConverter.PopInt();
            PlayerMissilesLaunched = memoryObjectConverter.PopInt();
            PlayerShotsHit = memoryObjectConverter.PopInt();
            PlayerMissilesHit = memoryObjectConverter.PopInt();
            PlayerSubDistanceTravelled = memoryObjectConverter.PopInt();
            PlayerDistanceTraveled = memoryObjectConverter.PopInt();
            Unknown_13 = memoryObjectConverter.PopInt();
            Unknown_14 = memoryObjectConverter.PopInt();
            Unknown_15 = memoryObjectConverter.PopInt();
        }

        public override int[] GetSectorObjectIDs()
        {
            return pObjectHashTable.obj.ScanContents();
        }

        public override IMemoryBlockManager ParentMemoryBlock
        {
            get => base.ParentMemoryBlock;
            set
            {
                pFirst.ParentMemoryBlock = value;
                pLast.ParentMemoryBlock = value;
                pObjectHashTable.ParentMemoryBlock = value;
                pPlayerShip.ParentMemoryBlock = value;
                base.ParentMemoryBlock = value;
            }
        }

        public override IntPtr pThis
        {
            get => base.pThis;
            set
            {
                pFirst.pThis = value + 0x8;
                pLast.pThis = value + 0x10;
                pObjectHashTable.pThis = value + 0x14;
                pPlayerShip.pThis = value + 0x38;
                base.pThis = value;
            }
        }
        #endregion
    }
}
