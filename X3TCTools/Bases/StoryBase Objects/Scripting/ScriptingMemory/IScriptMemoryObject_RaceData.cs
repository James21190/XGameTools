using Common.Memory;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData : IMemoryObject
    {
        int ASectorEventObjectID { get; }
        EventObject ASectorEventObject { get; }

        int pOwnedSectorEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedSectorEventObjectIDHashTableObject { get; }

        int pOwnedShipEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get; }

        int pOwnedShipyardEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedShipyardEventObjectIDHashTableObject { get; }

        int pOwnedStationEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject { get; }

        EventObject[] Ships { get; }
        EventObject[] Stations { get; }
        GameHook.RaceID RaceID { get; }
    }
}
