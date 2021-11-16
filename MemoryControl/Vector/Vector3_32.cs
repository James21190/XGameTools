using CommonToolLib.Memory;
using System;
using System.Collections.Generic;


namespace CommonToolLib.Vector
{
    public struct Vector3_32 : IMemoryObject
    {
        public int X;
        public int Y;
        public int Z;

        public Vector3_32(int x, int y, int z)
        {
            this.X = (x);
            this.Y = (y);
            this.Z = (z);
            pThis = IntPtr.Zero;
            hProcess = IntPtr.Zero;
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
            this.pThis = address;
            this.hProcess = hProcess;
        }
        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(X);
            collection.Append(Y);
            collection.Append(Z);

            return collection.GetBytes();
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);
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
