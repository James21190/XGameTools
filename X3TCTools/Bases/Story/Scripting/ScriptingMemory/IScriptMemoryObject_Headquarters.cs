using Common.Memory;
using X3Tools.Bases.Sector;

namespace X3Tools.Bases.Story.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Headquarters : IScriptMemoryObject_Station
    {
        int pAvailableBlueprintHashTable { get; }
        ScriptTableObject AvailableBlueprintHashTable { get; }

        SectorObject.SectorObjectType[] AvailableBlueprints { get; }
    }
}
