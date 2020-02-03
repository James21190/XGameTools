using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases
{
    public class DynamicValue : MemoryObject
    {

        public enum FlagType
        {
            NULL,
            Int,
            MODValue,
            pStoryBase_15fc_Object = 8,
            pStoryBase_1600_Object,
            pEventObject,
            pTextObject,
            Pointer = 14

        }

        public const int ByteSize = 5;

        public FlagType Flag;
        public int Value;

        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append((byte)Flag);
            collection.Append(Value);
            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);
            byte temp = 0;
            collection.PopFirst(ref temp);
            Flag = (FlagType)temp;
            collection.PopFirst(ref Value);
        }
    }
}
