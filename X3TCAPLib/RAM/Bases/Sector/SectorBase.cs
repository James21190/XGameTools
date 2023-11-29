using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Generics;

namespace X3TCAPLib.RAM.Bases.Sector
{
    public class SectorBase : XCommonLib.RAM.Bases.Sector.SectorBase
    {
        #region Memory Fields
        public int Unknown_1;
        public int Unknown_2;
        public MemoryObjectPointer<SectorObject> pFirst = new MemoryObjectPointer<SectorObject>();
        public int Unknown_3;
        public MemoryObjectPointer<SectorObject> pLast = new MemoryObjectPointer<SectorObject>();
        public MemoryObjectPointer<HashTable<SectorObject>> pObjectHashTable = new MemoryObjectPointer<HashTable<SectorObject>>();
        public int Unknown_4;
        public int Unknown_5;
        public int Unknown_6;
        public int Unknown_7;
        public int Unknown_8;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        public MemoryObjectPointer<SectorObject> pPlayerShip = new MemoryObjectPointer<SectorObject>();
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

        #region MemoryObject
        public override int ByteSize => 0x68;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            Unknown_1 = objectByteList.PopInt(); // 0x0
            Unknown_2 = objectByteList.PopInt();
            pFirst = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            Unknown_3 = objectByteList.PopInt();
            pLast = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>(); // 0x10
            pObjectHashTable = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<SectorObject>>>();
            Unknown_4 = objectByteList.PopInt();
            Unknown_5 = objectByteList.PopInt();
            Unknown_6 = objectByteList.PopInt(); // 0x20
            Unknown_7 = objectByteList.PopInt();
            Unknown_8 = objectByteList.PopInt();
            Unknown_9 = objectByteList.PopInt();
            Unknown_10 = objectByteList.PopInt(); // 0x30
            Unknown_11 = objectByteList.PopInt();
            pPlayerShip = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            Unknown_12 = objectByteList.PopInt();
            Unknown_13 = objectByteList.PopInt(); // 0x40
            Unknown_14 = objectByteList.PopInt();
            Unknown_15 = objectByteList.PopInt();
            Unknown_16 = objectByteList.PopInt();
            Unknown_17 = objectByteList.PopInt(); // 0x50
            Unknown_18 = objectByteList.PopInt();
            Unknown_19 = objectByteList.PopInt();
            Unknown_20 = objectByteList.PopInt();
            Unknown_21 = objectByteList.PopInt(); // 0x60
            Unknown_22 = objectByteList.PopInt();

            return SetDataResult.Success;
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
