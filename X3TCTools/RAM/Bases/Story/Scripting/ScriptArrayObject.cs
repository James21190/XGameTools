using CommonToolLib.Memory;
using System;

namespace X3Tools.RAM.Bases.Story.Scripting
{
    public class ScriptArrayObject : MemoryObject
    {
        public int ID;
        public int Unknown_1;
        public int Length;
        public int Count;
        public MemoryObjectPointer<DynamicValue> pDynamicValueArr = new MemoryObjectPointer<DynamicValue>();

        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();

            collection.Append(ID);
            collection.Append(Unknown_1);
            collection.Append(Length);
            collection.Append(Count);
            collection.Append(pDynamicValueArr);

            return collection.GetBytes();
        }

        public override int ByteSize => 20;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);

            ID = collection.PopInt();
            Unknown_1 = collection.PopInt();
            Length  = collection.PopInt();
            Count = collection.PopInt();
            pDynamicValueArr = collection.PopIMemoryObject<MemoryObjectPointer<DynamicValue>>();
        }
        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pDynamicValueArr.SetLocation(hProcess, address + 20);
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
