using Common.Memory;

namespace X3Tools.Sector_Objects.Meta
{
    public interface ISectorObjectMeta : IMemoryObject
    {
        SectorObject GetFirstChild(SectorObject.Main_Type main_Type);
        SectorObject GetLastChild(SectorObject.Main_Type main_Type);
    }
}
