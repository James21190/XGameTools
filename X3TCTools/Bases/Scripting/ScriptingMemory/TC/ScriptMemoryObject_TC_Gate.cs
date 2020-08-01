using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Gate : ScriptingMemoryObject, IScriptMemoryObject_Gate
    {
        public int DestSectorX
        {
            get { return GetVariableValue((int)TC_Gate_Variables.Dest_Sector_X); }
        }

        public int DestSectorY
        {
            get { return GetVariableValue((int)TC_Gate_Variables.Dest_Sector_Y); }
        }

        public override string GetVariableName(int index)
        {
            return ((TC_Gate_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Gate() : base()
        {

        }
    }
}
