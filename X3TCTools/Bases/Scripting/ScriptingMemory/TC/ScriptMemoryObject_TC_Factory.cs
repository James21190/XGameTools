using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Factory : ScriptMemoryObject, IScriptMemoryObject_Factory
    {
        public const int VariableCount = 70;


        public int SubType => throw new NotImplementedException();

        public StationCargoEntry[] Cargo => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((TC_Factory_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Factory() : base(VariableCount)
        {

        }
    }
}
