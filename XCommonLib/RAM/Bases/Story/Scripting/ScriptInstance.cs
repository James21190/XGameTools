using CommonToolLib.Memory;
using XCommonLib.RAM.Generics;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptInstance : MemoryObject, INumericIDObject
    {
        public abstract int NegativeID { get; set; }
        public abstract int ReferenceCount { get; set; }

        public int ID => -NegativeID - 1;
    }
}
