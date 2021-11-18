using CommonToolLib.ProcessHooking;

namespace X3TCAPLib.RAM.Bases.Sector.SectorObject_Meta
{
    public class SectorObject_Sector_Meta : SectorObjectMetaWithChildren
    {
        public override int ByteSize => 0x180;

        protected override void SetUniqueData(ObjectByteList obl)
        {

        }
    }
}
