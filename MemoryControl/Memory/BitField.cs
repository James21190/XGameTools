namespace CommonToolLib.Memory
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


        public override byte[] GetBytes()
        {
            return m_Value;
        }

        public override int ByteSize => m_Length;

        public override void SetData(byte[] Memory)
        {
            m_Value = Memory;
        }
    }
}
