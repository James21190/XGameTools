using CommonToolLib.Generics;
using CommonToolLib.Generics.BinaryObjects;
using CommonToolLib.ProcessHooking;
using System;
using System.Runtime.CompilerServices;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public struct DynamicValue : IMemoryObject
    {
        public const int FlagCount = 15;
        public enum FlagType
        {
            NULL,
            Int,
            MODValue,

            pX2HashTable = 4,

            pArray = 8,
            pHashTable,
            pScriptingObject,
            pTextObject,
            pObject0xe = 14
        }

        public FlagType Flag;
        public int Value;

        public DynamicValue(FlagType flag = FlagType.NULL, int value = 0)
        {
            Flag = flag;
            Value = value;
            pThis = IntPtr.Zero;
            ParentMemoryBlock = null;
        }

        #region IMemoryObject
        public IntPtr pThis { get; set; }
        public IMemoryBlockManager ParentMemoryBlock { get; set; }
        public byte[] GetBytes()
        {
            MemoryObjectConverter collection = new MemoryObjectConverter();
            collection.Append((byte)Flag);
            collection.Append(Value);
            return collection.GetBytes();
        }

        public const int BYTE_SIZE = 5;
        public int ByteSize => BYTE_SIZE;

        public void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            Flag = (FlagType)memoryObjectConverter.PopByte();
            Value = memoryObjectConverter.PopInt();
        }

        public void ReloadFromMemory(int maxObjectSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE)
        {
            int bytesConsumed;
            SetData(ParentMemoryBlock.ReadBytes(pThis, maxObjectSize), out bytesConsumed);
        }

        public void SetData(byte[] data, out int bytesConsumed)
        {
            var boc = new BinaryObjectConverter(data);
            Flag = (FlagType)boc.PopByte();
            Value = boc.PopInt();
            bytesConsumed = BYTE_SIZE;
        }
        #endregion

        public override string ToString()
        {
            return Flag + "(" + Value.ToString() + ")";
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is DynamicValue))
            {
                throw new Exception("Type missmatch");
            }

            DynamicValue type = (DynamicValue)obj;

            if (Flag > type.Flag)
            {
                return -1;
            }

            if (Flag < type.Flag)
            {
                return 1;
            }

            if (Value > type.Value)
            {
                return -1;
            }

            if (Value < type.Value)
            {
                return 1;
            }

            return 0;
        }

        #region Operators

        public override bool Equals(object obj)
        {
            if (obj is DynamicValue)
            {
                return this == (DynamicValue)obj;
            }
            return false;
        }


        public static bool operator ==(DynamicValue a, DynamicValue b)
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

        public static bool operator !=(DynamicValue a, DynamicValue b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Casting
        public static explicit operator DynamicValue(int v)
        {
            return new DynamicValue(FlagType.Int, v);
        }

        public static explicit operator int (DynamicValue v)
        {
            if (v.Flag != FlagType.Int)
                throw new ArgumentException("Dynamic value is not an int");
            return v.Value;
        }
        #endregion

        #region Default objects

        public static readonly DynamicValue Null = new DynamicValue();
        public static readonly DynamicValue Zero = new DynamicValue(FlagType.Int);

        #endregion
    }
}
