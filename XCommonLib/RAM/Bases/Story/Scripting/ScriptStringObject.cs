using CommonToolLib.ProcessHooking;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptStringObject : MemoryObject
    {
        public abstract MemoryString Text { get; }
    }
}
