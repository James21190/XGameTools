using CommonToolLib.Memory;
using System;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3Tools.RAM.Bases.Story.Scripting
{
    public class ScriptInstanceSub : MemoryObject
    {
        public int Class;
        public int Unknown_1;
        public IntPtr pSelf;
        public int Unknown_2;
        public int NextID;
        public MemoryObjectPointer<ScriptInstanceSub> pNext = new MemoryObjectPointer<ScriptInstanceSub>();
        public int Unknown_3;
        public int ScriptVariableCount;
        public int Unknown_4;
        public int Unknown_5;
        public int FunctionCount_1;
        public MemoryObjectPointer<ScriptInstanceSubFunction> pFunctions = new MemoryObjectPointer<ScriptInstanceSubFunction>();
        public int Unknown;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 52;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);
            collection.PopFirst(ref Class);
            collection.PopFirst(ref Unknown_1);
            collection.PopFirst(ref pSelf);
            collection.PopFirst(ref Unknown_2);
            collection.PopFirst(ref NextID);
            collection.PopFirst(ref pNext);
            collection.PopFirst(ref Unknown_3);
            collection.PopFirst(ref ScriptVariableCount);
            collection.PopFirst(ref Unknown_4);
            collection.PopFirst(ref Unknown_5);
            collection.PopFirst(ref FunctionCount_1);
            collection.PopFirst(ref pFunctions);
            collection.PopFirst(ref Unknown);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pNext.SetLocation(hProcess, address + 0x14);

            pFunctions.SetLocation(hProcess, address + 0x2c);
        }
    }
}
