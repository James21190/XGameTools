using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.Sector;
using XCommonLib.RAM.Generics;

namespace X3TCAPLib.RAM.Bases.Sector
{
    public class SectorBase : XCommonLib.RAM.Bases.Sector.SectorBase
    {
        #region Memory Fields
        public int Unknown_1;
        public int Unknown_2;
        public MemoryObjectPointer<SectorObject> pFirst;
        public int Unknown_3;
        public MemoryObjectPointer<SectorObject> pLast;
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

        #region Common
        public override XCommonLib.RAM.Bases.Sector.SectorObject First { get => pFirst.obj; }
        public override XCommonLib.RAM.Bases.Sector.SectorObject Last { get => pLast.obj; }
        public override XCommonLib.RAM.Bases.Sector.SectorObject Player { get => pPlayerShip.obj; }
        #endregion

        #region MemoryObject
        public override int ByteSize => 0x68;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
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
        }
        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            if (pFirst != null) pFirst.SetLocation(hProcess, address + 0x8);
            if (pLast != null) pLast.SetLocation(hProcess, address + 0x10);
            if (pObjectHashTable != null) pObjectHashTable.SetLocation(hProcess, address + 0x14);
            if (pPlayerShip != null) pPlayerShip.SetLocation(hProcess, address + 0x38);
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
