using Common.Memory;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Station : IMemoryObject
    {
        int MainType { get; }
        int SubType { get; }

        /// <summary>
        /// The ScriptingObject ID for the current sector's ScriptingObject.
        /// </summary>
        int CurrentSectorScriptingObjectID { get; }
        /// <summary>
        /// The current sector's ScriptingObject.
        /// </summary>
        ScriptInstance CurrentSectorScriptingObject { get; }

        int pCargoHashTable { get; }
        ScriptTableObject CargoHashTable { get; }

        int OwnerDataScriptingObjectID { get; }
        ScriptInstance OwnerDataScriptingObject { get; }

        CargoEntry[] CargoEntries { get; }
    }
}
