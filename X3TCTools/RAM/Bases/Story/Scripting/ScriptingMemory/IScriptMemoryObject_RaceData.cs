using Common.Memory;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData : IMemoryObject
    {
        int ASectorScriptingObjectID { get; }
        ScriptInstance ASectorScriptingObject { get; }

        int pOwnedSectorScriptingObjectIDHashTableObject { get; }
        ScriptTableObject OwnedSectorScriptingObjectIDHashTableObject { get; }

        int pOwnedShipScriptingObjectIDHashTableObject { get; }
        ScriptTableObject OwnedShipScriptingObjectIDHashTableObject { get; }

        int pOwnedShipyardScriptingObjectIDHashTableObject { get; }
        ScriptTableObject OwnedShipyardScriptingObjectIDHashTableObject { get; }

        int pOwnedStationScriptingObjectIDHashTableObject { get; }
        ScriptTableObject OwnedStationScriptingObjectIDHashTableObject { get; }

        ScriptInstance[] Ships { get; }
        ScriptInstance[] Stations { get; }
        GameHook.RaceID RaceID { get; }
    }
}
