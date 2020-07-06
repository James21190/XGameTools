using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemoryObject
{
    public class SectorObject_Ship_ScriptMemoryObject : ScriptingMemoryObject
    {
        
        public SectorObject_Ship_ScriptMemoryObject()
        {
            VariableCount = 73;
        }
        
        public enum VariableName
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

        public override string GetVariableName(int index)
        {
            return ((VariableName)index).ToString();
        }

    }
}
