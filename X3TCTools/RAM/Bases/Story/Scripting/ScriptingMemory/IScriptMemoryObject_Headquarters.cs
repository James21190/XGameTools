using Common.Memory;
using X3Tools.RAM.Bases.Sector;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Headquarters : IScriptMemoryObject_Station
    {
        int pAvailableBlueprintHashTable { get; }
        ScriptTableObject AvailableBlueprintHashTable { get; }

        SectorObject.SectorObjectType[] AvailableBlueprints { get; }
    }
}
