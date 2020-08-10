using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Sector : ScriptMemoryObject, IScriptMemoryObject_Sector
    {
        public int SectorX
        {
            get
            {
                return GetVariableValue((int)TC_Sector_Variables.Sector_X);
            }
        }

        public int SectorY { get
            {
                return GetVariableValue((int)TC_Sector_Variables.Sector_Y);
            } 
        }

        public ScriptMemoryObject_TC_Sector() : base(55)
        {

        }

        public override string GetVariableName(int index)
        {
            return ((TC_Sector_Variables)index).ToString();
        }

    }
}
