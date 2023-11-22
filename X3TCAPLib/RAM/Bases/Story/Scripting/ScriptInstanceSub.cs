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

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            Class = objectByteList.PopInt();
            Unknown_1 = objectByteList.PopInt();
            pSelf = objectByteList.PopIntPtr();
            Unknown_2 = objectByteList.PopInt();
            NextID = objectByteList.PopInt();
            pNext = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceSub>>();
            Unknown_3 = objectByteList.PopInt();
            ScriptVariableCount = objectByteList.PopInt();
            Unknown_4 = objectByteList.PopInt();
            Unknown_5 = objectByteList.PopInt();
            FunctionCount_1 = objectByteList.PopInt();
            pFunctions = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryInt32>>();
            Unknown = objectByteList.PopInt();

            return SetDataResult.Success;
        }
        #endregion
    }
}
