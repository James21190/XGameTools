using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_PositionData_12 : ScriptMemoryObject
    {
        public override string GetVariableName(int index)
        {
            return ((AP_PositionData_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_PositionData_12() : base(12)
        {

        }
    }
}
