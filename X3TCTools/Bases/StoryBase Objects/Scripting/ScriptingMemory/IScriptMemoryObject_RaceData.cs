using Common.Memory;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData : IMemoryObject
    {
        int ASectorScriptingObjectID { get; }
        ScriptingObject ASectorScriptingObject { get; }

        int pOwnedSectorScriptingObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedSectorScriptingObjectIDHashTableObject { get; }

        int pOwnedShipScriptingObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedShipScriptingObjectIDHashTableObject { get; }

        int pOwnedShipyardScriptingObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedShipyardScriptingObjectIDHashTableObject { get; }

        int pOwnedStationScriptingObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedStationScriptingObjectIDHashTableObject { get; }

        ScriptingObject[] Ships { get; }
        ScriptingObject[] Stations { get; }
        GameHook.RaceID RaceID { get; }
    }
}
