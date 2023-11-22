using CommonToolLib.ProcessHooking;
using System;


namespace CommonToolLib.Generics
{
    public struct Vector2_32 : IMemoryObject
    {
        public int X;
        public int Y;

        public Vector2_32(int x, int y)
        {
            X = (x);
            Y = (y);
            pThis = IntPtr.Zero;
            ParentMemoryBlock = null;
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
        public IntPtr pThis { get; set; }
        public IMemoryBlockManager ParentMemoryBlock { get; set; }

        public byte[] GetBytes()
        {
            var collection = new MemoryObjectConverter();

            collection.Append(X);
            collection.Append(Y);

            return collection.GetBytes();
        }

        public SetDataResult SetData(byte[] Memory)
        {
            var collection = new MemoryObjectConverter(Memory);
            X = collection.PopInt();
            Y = collection.PopInt();
            return SetDataResult.Success;
        }
        public void ReloadFromMemory()
        {
            throw new NotImplementedException();
        }

        public int ByteSize => 8;

        #endregion
    }
}
