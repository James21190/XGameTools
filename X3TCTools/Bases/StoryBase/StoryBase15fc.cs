using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases
{
    public class StoryBase15fc : MemoryObject
    {
        public const int ByteSize = 20;

        public int ID;
        public int Unknown_1;
        public int Unknown_2;
        public int Unknown_3;
        public MemoryObjectPointer<DynamicValue> pDynamicValueArr = new MemoryObjectPointer<DynamicValue>();

        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(ID);
            collection.Append(Unknown_1);
            collection.Append(Unknown_2);
            collection.Append(Unknown_3);
            collection.Append(pDynamicValueArr);

            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);

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
