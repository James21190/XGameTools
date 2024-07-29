using CommonToolLib.ProcessHooking;
using System;
using CommonToolLib.Generics.BinaryObjects;


namespace CommonToolLib.Generics
{
    public struct Vector2_32 : IBinaryObject
    {
        public int X;
        public int Y;

        public Vector2_32(int x, int y)
        {
            X = (x);
            Y = (y);
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

        #region IBinaryObject
        public byte[] GetBytes()
        {
            var collection = new MemoryObjectConverter();

            collection.Append(X);
            collection.Append(Y);

            return collection.GetBytes();
        }

        void IBinaryObject.SetData(byte[] data, out int bytesConsumed)
        {
            var collection = new MemoryObjectConverter(data);
            X = collection.PopInt();
            Y = collection.PopInt();
            bytesConsumed = BYTE_SIZE;
        }

        public const int BYTE_SIZE = 8;

        #endregion
    }
}
