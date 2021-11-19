﻿using CommonToolLib.ProcessHooking;
using System;

namespace XCommonLib.RAM.Bases.Story.Scripting
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
            pScriptingObject,
            pTextObject,
            pObject0xe = 14
        }

        public FlagType Flag;
        public int Value;

        #region MemoryObject
        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append((byte)Flag);
            collection.Append(Value);
            return collection.GetBytes();
        }

        public const int ByteSizeConst = 5;
        public override int ByteSize => ByteSizeConst;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            Flag = (FlagType)objectByteList.PopByte();
            Value = objectByteList.PopInt();
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
    }
}