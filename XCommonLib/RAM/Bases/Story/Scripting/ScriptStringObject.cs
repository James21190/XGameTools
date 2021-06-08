using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptStringObject : MemoryObject
    {
        public abstract MemoryString Text { get; }
    }
}
