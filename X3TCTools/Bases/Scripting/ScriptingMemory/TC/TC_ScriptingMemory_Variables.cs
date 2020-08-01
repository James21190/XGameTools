using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public enum TC_Dock_Variables
    {
        Shielding = 19,
        Cargo = 44
    }
    public enum TC_Gate_Variables
    {
        Dest_Sector_X = 8,
        Dest_Sector_Y
    }
    public enum TC_Sector_Variables
    {
        Sector_X,
        Sector_Y,
        UnknownParentEventObjectID,

        ShipHashTable = 3,

        DockHashTable = 6,
        FactoryHashTable,
    }
    public enum TC_Ship_Variables
    {
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID = 1,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        SubType = 12,

        CustomShipName = 16,

        Hull = 18,

        WeaponArray = 21,

        ShieldArray = 25,

        Cargo = 33,

        PilotID = 37,

        AdditionalMaxCargoUnits = 69,
        CurrentCargoUnits,
        MaximumLaserEnergy,
        MaximumShield
    }

    public enum TC_Ware_Variables
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
