using Common.Memory;
using System;

namespace X3Tools.RAM.Generics
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

        public int ByteSize => 4;

        public IntPtr pThis { get; set; }
        public IntPtr hProcess { get; set; }

        public void SetData(byte[] Memory)
        {
            FixedPointValue = BitConverter.ToUInt32(Memory, 0);
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            this.hProcess = hProcess;
            pThis = address;
        }

        public void ReloadFromMemory()
        {
            throw new NotImplementedException();
        }
    }
}
