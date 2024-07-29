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

        public const int BYTE_SIZE = 0x54;
        public override int ByteSize => BYTE_SIZE;

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

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            memoryObjectConverter.Seek(0x8);
            pFirst = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();

            memoryObjectConverter.Seek(0x10);
            pLast = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();

            memoryObjectConverter.Seek(0x3c);
            pPlayer = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();

            // Seek to end to consume the correct amount of bytes.
            memoryObjectConverter.Seek(BYTE_SIZE);
        }
    }
}
