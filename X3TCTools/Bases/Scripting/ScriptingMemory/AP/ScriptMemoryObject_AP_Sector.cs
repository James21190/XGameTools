using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Sector : ScriptMemoryObject, IScriptMemoryObject_Sector
    {
        public int SectorX
        {
            get
            {
                return GetVariableValue((int)AP_Sector_Variables.Sector_X);
            }
        }

        public int SectorY { get
            {
                return GetVariableValue((int)AP_Sector_Variables.Sector_Y);
            } 
        }

        public ScriptMemoryObject_AP_Sector() : base(56)
        {

        }

        public override string GetVariableName(int index)
        {
            return ((AP_Sector_Variables)index).ToString();
        }

    }
}
