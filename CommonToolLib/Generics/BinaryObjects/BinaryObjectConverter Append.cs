using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Generics.BinaryObjects
{
    public partial class BinaryObjectConverter
    {
        #region Single Appends

        #region Integers

        #region Unsigned
        public void Append(byte value)
        {
            _Data.Add(value);
        }
        public void Append(ushort value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }
        public void Append(uint value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }
        public void Append(IntPtr value)
        {
            Append((int)value);
        }
        #endregion

        #region Signed
        #endregion
        public void Append(short value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }
        public void AppendReversed(short value)
        {
            AppendReversed(BitConverter.GetBytes(value));
        }
        public void Append(int value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }
        public void AppendReversed(int value)
        {
            AppendReversed(BitConverter.GetBytes(value));
        }
        public void Append(long value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }
        public void AppendReversed(long value)
        {
            AppendReversed(BitConverter.GetBytes(value));
        }
        #endregion

        #region Decimals
        public void Append(double value)
        {
            Append(BitConverter.GetBytes(value));
        }
        public void Append(decimal value)
        {
            var arr = decimal.GetBits(value);
            if (arr.Length != 4)
                throw new Exception("Decimal array was not of length 4.");
            for (int i = 0; i < arr.Length; i++)
            {
                Append(arr[i]);
            }
        }
        #endregion

        #region Text
        /// <summary>
        /// Fills a null array with a string. The string is null terminated.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AppendFixedLengthString(string str, int length)
        {
            if (str.Length > length)
                throw new ArgumentException();
            var arr = Encoding.Default.GetBytes(str);
            byte[] result = new byte[length];
            for (int i = 0; i < length; i++)
            {
                if (arr.Length <= i)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = arr[i];
                }
            }
            Append(result);
        }
        public void AppendFixedLengthStrings(string[] strs, int length)
        {
            foreach (var str in strs)
                AppendFixedLengthString(str, length);
        }
        public void AppendCString(string str)
        {
            byte[] bytes = new byte[str.Length + 1];

            for (int i = 0; i < str.Length; i++)
            {
                bytes[i] = (byte)str[i];
                if (bytes[i] == 0)
                    throw new ArgumentException("String contains null");
            }

            bytes[str.Length] = 0;

            Append(bytes);
        }
        #endregion

        public void Append(IBinaryObject binaryObject)
        {
            _Data.AddRange(binaryObject.GetBytes());
        }
        #endregion

        #region Array Appends

        #region Integers

        #region Unsigned
        public void Append(byte[] arr)
        {
            _Data.AddRange(arr);
        }
        public void AppendReversed(byte[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
                Append(arr[i]);
        }
        #endregion

        #region Signed
        public void Append(short[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Append(arr[i]);
        }
        public void Append(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Append(arr[i]);
        }
        public void Append(long[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Append(arr[i]);
        }
        #endregion

        #endregion

        #region Decimals
        #endregion

        #region Text
        public void AppendCStrings(string[] strs)
        {
            foreach (var str in strs)
            {
                AppendCString(str);
            }
        }
        #endregion

        public void Append<T>(T[] arr) where T : IBinaryObject
        {
            foreach (T obj in arr)
            {
                Append(obj.GetBytes());
            }
        }
        #endregion
    }
}
