using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemoryObject
{
    public class BlankScriptingMemoryObject : ScriptingMemoryObject
    {
        public BlankScriptingMemoryObject(int length)
        {
            VariableCount = length;
        }
    }
}
