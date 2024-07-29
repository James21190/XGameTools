using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonToolLib.Generics.BinaryObjects
{
    /// <summary>
    /// A byte array that can combine IBinaryObjects and seperate them.
    /// </summary>
    public partial class BinaryObjectConverter : IBinaryObject
    {
        public const int DEFAULT_MAX_OBJECT_SIZE = 0x400;
        private List<byte> _Data;
        public int DataPointer { get; private set; } = 0;
        public int Size => _Data.Count;
        public bool IsAtEnd 
        { 
            get
            {
                return DataPointer >= _Data.Count();
            } 
        }

        #region Constructors
        public BinaryObjectConverter()
        {
            _Data = new List<byte>();
        }

        public BinaryObjectConverter(byte[] data)
        {
            _Data = new List<byte>(data);
        }
        #endregion

        public void Seek(int index)
        {
            DataPointer = index;
        }

        public void Skip(int count)
        {
            DataPointer += count;
        }

        #region IBinaryObject
        public byte[] GetBytes()
        {
            return _Data.ToArray();
        }
        public void SetData(byte[] data, out int bytesConsumed)
        {
            _Data = new List<byte>(data);
            bytesConsumed = data.Length;
        }
        #endregion
    }
}
