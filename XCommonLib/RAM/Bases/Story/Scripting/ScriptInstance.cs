using CommonToolLib.Memory;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptInstance : MemoryObject
    {
        public abstract int NegativeID { get; set; }
        public abstract int ReferenceCount { get; set; }

        public int ID => -NegativeID - 1;
    }
}
