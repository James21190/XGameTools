using CommonToolLib.ProcessHooking;
using CommonToolLib.Generics.BinaryObjects;
using System;


namespace CommonToolLib.Generics
{
    public struct Vector4_32 : IBinaryObject
    {
        public int X;
        public int Y;
        public int Z;
        public int W;

        public Vector4_32(int x, int y, int z, int w)
        {
            X = (x);
            Y = (y);
            Z = (z);
            W = (w);
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

        #region IBinaryObject
        public byte[] GetBytes()
        {
            var collection = new MemoryObjectConverter();

            collection.Append(X);
            collection.Append(Y);
            collection.Append(Z);
            collection.Append(W);

            return collection.GetBytes();
        }

        void IBinaryObject.SetData(byte[] data, out int bytesConsumed)
        {
            var collection = new MemoryObjectConverter(data);
            X = collection.PopInt();
            Y = collection.PopInt();
            Z = collection.PopInt();
            W = collection.PopInt();
            bytesConsumed = BYTE_SIZE;
        }

        public const int BYTE_SIZE = 16;

        #endregion
    }
}
