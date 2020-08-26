using Common.Memory;
using System;

namespace X3TCTools.Bases.Scripting
{
    public class EventObjectSub : MemoryObject
    {
        public const int ByteSize = 52;

        public int ID;
        public int Unknown_1;
        public IntPtr pSelf;
        public int Unknown_2;
        public int NextID;
        public MemoryObjectPointer<EventObjectSub> pNext = new MemoryObjectPointer<EventObjectSub>();
        public int Unknown_3;
        public int ScriptVariableCount;
        public int Unknown_4;
        public int Unknown_5;
        public int Unknown_6;
        public int Unknown_7;
        public int Unknown_8;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);
            collection.PopFirst(ref ID);
            collection.PopFirst(ref Unknown_1);
            collection.PopFirst(ref pSelf);
            collection.PopFirst(ref Unknown_2);
            collection.PopFirst(ref NextID);
            collection.PopFirst(ref pNext);
            collection.PopFirst(ref Unknown_3);
            collection.PopFirst(ref ScriptVariableCount);
            collection.PopFirst(ref Unknown_4);
            collection.PopFirst(ref Unknown_5);
            collection.PopFirst(ref Unknown_6);
            collection.PopFirst(ref Unknown_7);
            collection.PopFirst(ref Unknown_8);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pNext.SetLocation(hProcess, address + 0x14);
        }
    }
}
