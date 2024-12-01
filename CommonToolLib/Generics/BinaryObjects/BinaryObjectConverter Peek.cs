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

        public uint PeekUInt()
        {
            return BitConverter.ToUInt32(PeekBytes(4), 0);
        }

        public ulong PeekULong()
        {
            return BitConverter.ToUInt64(PeekBytes(8), 0);
        }
        #endregion

        #region Signed
        public int PeekInt()
        {
            return BitConverter.ToInt32(PeekBytes(4), 0);
        }

        public long PeekLong()
        {
            return BitConverter.ToInt64(PeekBytes(8), 0);
        }
        #endregion
        #endregion

        #region Decimals
        public float PeekFloat()
        {
            return BitConverter.ToSingle(PeekBytes(4), 0);
        }

        public double PeekDouble()
        {
            return BitConverter.ToDouble(PeekBytes(8), 0);
        }

        public decimal PeekDecimal()
        {
            int[] bits = PeekInts(4);
            return new decimal(bits);
        }
        #endregion
        #endregion

        #region Arrays
        #region Integers
        #region Unsigned
        public byte[] PeekBytes(int count)
        {
            if (_Data.Count() - DataPointer <= 0)
            {
                throw new IndexOutOfRangeException("Unable to peek bytes as the end of the data has been reached.");
            }
            byte[] result = _Data.Skip(DataPointer).Take(count).ToArray();
            return result;
        }

        public uint[] PeekUInts(int count)
        {
            const int SIZE = 4;
            var arr = PeekBytes(SIZE * count);
            var result = new uint[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToUInt32(arr, SIZE * i);
            }
            return result;
        }

        public ulong[] PeekULongs(int count)
        {
            const int SIZE = 8;
            var arr = PeekBytes(SIZE * count);
            var result = new ulong[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToUInt64(arr, SIZE * i);
            }
            return result;
        }
        #endregion

        #region Signed
        public int[] PeekInts(int count)
        {
            const int SIZE = 4;
            var arr = PeekBytes(SIZE * count);
            var result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToInt32(arr, SIZE * i);
            }
            return result;
        }
        public long[] PeekLongs(int count)
        {
            const int SIZE = 8;
            var arr = PeekBytes(SIZE * count);
            var result = new long[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToInt64(arr, SIZE * i);
            }
            return result;
        }
        #endregion
        #endregion

        #region Decimals
        public decimal[] PeekDecimals(int count)
        {
            const int SIZE = 16;
            var result = new decimal[count];
            byte[] arr;
            for (int i = 0; i < count; i++)
            {
                arr = PeekBytes(SIZE * count);
                int[] bits = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    bits[j] = BitConverter.ToInt32(arr, i * SIZE + 4 * j);
                }
                result[i] = new decimal(bits);
            }
            return result;
        }

        public float[] PeekFloats(int count)
        {
            const int SIZE = 4;
            var arr = PeekBytes(SIZE * count);
            var result = new float[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToSingle(arr, SIZE * i);
            }
            return result;
        }

        public double[] PeekDoubles(int count)
        {
            const int SIZE = 8;
            var arr = PeekBytes(SIZE * count);
            var result = new double[count]; for (int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToDouble(arr, SIZE * i);
            }
            return result;
        }
        #endregion
        #endregion
    }
}
