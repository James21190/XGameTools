using Common.Memory;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Sector : IMemoryObject, IValidateable
    {
        int SectorX { get; }
        int SectorY { get; }

        int BackgroundID { get; }

        int OwningRaceDataScriptingObjectID { get; }
        ScriptingObject OwningRaceDataScriptingObject { get; }

        int pShipScriptingObjectHashTableObject { get; }
        ScriptingHashTableObject ShipScriptingObjectHashTableObject { get; }

        int pGateScriptingObjectHashTableObject { get; }
        ScriptingHashTableObject GateScriptingObjectHashTableObject { get; }

        int OwnerDataScriptingObjectID { get; }
        ScriptingObject OwnerDataScriptingObject { get; }

    }
}
