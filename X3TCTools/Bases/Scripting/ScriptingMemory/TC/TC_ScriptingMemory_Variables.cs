using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public enum TC_Ship_Variables
    {
        SubType = 12,

        CustomShipName = 16,

        Hull = 18,

        InstalledWeapons = 21,

        InstalledShields = 25,

        CargoItemCountHashTable = 33,

        PilotID = 37,

        AdditionalMaxCargoUnits = 69,
        CurrentCargoUnits,
        MaximumLaserEnergy,
        MaximumShield
    }
}
