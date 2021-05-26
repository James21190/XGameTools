using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolLib;
using CommonToolLib.Vector;
using CommonToolLib.Memory;


namespace X2Tools.X2.SectorObjects
{
    public class SectorObjectData : MemoryObject
    {
        public const int ByteSize = 488;
        public Vector3 Position;
        public RotationMatrix_3 RotationMatrix;
        public Vector3 PositionDelta;

        // Temporary until all variables are mapped
        private byte[] m_Memory;

        public override byte[] GetBytes()
        {
            Array.Copy(Position.GetBytes(), 0, m_Memory, 40, 12);
            Array.Copy(RotationMatrix.GetBytes(), 0, m_Memory, 52, 36);
            Array.Copy(PositionDelta.GetBytes(), 0, m_Memory, 176, 12);
            return m_Memory;
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            m_Memory = Memory;
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);

            Position = collection.PopIMemoryObject<Vector3>(40);
            RotationMatrix = collection.PopIMemoryObject<RotationMatrix_3>(52);
            PositionDelta = collection.PopIMemoryObject<Vector3>(176);
        }
    }
}
