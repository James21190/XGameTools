using CommonToolLib.Memory;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XCommonLib.RAM.Bases.Story
{
    public abstract class StoryBase : MemoryObject
    {
        public abstract MemoryString GetStringFromArray(int index);
        public abstract ScriptInstance GetScriptInstance(int id);
    }
}
