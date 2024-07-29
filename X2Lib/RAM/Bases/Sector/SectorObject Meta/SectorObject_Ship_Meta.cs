using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Lib.RAM.Bases.Sector.SectorObject_Meta
{
    public class SectorObject_Ship_Meta : SectorObjectMetaWithChildren
    {

        // Not Correct
        public override int ByteSize => 0x180;

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new NotImplementedException();
        }

        protected override void SetUniqueData(MemoryObjectConverter obl)
        {

        }
    }
}
