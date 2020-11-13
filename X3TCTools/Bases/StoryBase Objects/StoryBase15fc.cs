using Common.Memory;
using System;
using X3TCTools.Bases.StoryBase_Objects.Scripting;

namespace X3TCTools.Bases.StoryBase_Objects
{
    public class StoryBase15fc : MemoryObject
    {
        public int ID;
        public int Unknown_1;
        public int Unknown_2;
        public int Unknown_3;
        public MemoryObjectPointer<DynamicValue> pDynamicValueArr = new MemoryObjectPointer<DynamicValue>();

        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();

            collection.Append(ID);
            collection.Append(Unknown_1);
            collection.Append(Unknown_2);
            collection.Append(Unknown_3);
            collection.Append(pDynamicValueArr);

            return collection.GetBytes();
        }

        public override int ByteSize => 20;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);

            collection.PopFirst(ref ID);
            collection.PopFirst(ref Unknown_1);
            collection.PopFirst(ref Unknown_2);
            collection.PopFirst(ref Unknown_3);
            collection.PopFirst(ref pDynamicValueArr);
        }
        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pDynamicValueArr.SetLocation(hProcess, address + 20);
        }

        public enum Indeces
        {
            Position_X,
            Position_Y,
            Position_Z,
        }

        public DynamicValue GetValue(Indeces Index)
        {
            return pDynamicValueArr.GetObjectInArray((int)Index);
        }
    }
}
