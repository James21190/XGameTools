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
        /// The EventObject ID for the prevous sector's EventObject.
        /// </summary>
        int PreviousSectorEventObjectID { get; }
        /// <summary>
        /// The previous sector's EventObject.
        /// </summary>
        ScriptingObject PreviousSectorEventObject { get; }

        /// <summary>
        /// The EventObject ID for the current sector's EventObject.
        /// </summary>
        int CurrentSectorEventObjectID { get; }
        /// <summary>
        /// The current sector's EventObject.
        /// </summary>
        ScriptingObject CurrentSectorEventObject { get; }

        int OwnerDataEventObjectID { get; }
        ScriptingObject OwnerDataEventObject { get; }
    }
}
