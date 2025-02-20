using System;
using System.Linq;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// A 64 bit intager that implements IBinaryObject.
    /// </summary>
    public class MemoryInt64 : MemoryObject
    {
        public long Value = 0;
        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

        public const int BYTE_SIZE = 8;
        public override int ByteSize => BYTE_SIZE;

        public override void SetData(byte[] data, out int bytesConsumed)
        {
            Value = BitConverter.ToInt64(data, 0);
            bytesConsumed = BYTE_SIZE;
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }
    /// <summary>
    /// A 32 bit intager that implements IBinaryObject.
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

        public const int BYTE_SIZE = 4;
        public override int ByteSize => BYTE_SIZE;
        public override void SetData(byte[] data, out int bytesConsumed)
        {
            Value = BitConverter.ToInt32(data, 0);
            bytesConsumed = BYTE_SIZE;

        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }

    /// <summary>
    /// A 16 bit intager that implements IBinaryObject.
    /// </summary>
    public class MemoryInt16 : MemoryObject
    {
        public short Value = 0;
        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

        public const int BYTE_SIZE = 2;
        public override int ByteSize => BYTE_SIZE;

        public override void SetData(byte[] data, out int bytesConsumed)
        {
            Value = BitConverter.ToInt16(data, 0);
            bytesConsumed = BYTE_SIZE;
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }

    /// <summary>
    /// A 8 bit intager that implements IBinaryObject.
    /// </summary>
    public class MemoryByte : MemoryObject
    {
        public byte Value = 0;

        public override byte[] GetBytes()
        {
            return new byte[] { Value };
        }

        public const int BYTE_SIZE = 1;
        public override int ByteSize => BYTE_SIZE;
        public override void SetData(byte[] data, out int bytesConsumed)
        {
            Value = data[0];
            bytesConsumed = BYTE_SIZE;
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
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

        public override int ByteSize => Value != null ? Value.Length : 100;

        public override void SetData(byte[] data, out int bytesConsumed)
        {
            Value = "";
            MemoryObjectConverter collection = new MemoryObjectConverter(data);
            char character = (char)collection.PopByte();
            while (character != 0 && !collection.IsAtEnd)
            {
                Value += character;
                character = (char)collection.PopByte();
            }
            bytesConsumed = Value.Length + 1;
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }
}
