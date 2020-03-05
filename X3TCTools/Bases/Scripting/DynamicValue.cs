using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases.Scripting
{
    public class DynamicValue : MemoryObject
    {
        public const int FlagCount = 15;
        public enum FlagType
        {
            NULL,
            Int,
            MODValue,
            pArray = 8,
            pHashTable,
            pEventObject,
            pTextObject
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

        public override string ToString()
        {
            return Flag + "-" + (int)Flag + "-" + Value.ToString("X");
        }

        public void FromString(string str)
        {
            var split = str.Split('-');
            Flag = (FlagType)int.Parse(split[1]);
            Value = int.Parse(split[2]);

        }

        public static bool operator==(DynamicValue a, DynamicValue b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            else if (object.ReferenceEquals(b, null))
            {
                return object.ReferenceEquals(a, null);
            }

            return (a.Flag == b.Flag && a.Value == b.Value);
        }

        public static bool operator!=(DynamicValue a, DynamicValue b)
        {
            return !(a == b);
        }
    }
}
