using CommonToolLib.ProcessHooking;
using XCommonLib.RAM.Generics;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptInstance : MemoryObject, INumericIDObject
    {
        #region Memory
        public abstract int NegativeID { get; set; }
        public abstract int ReferenceCount { get; set; }
        public abstract ScriptInstanceSub Sub { get; }
        public abstract MemoryObjectPointer<DynamicValue> pScriptVariableArr { get; set; }
        #endregion

        public int ID => -NegativeID - 1;
    }
}
