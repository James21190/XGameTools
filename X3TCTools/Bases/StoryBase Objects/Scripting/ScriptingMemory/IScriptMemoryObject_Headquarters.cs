using Common.Memory;
using X3TCTools.Sector_Objects;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Headquarters : IScriptMemoryObject_Station
    {
        int pAvailableBlueprintHashTable { get; }
        ScriptingHashTableObject AvailableBlueprintHashTable { get; }

        SectorObject.SectorObjectType[] AvailableBlueprints { get; }
    }
}
