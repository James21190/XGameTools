using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_SectorData : ScriptMemoryObject
    {
        public const int VariableCount = 9;
        public override string GetVariableName(int index)
        {
            return ((TC_SectorData_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_SectorData() : base(VariableCount)
        {

        }
    }
}
