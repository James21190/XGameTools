using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Memory
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

        public override int GetByteSize()
        {
            return 8;
        }

        public override void SetData(byte[] Memory)
        {
            Value = BitConverter.ToInt64(Memory, 0);
        }
    }
    /// <summary>
    /// A 32 bit intager that implements IMemoryObject.
    /// </summary>
    public class MemoryInt32 : MemoryObject
    {
        public int Value = 0;
        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

        public override int GetByteSize()
        {
            return 4;
        }

        public override void SetData(byte[] Memory)
        {
            Value = BitConverter.ToInt32(Memory, 0);
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

        public override int GetByteSize()
        {
            return 2;
        }

        public override void SetData(byte[] Memory)
        {
            Value = BitConverter.ToInt16(Memory, 0);
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

        public override int GetByteSize()
        {
            return 1;
        }

        public override void SetData(byte[] Memory)
        {
            Value = Memory[0];
        }
    }
}
