using Common.Memory;

namespace X3TCTools.SectorObjects.Meta
{
    internal class SectorObject_Station_Meta : SectorObjectMetaWithChildren
    {
        public override int GetByteSize()
        {
            return 2000;
        }

        protected override void SetUniqueData(ObjectByteList obl)
        {

        }
    }
}
