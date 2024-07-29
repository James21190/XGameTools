using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstanceSub : MemoryObject
    {
        #region Memory
        public int Class { get; set; }
        public int Unknown_1 { get; set; }
        public IntPtr pSelf { get; set; }
        public int Unknown_2 { get; set; }
        public MemoryObjectPointer<ScriptInstanceSub> pNext;
        public int NextID { get; set; }
        public int Unknown_3 { get; set; }
        public int ScriptVariableCount { get; set; }
        public int Unknown_4 { get; set; }
        public int Unknown_5 { get; set; }
        public int FunctionCount_1 { get; set; }
        public MemoryObjectPointer<MemoryInt32> pFunctions;
        public int Unknown { get; set; }
        #endregion

        #region MemoryObject
        public override int ByteSize => 52;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            Class = memoryObjectConverter.PopInt();
            Unknown_1 = memoryObjectConverter.PopInt();
            pSelf = memoryObjectConverter.PopIntPtr();
            Unknown_2 = memoryObjectConverter.PopInt();
            NextID = memoryObjectConverter.PopInt();
            pNext = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceSub>>();
            Unknown_3 = memoryObjectConverter.PopInt();
            ScriptVariableCount = memoryObjectConverter.PopInt();
            Unknown_4 = memoryObjectConverter.PopInt();
            Unknown_5 = memoryObjectConverter.PopInt();
            FunctionCount_1 = memoryObjectConverter.PopInt();
            pFunctions = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<MemoryInt32>>();
            Unknown = memoryObjectConverter.PopInt();
        }
        #endregion
    }
}
