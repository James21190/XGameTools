﻿using System;
using System.Linq;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// A 64 bit intager that implements IMemoryObject.
    /// </summary>
    public class MemoryInt64 : MemoryObject
    {
        public long Value = 0;
        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

        public override int ByteSize => 8;

        public override SetDataResult SetData(byte[] Memory)
        {
            Value = BitConverter.ToInt64(Memory, 0);
            return SetDataResult.Success;
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }
    /// <summary>
    /// A 32 bit intager that implements IMemoryObject.
    /// </summary>
    public class MemoryInt32 : MemoryObject
    {
        public int Value = 0;

        public MemoryInt32()
        {

        }

        public MemoryInt32(int value)
        {
            Value = value;
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

        public override int ByteSize => 4;

        public override SetDataResult SetData(byte[] Memory)
        {
            Value = BitConverter.ToInt32(Memory, 0);
            return SetDataResult.Success;
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }

    /// <summary>
    /// A 16 bit intager that implements IMemoryObject.
    /// </summary>
    public class MemoryInt16 : MemoryObject
    {
        public short Value = 0;
        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

        public override int ByteSize => 2;

        public override SetDataResult SetData(byte[] Memory)
        {
            Value = BitConverter.ToInt16(Memory, 0);
            return SetDataResult.Success;
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }

    /// <summary>
    /// A 8 bit intager that implements IMemoryObject.
    /// </summary>
    public class MemoryByte : MemoryObject
    {
        public byte Value = 0;

        public override byte[] GetBytes()
        {
            return new byte[] { Value };
        }

        public override int ByteSize => 1;

        public override SetDataResult SetData(byte[] Memory)
        {
            Value = Memory[0];
            return SetDataResult.Success;
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }

    public class MemoryString : MemoryObject
    {
        public string Value;

        public override byte[] GetBytes()
        {
            byte[] bytes = new byte[Value.Length + 1];
            for (int i = 0; i < Value.Length; i++)
            {
                bytes[i] = (byte)Value.ToArray()[i];
            }
            bytes[Value.Length] = 0;
            MemoryObjectConverter collection = new MemoryObjectConverter();
            collection.Append(bytes);
            return collection.GetBytes();
        }

        public override int ByteSize => Value == null ? 100 : Value.Length + 1;

        public override SetDataResult SetData(byte[] Memory)
        {
            Value = "";
            MemoryObjectConverter collection = new MemoryObjectConverter(Memory);
            char character = (char)collection.PopByte();
            while (character != 0)
            {
                Value += character;
                character = (char)collection.PopByte();
            }
            return SetDataResult.Success;
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }
}
