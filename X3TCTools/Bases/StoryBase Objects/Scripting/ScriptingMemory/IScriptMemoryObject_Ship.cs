using Common.Memory;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Ship : IMemoryObject, IValidateable
    {
        /// <summary>
        /// The object SubType of the ship.
        /// </summary>
        int SubType { get; }
        /// <summary>
        /// The list of cargo the ship contains.
        /// </summary>
        CargoEntry[] CargoEntries { get; }

        /// <summary>
        /// The ScriptingObject ID for the prevous sector's ScriptingObject.
        /// </summary>
        int PreviousSectorScriptingObjectID { get; }
        /// <summary>
        /// The previous sector's ScriptingObject.
        /// </summary>
        ScriptingObject PreviousSectorScriptingObject { get; }

        /// <summary>
        /// The ScriptingObject ID for the current sector's ScriptingObject.
        /// </summary>
        int CurrentSectorScriptingObjectID { get; }
        /// <summary>
        /// The current sector's ScriptingObject.
        /// </summary>
        ScriptingObject CurrentSectorScriptingObject { get; }

        int OwnerDataScriptingObjectID { get; }
        ScriptingObject OwnerDataScriptingObject { get; }

        int pCustomNameArrayObject { get; }

        ScriptingArrayObject CustomNameArrayObject { get; }

        string CustomName { get; }
    }
}
