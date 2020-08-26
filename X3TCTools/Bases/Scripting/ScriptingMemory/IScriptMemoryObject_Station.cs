using Common.Memory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Station : IMemoryObject
    {
        int MainType { get; }
        int SubType { get; }

        /// <summary>
        /// The EventObject ID for the current sector's EventObject.
        /// </summary>
        int CurrentSectorEventObjectID { get; }
        /// <summary>
        /// The current sector's EventObject.
        /// </summary>
        EventObject CurrentSectorEventObject { get; }

        int pCargoHashTable { get; }
        ScriptingHashTableObject CargoHashTable { get; }

        int OwnerDataEventObjectID { get; }
        EventObject OwnerDataEventObject { get; }

        CargoEntry[] CargoEntries { get; }
    }
}
