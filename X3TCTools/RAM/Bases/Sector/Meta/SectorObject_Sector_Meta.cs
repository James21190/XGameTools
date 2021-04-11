using Common.Memory;

namespace X3Tools.RAM.Bases.Sector.Meta
{
    public class SectorObject_Sector_Meta : SectorObjectMetaWithChildren
    {
        public override int ByteSize => 0x180;

        protected override void SetUniqueData(ObjectByteList obl)
        {

        }
    }
}
