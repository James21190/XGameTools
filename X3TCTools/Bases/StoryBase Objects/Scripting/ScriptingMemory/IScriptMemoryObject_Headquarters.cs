using Common.Memory;
using X3Tools.Sector_Objects;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Headquarters : IScriptMemoryObject_Station
    {
        int pAvailableBlueprintHashTable { get; }
        ScriptingHashTableObject AvailableBlueprintHashTable { get; }

        SectorObject.SectorObjectType[] AvailableBlueprints { get; }
    }
}
