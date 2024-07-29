using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Generics.BinaryObjects
{
    public partial class BinaryObjectConverter
    {
        #region Single

        #region Integers
        #region Unsigned
        public byte PeekByte()
        {
            return _Data[DataPointer];
        }
        public ushort PeekUShort()
        {
            return BitConverter.ToUInt16(PeekBytes(2), 0);
        }
        #endregion
        #region Signed
        public short PeekShort()
        {
            return BitConverter.ToInt16(PeekBytes(2), 0);
        }
        #endregion
        #endregion

        #region Decimals
        #endregion

        #region Text
        #endregion

        #endregion

        #region Arrays

        #region Integers
        #region Unsigned
        public byte[] PeekBytes(int count)
        {
            if(_Data.Count() - DataPointer <= 0)
            {
                throw new IndexOutOfRangeException("Unable to peek bytes as the end of the data has been reached.");
            }
            byte[] result = _Data.Skip(DataPointer).Take(count).ToArray();
            return result;
        }
        public ushort[] PeekUShorts(int count)
        {
            const int SIZE = 2;
            var arr = PeekBytes(SIZE * count);
            var result = new ushort[count];
            for(int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToUInt16(arr, SIZE * i);
            }
            return result;
        }
        #endregion
        #region Signed
        public short[] PeekShorts(int count)
        {
            const int SIZE = 2;
            var arr = PeekBytes(SIZE * count);
            var result = new short[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToInt16(arr, SIZE * i);
            }
            return result;
        }
        #endregion
        #endregion

        #region Decimals
        #endregion

        #region Text
        #endregion

        #endregion

    }
}
