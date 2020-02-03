using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;


namespace Common.Vector
{
    public struct Vector4 : IMemoryObject
    {
        public const int ByteSize = 16;
        public int X;
        public int Y;
        public int Z;
        public int W;

        public byte[] GetBytes()
        {
            List<byte> arr = new List<byte>();

            arr.AddRange(BitConverter.GetBytes(X));
            arr.AddRange(BitConverter.GetBytes(Y));
            arr.AddRange(BitConverter.GetBytes(Z));
            arr.AddRange(BitConverter.GetBytes(W));

            return arr.ToArray();
        }

        public void SetData(byte[] Memory)
        {
            X = BitConverter.ToInt32(Memory, 0);
            Y = BitConverter.ToInt32(Memory, 4);
            Z = BitConverter.ToInt32(Memory, 8);
            W = BitConverter.ToInt32(Memory, 12);
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }

        public Vector4(int X, int Y, int Z, int W)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.W = W;
        }

        public static bool operator == (Vector4 V1, Vector4 V2)
        {
            return (
                V1.X == V2.X &&
                V1.Y == V2.Y &&
                V1.Z == V2.Z &&
                V1.W == V2.W
                );
        }

        public static bool operator != (Vector4 V1, Vector4 V2)
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
            return string.Format("{0},{1},{2},{3}", X, Y, Z, W);
        }
    }
}
