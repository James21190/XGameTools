using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.Sector;

namespace XBTFLib.RAM.Bases.Sector
{
    public class SectorBase : XCommonLib.RAM.Bases.Sector.SectorBase
    {
        #region Memory
        MemoryObjectPointer<SectorObject> pFirst;
        MemoryObjectPointer<SectorObject> pLast;

        MemoryObjectPointer<SectorObject> pPlayer;
        #endregion

        public override XCommonLib.RAM.Bases.Sector.SectorObject First => pFirst.obj;

        public override XCommonLib.RAM.Bases.Sector.SectorObject Last => pLast.obj;

        public override XCommonLib.RAM.Bases.Sector.SectorObject Player => pPlayer.obj;

        public override int ByteSize => 0x54;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject GetSectorObject(int id)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject GetSectorObject(IntPtr pAddress)
        {
            throw new NotImplementedException();
        }

        public override int[] GetSectorObjectIDs()
        {
            throw new NotImplementedException();
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            pFirst = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>(0x8);
            pLast = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>(0x10);

            pPlayer = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>(0x3c);

            return SetDataResult.Success;
        }
    }
}
