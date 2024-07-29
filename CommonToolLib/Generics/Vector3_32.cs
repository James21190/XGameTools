using CommonToolLib.ProcessHooking;
using CommonToolLib.Generics.BinaryObjects;
using System;


namespace CommonToolLib.Generics
{
    public struct Vector3_32 : IBinaryObject
    {
        public int X;
        public int Y;
        public int Z;

        public Vector3_32(int x, int y, int z)
        {
            X = (x);
            Y = (y);
            Z = (z);
        }

        public static Vector3_32 operator *(Vector3_32 a, int b)
        {
            a.X *= b;
            a.Y *= b;
            a.Z *= b;
            return a;
        }

        public static Vector3_32 operator *(Vector3_32 a, double b)
        {
            a.X = (int)((double)a.X * b);
            a.Y = (int)((double)a.Y * b);
            a.Z = (int)((double)a.Z * b);
            return a;
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

        #region IBinaryObject

        public byte[] GetBytes()
        {
            var collection = new MemoryObjectConverter();

            collection.Append(X);
            collection.Append(Y);
            collection.Append(Z);

            return collection.GetBytes();
        }

        void IBinaryObject.SetData(byte[] data, out int bytesConsumed)
        {
            var collection = new MemoryObjectConverter(data);
            X = collection.PopInt();
            Y = collection.PopInt();
            Z = collection.PopInt();
            bytesConsumed = BYTE_SIZE;
        }

        public const int BYTE_SIZE = 12;

        #endregion
    }
}
