using Common.Memory;
using System;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting
{
    public class DynamicValue : MemoryObject, IComparable
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
            pTextObject,
            pObject0xe = 14
        }

        public FlagType Flag;
        public int Value;

        /// <summary>
        /// Returns the HashTable that this value points to
        /// </summary>
        /// <returns></returns>
        public ScriptingHashTableObject GetAsHashTableObject()
        {
            if (Flag != FlagType.pHashTable)
            {
                throw new Exception("Object is not a hash table.");
            }

            ScriptingHashTableObject table = new ScriptingHashTableObject();
            table.SetLocation(m_hProcess, (IntPtr)Value);
            table.ReloadFromMemory();
            return table;
        }

        /// <summary>
        /// Returns the TextObject that this value points to
        /// </summary>
        /// <returns></returns>
        public ScriptingTextObject GetAsTextObject()
        {
            if (Flag != FlagType.pTextObject)
            {
                throw new Exception("Object is not a text object.");
            }

            ScriptingTextObject textObject = new ScriptingTextObject();
            textObject.SetLocation(m_hProcess, (IntPtr)Value);
            textObject.ReloadFromMemory();
            return textObject;
        }

        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append((byte)Flag);
            collection.Append(Value);
            return collection.GetBytes();
        }

        public const int ByteSizeConst = 5;
        public override int ByteSize => ByteSizeConst;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);
            byte temp = 0;
            collection.PopFirst(ref temp);
            Flag = (FlagType)temp;
            collection.PopFirst(ref Value);
        }

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
    }
}
