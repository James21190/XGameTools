using Common.Memory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
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
        EventObject PreviousSectorEventObject { get; }

        /// <summary>
        /// The EventObject ID for the current sector's EventObject.
        /// </summary>
        int CurrentSectorEventObjectID { get; }
        /// <summary>
        /// The current sector's EventObject.
        /// </summary>
        EventObject CurrentSectorEventObject { get; }

        int OwnerDataEventObjectID { get; }
        EventObject OwnerDataEventObject { get; }
    }
}
