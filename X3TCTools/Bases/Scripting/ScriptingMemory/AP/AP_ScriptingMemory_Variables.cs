using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public enum AP_Dock_Variables
    {
        Shielding = 19,
        Cargo = 44
    }
    public enum AP_Gate_Variables
    {
        Dest_Sector_X = 8,
        Dest_Sector_Y
    }
    public enum AP_Sector_Variables
    {
        Sector_X,
        Sector_Y,
        UnknownParentEventObjectID,

        ShipHashTable = 3,

        DockHashTable = 6,
        FactoryHashTable,
    }
    public enum AP_Ship_Variables
    {
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID = 1,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        SubType = 14,

        CustomShipName = 18,

        WeaponArray = 23,

        ShieldArray = 27,

        Cargo = 35
    }

    public enum AP_Factory_Variables
    {
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID = 1,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        SubType = 13,
    }

    public enum AP_Ware_Variables
    {
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID = 1,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        Amount = 6,
        MainType,
        SubType
    }
}
