using Common.Memory;
using System;

namespace X3TCTools.Generics
{
    public struct X3FixedPointValue : IMemoryObject
    {
        private decimal m_value;

        public uint FixedPointValue
        {
            get => Convert.ToUInt32(m_value * FixedPointUnit);
            set => m_value = value / FixedPointUnit;
        }

        public decimal Value
        {
            get => m_value;
            set => m_value = value;
        }

        public static decimal ConvertFromInt(int value)
        {
            return value / FixedPointUnit;
        }

        public static int ConvertToInt(decimal value)
        {
            return Convert.ToInt32(value * FixedPointUnit);
        }

        public const uint FixedPointUnit = 0x00010000;
        public byte[] GetBytes()
        {
            return BitConverter.GetBytes(FixedPointValue);
        }

        public int GetByteSize()
        {
            return 4;
        }

        public void SetData(byte[] Memory)
        {
            FixedPointValue = BitConverter.ToUInt32(Memory, 0);
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }

        public void ReloadFromMemory()
        {
            throw new NotImplementedException();
        }
    }
}
