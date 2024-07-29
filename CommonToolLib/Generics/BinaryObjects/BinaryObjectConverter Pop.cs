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
        public byte PopByte()
        {
            return _Data[DataPointer++];
        }
        public ushort PopUShort()
        {
            return (ushort)PopShort();
        }
        public uint PopUInt()
        {
            return (uint)PopInt();
        }
        public IntPtr PopIntPtr()
        {
            return (IntPtr)PopInt();
        }
        public ulong PopULong()
        {
            return (ulong)PopLong();
        }

        #endregion

        #region Signed
        public short PopShort()
        {
            return BitConverter.ToInt16(PopBytes(2), 0);
        }
        public short PopShortReversed()
        {
            return BitConverter.ToInt16(PopBytesReversed(2), 0);
        }
        public int PopInt()
        {
            return BitConverter.ToInt32(PopBytes(4), 0);
        }
        public long PopLong()
        {
            return BitConverter.ToInt64(PopBytes(8), 0);
        }
        #endregion

        #endregion

        #region Decimals
        public double PopDouble()
        {
            return (BitConverter.ToDouble(PopBytes(8), 0));
        }
        public decimal PopDecimal()
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.decimal.getbits?view=net-8.0
            int[] parts = PopInts(4);
            bool sign = (parts[3] & 0x80000000) != 0;

            byte scale = (byte)((parts[3] >> 16) & 0x7F);
            decimal newValue = new decimal(parts[0], parts[1], parts[2], sign, scale);
            return newValue;
        }
        #endregion

        #region Text
        public string PopFixedLengthString(int length)
        {
            List<byte> bytes = new List<byte>();
            int i;
            for (i = 0; i < length; i++)
            {
                var readByte = PopByte();
                if (readByte == 0)
                {
                    DataPointer += (length - i - 1);
                    break;
                }
                bytes.Add(readByte);

            }
            return Encoding.Default.GetString(bytes.ToArray());
        }
        public string PopCString()
        {
            StringBuilder sb = new StringBuilder();
            byte b = PopByte();
            while (b != 0)
            {
                sb.Append((char)b);
                b = PopByte();
            }
            return sb.ToString();
        }
        #endregion

        public T PopIBinaryObject<T>(int maxSize = DEFAULT_MAX_OBJECT_SIZE) where T : IBinaryObject, new()
        {
            try
            {
                T binaryObject = new T();
                var arr = PeekBytes(maxSize);
                int bytesConsumed;
                binaryObject.SetData(arr, out bytesConsumed);
                Skip(bytesConsumed);
                return binaryObject;
            }
            catch(IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("Unable to pop object of type '" + typeof(T).Name + "'. Bytes remaining:" + (_Data.Count() - DataPointer).ToString() + ". MaxSize:" + maxSize.ToString() + ".", e);
            }
        }


        #endregion

        #region Arrays

        #region Integers

        #region Unsigned
        public byte[] PopBytes(int count)
        {
            byte[] result = _Data.Skip(DataPointer).Take(count).ToArray();
            DataPointer += count;
            return result;
        }
        public byte[] PopBytesReversed(int count)
        {
            byte[] result = new byte[count];
            for (int i = count - 1; i >= 0; i--)
            {
                result[i] = PopByte();
            }

            return result;
        }
        public ushort[] PopUShorts(int Count)
        {
            ushort[] arr = new ushort[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = PopUShort();
            }

            return arr;
        }
        public uint[] PopUInts(int Count)
        {
            uint[] arr = new uint[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = PopUInt();
            }

            return arr;
        }
        public IntPtr[] PopIntPtrs(int Count)
        {
            IntPtr[] arr = new IntPtr[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = PopIntPtr();
            }

            return arr;
        }
        public ulong[] PopULongs(int count)
        {
            ulong[] arr = new ulong[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = PopULong();
            }

            return arr;
        }


        #endregion

        #region Signed
        public short[] PopShorts(int Count)
        {
            short[] arr = new short[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = PopShort();
            }

            return arr;
        }
        public int[] PopInts(int Count)
        {
            int[] arr = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = PopInt();
            }

            return arr;
        }
        public long[] PopLongs(int count)
        {
            long[] arr = new long[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = PopLong();
            }

            return arr;
        }
        #endregion

        #endregion

        #region Decimals
        public double[] PopDoubles(int count)
        {
            var result = new double[count];
            var bytes = PopBytes(8 * count);
            for (int i = 0; i < count; i++)
            {
                result[i] = BitConverter.ToDouble(bytes, 8 * i);
            }
            return result;
        }
        #endregion

        #region Text
        public string[] PopLengthedStrings(int length, int count)
        {
            string[] results = new string[count];
            for (int i = 0; i < count; ++i)
            {
                results[i] = PopFixedLengthString(length);
            }
            return results;
        }
        public string[] PopCStrings(int count)
        {
            var result = new string[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = PopCString();
            }
            return result;
        }
        #endregion

        public T[] PopIBinaryObjects<T>(int count, int maxSize = DEFAULT_MAX_OBJECT_SIZE) where T : IBinaryObject, new()
        {
            T[] binaryObject = new T[count];
            for (int i = 0; i < count; i++)
            {
                binaryObject[i] = PopIBinaryObject<T>(maxSize);
            }

            return binaryObject;
        }


        #endregion
    }
}
