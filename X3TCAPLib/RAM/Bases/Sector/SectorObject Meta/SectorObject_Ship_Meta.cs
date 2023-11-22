using CommonToolLib.ProcessHooking;

namespace X3TCAPLib.RAM.Bases.Sector.SectorObject_Meta
{
    public class SectorObject_Ship_Meta : SectorObjectMetaWithChildren
    {
        public override int ByteSize => 0x940;

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new global::System.NotImplementedException();
        }

        protected override void SetUniqueData(MemoryObjectConverter obl)
        {

        }
    }
}
