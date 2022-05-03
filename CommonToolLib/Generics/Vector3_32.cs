using CommonToolLib.ProcessHooking;
using System;


namespace CommonToolLib.Generics
{
    public struct Vector3_32 : IMemoryObject
    {
        public int X;
        public int Y;
        public int Z;

        public Vector3_32(int x, int y, int z)
        {
            X = (x);
            Y = (y);
            Z = (z);
            pThis = IntPtr.Zero;
            hProcess = IntPtr.Zero;
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

        #region IMemoryObject
        public IntPtr pThis { get; set; }
        public IntPtr hProcess { get; set; }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pThis = address;
            this.hProcess = hProcess;
        }
        public byte[] GetBytes()
        {
            var collection = new MemoryObjectConverter();

            collection.Append(X);
            collection.Append(Y);
            collection.Append(Z);

            return collection.GetBytes();
        }

        public void SetData(byte[] Memory)
        {
            var collection = new MemoryObjectConverter(Memory);
            X = collection.PopInt();
            Y = collection.PopInt();
            Z = collection.PopInt();
        }
        public void ReloadFromMemory()
        {
            throw new NotImplementedException();
        }

        public int ByteSize => 12;

        #endregion
    }
}
