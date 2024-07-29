using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Sector.SectorObject_Meta
{
    public class SectorObject_Gate_Meta : SectorObjectMetaWithChildren
    {
        public override int ByteSize => 0x940; // Unknown

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            throw new NotImplementedException();
        }

        protected override void SetUniqueData(MemoryObjectConverter obl)
        {

        }
    }
}
