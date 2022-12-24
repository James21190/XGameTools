using CommonToolLib.ProcessHooking;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptTaskObject : MemoryObject
    {
        #region Memory
        public abstract int ID { get; set; }
        public abstract int StackSize { get; set; }
        public abstract DynamicValue[] Stack { get; } 
        public abstract int InstructionIndex { get; set; }
        #endregion
    }
}
