using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Dock : ScriptMemoryObject, IScriptMemoryObject_Dock
    {
        public const int VariableCount = 53;
        public override string GetVariableName(int index)
        {
            return ((AP_Dock_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Dock() : base(VariableCount)
        {

        }
    }
}
