using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptInstanceTypeDef : MemoryObject
    {
        public int Class;
        public int MemoryLength;
        public abstract ScriptInstanceTypeDef BaseType { get; }
        public abstract ScriptInstanceFunction[] Functions { get; }
    }
}
