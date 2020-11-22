using Common.Memory;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData : IMemoryObject
    {
        int ASectorEventObjectID { get; }
        ScriptingObject ASectorEventObject { get; }

        int pOwnedSectorEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedSectorEventObjectIDHashTableObject { get; }

        int pOwnedShipEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get; }

        int pOwnedShipyardEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedShipyardEventObjectIDHashTableObject { get; }

        int pOwnedStationEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject { get; }

        ScriptingObject[] Ships { get; }
        ScriptingObject[] Stations { get; }
        GameHook.RaceID RaceID { get; }
    }
}
