using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.Story.Scripting;
using XCommonLib.RAM.Generics;

namespace XCommonLib.RAM.Bases.Story
{
    public abstract class StoryBase : MemoryObject
    {
        public abstract MemoryObjectPointer<MemoryString> pStrings { get; }

        public MemoryString GetStringFromArray(int index)
        {
            var ms = new MemoryString();
            ms.SetLocation(hProcess, pStrings.address + index);
            ms.ReloadFromMemory();
            return ms;
        }

        public abstract ScriptInstance GetScriptInstance(int id);
    }
}
