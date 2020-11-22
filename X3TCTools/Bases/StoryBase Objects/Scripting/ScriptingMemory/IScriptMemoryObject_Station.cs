using Common.Memory;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
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
        ScriptingObject CurrentSectorEventObject { get; }

        int pCargoHashTable { get; }
        ScriptingHashTableObject CargoHashTable { get; }

        int OwnerDataEventObjectID { get; }
        ScriptingObject OwnerDataEventObject { get; }

        CargoEntry[] CargoEntries { get; }
    }
}
