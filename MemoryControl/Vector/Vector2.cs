using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;


namespace Common.Vector
{
    public struct Vector2 : IMemoryObject
    {
        public const int ByteSize = 8;
        public int X;
        public int Y;

        public Vector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static bool operator == (Vector2 V1, Vector2 V2)
        {
            return (
                V1.X == V2.X &&
                V1.Y == V2.Y
                );
        }

        public static bool operator != (Vector2 V1, Vector2 V2)
        {
            return !(V1 == V2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }

        #region IMemoryObject
        public byte[] GetBytes()
        {
            List<byte> arr = new List<byte>();

            arr.AddRange(BitConverter.GetBytes(X));
            arr.AddRange(BitConverter.GetBytes(Y));

            return arr.ToArray();
        }

        public void SetData(byte[] Memory)
        {
            X = BitConverter.ToInt32(Memory, 0);
            Y = BitConverter.ToInt32(Memory, 4);
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }

        public void ReloadFromMemory()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
