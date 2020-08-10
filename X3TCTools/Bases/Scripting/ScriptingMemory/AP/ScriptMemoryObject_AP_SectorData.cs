using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_SectorData : ScriptMemoryObject
    {
        public const int VariableCount = 9;
        public override string GetVariableName(int index)
        {
            return ((AP_SectorData_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_SectorData() : base(VariableCount)
        {

        }
    }
}
