using System;

namespace CommonToolLib.ProcessHooking
{
    public class BitField : MemoryObject
    {
        private byte[] m_Value;
        private int m_Length;

        public BitField()
        {
            m_Length = 4;
            m_Value = new byte[4];
        }

        public BitField(int length)
        {
            m_Length = length;
            m_Value = new byte[length];
        }

        public bool GetBit(int index)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;
            byte mask = (byte)(0x01 << bitIndex);
            return (m_Value[byteIndex] & mask) != 0;
        }

        public void SetBit(int index, bool value)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;
            byte mask = (byte)(0x01 << bitIndex);
            if (value)
            {
                m_Value[byteIndex] = (byte)(m_Value[byteIndex] | mask);
            }
            else
            {
                m_Value[byteIndex] = (byte)(m_Value[byteIndex] & ~mask);
            }
        }

        public int CountOnes()
        {

            int count = 0;
            for(int b = 0; b < m_Length; b++)
            {
                var bite = m_Value[b];
                // Could make a lookup table for this, but effort.
                for(int i = 0; i < 8; i++)
                {
                    if((bite & (0b1 << i)) != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public override int ByteSize => m_Length;

        public override byte[] GetBytes()
        {
            return m_Value;
        }

        public override void SetData(byte[] data, out int bytesConsumed)
        {
            Array.Copy(data, m_Value, m_Length);
            m_Value = data;
            bytesConsumed = m_Length;
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new System.NotSupportedException();
        }
    }
}
