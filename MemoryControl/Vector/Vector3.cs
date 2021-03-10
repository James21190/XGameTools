using Common.Memory;
using System;
using System.Collections.Generic;


namespace Common.Vector
{
    public struct Vector3 : IMemoryObject
    {
        public int X;
        public int Y;
        public int Z;

        public byte[] GetBytes()
        {
            List<byte> arr = new List<byte>();

            arr.AddRange(BitConverter.GetBytes(X));
            arr.AddRange(BitConverter.GetBytes(Y));
            arr.AddRange(BitConverter.GetBytes(Z));

            return arr.ToArray();
        }

        public void SetData(byte[] Memory)
        {
            X = BitConverter.ToInt32(Memory, 0);
            Y = BitConverter.ToInt32(Memory, 4);
            Z = BitConverter.ToInt32(Memory, 8);
        }

        public int ByteSize => 12;


        public IntPtr pThis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IntPtr hProcess { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {

        }

        public Vector3(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public static bool operator ==(Vector3 V1, Vector3 V2)
        {
            return (
                V1.X == V2.X &&
                V1.Y == V2.Y &&
                V1.Z == V2.Z
                );
        }

        public static bool operator !=(Vector3 V1, Vector3 V2)
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
            return string.Format("{0},{1},{2}", X, Y, Z);
        }

        public void ReloadFromMemory()
        {
            throw new NotImplementedException();
        }
    }
}
