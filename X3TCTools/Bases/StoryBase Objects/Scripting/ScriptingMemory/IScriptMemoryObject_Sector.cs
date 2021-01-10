using Common.Memory;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Sector : IMemoryObject, IValidateable
    {
        int SectorX { get; }
        int SectorY { get; }

        int BackgroundID { get; }
        int MusicId { get; }

        int OwningRaceDataScriptingObjectID { get; }
        ScriptInstance OwningRaceDataScriptingObject { get; }

        #region InSectorObjects

        int pShipScriptingObjectHashTableObject { get; }
        ScriptTableObject ShipScriptingObjectHashTableObject { get; }

        int pGateScriptingObjectHashTableObject { get; }
        ScriptTableObject GateScriptingObjectHashTableObject { get; }

        #endregion

        int OwnerDataScriptingObjectID { get; }
        ScriptInstance OwnerDataScriptingObject { get; }

    }
}
