using Common.Memory;

namespace X3TCTools.Sector_Objects.Meta
{
    public class SectorObject_Sector_Meta : SectorObjectMetaWithChildren
    {
        public override int GetByteSize()
        {
            return 0x180;
        }

        protected override void SetUniqueData(ObjectByteList obl)
        {

        }
    }
}
