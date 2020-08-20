using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Dock : ScriptMemoryObject, IScriptMemoryObject_Dock
    {
        public const int VariableCount = 53;

        public int SubType => throw new NotImplementedException();

        public StationCargoEntry[] Cargo => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((TC_Dock_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Dock() : base(VariableCount)
        {

        }
    }
}
