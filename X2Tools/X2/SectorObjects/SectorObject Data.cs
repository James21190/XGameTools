using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Vector;
using Common.Memory;


namespace X2Tools.X2.SectorObjects
{
    public partial class SectorObject
    {
        public Data GetData()
        {
            return new Data(MemoryControl.Read(m_GameHook.hProcess, pData, Data.ByteSize));
        }
        public class Data
        {
            public const int ByteSize = 488;
            public Vector3 Position;
            public RotationMatrix_3 RotationMatrix;
            public Vector3 PositionDelta;

            // Temporary until all variables are mapped
            private byte[] m_Memory;

            public Data(byte[] Memory)
            {
                m_Memory = Memory;
                Position = new Vector3(BitConverter.ToInt32(Memory, 40), BitConverter.ToInt32(Memory, 44), BitConverter.ToInt32(Memory, 48));
                RotationMatrix = new RotationMatrix_3(Memory.Skip(52).Take(36).ToArray());
                PositionDelta = new Vector3(BitConverter.ToInt32(Memory, 176), BitConverter.ToInt32(Memory, 180), BitConverter.ToInt32(Memory, 184));
            }

            public byte[] GetBytes()
            {
                Array.Copy(Position.GetBytes(), 0, m_Memory, 40, 12);
                Array.Copy(RotationMatrix.GetBytes(), 0, m_Memory, 52, 36);
                Array.Copy(PositionDelta.GetBytes(), 0, m_Memory, 176, 12);
                return m_Memory;
            }
        }
    }
}
