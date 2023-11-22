using CommonToolLib.ProcessHooking;

namespace X3TCAPLib.RAM.Bases.Sector.SectorObject_Meta
{
    internal class SectorObject_Station_Meta : SectorObjectMetaWithChildren
    {
        public override int ByteSize => 2000;

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new global::System.NotImplementedException();
        }

        protected override void SetUniqueData(MemoryObjectConverter obl)
        {

        }
    }
}
