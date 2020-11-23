using Common.Memory;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Sector : IMemoryObject, IValidateable
    {
        int SectorX { get; }
        int SectorY { get; }

        int BackgroundID { get; }

        int OwningRaceDataEventObjectID { get; }
        ScriptingObject OwningRaceDataEventObject { get; }

        int pShipEventObjectHashTableObject { get; }
        ScriptingHashTableObject ShipEventObjectHashTableObject { get; }

        int pGateEventObjectHashTableObject { get; }
        ScriptingHashTableObject GateEventObjectHashTableObject { get; }

        int OwnerDataEventObjectID { get; }
        ScriptingObject OwnerDataEventObject { get; }

    }
}
