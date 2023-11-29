using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonToolLib.Generics
{
    /// <summary>
    /// A byte array that can combine IBinaryObjects and seperate them.
    /// </summary>
    public class BinaryObjectConverter : IBinaryObject
    {
        private List<byte> _Data;
        protected int _DataPointer { get; private set; } = 0;
        public bool IsAtEnd 
        { 
            get
            {
                return _DataPointer == _Data.Count();
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
            _DataPointer = index;
        }

        #region Appends
        #region Bytes
        public void Append(byte value)
        {
            _Data.Add(value);
        }
        public void Append(byte[] arr)
        {
            _Data.AddRange(arr);
        }
        public void AppendReversed(byte[] bytes)
        {
            for (int i = bytes.Length - 1; i >= 0; i--)
                Append(bytes[i]);
        }

        #endregion

        #region Shorts
        public void Append(short value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }
        public void AppendReversed(short value)
        {
            AppendReversed(BitConverter.GetBytes(value));
        }
        public void Append(ushort value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }

        #endregion

        #region Ints
        public void Append(int value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }
        public void AppendReversed(int value)
        {
            AppendReversed(BitConverter.GetBytes(value));
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

        #region BinaryObjects
        public void Append(IBinaryObject memoryObject)
        {
            _Data.AddRange(memoryObject.GetBytes());
        }
        public void Append<T>(T[] arr) where T : IBinaryObject
        {
            foreach (T obj in arr)
            {
                Append(obj.GetBytes());
            }
        }
        #endregion

        #region Strings
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
            for(int i = 0; i < length; i++)
            {
                if(arr.Length <= i)
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
            foreach(var str in strs)
                AppendFixedLengthString(str, length);
        }

        public void AppendCString(string str)
        {
            byte[] bytes = new byte[str.Length + 1];

            for(int i = 0; i < str.Length; i++)
            {
                bytes[i] = (byte)str[i];
                if (bytes[i] == 0)
                    throw new ArgumentException("String contains null");
            }

            bytes[str.Length] = 0;

            Append(bytes);
        }

        public void AppendCStrings(string[] strs)
        {
            foreach(var str in strs)
            {
                AppendCString(str);
            }
        }
        #endregion



        #endregion

        #region Pops
        #region Bytes
        public byte PopByte()
        {
            return _Data[_DataPointer++];
        }
        public byte PopByte(int GoToOffset)
        {
            Seek(GoToOffset);
            return PopByte();
        }
        public byte[] PopBytes(int Count)
        {
            byte[] result = _Data.Skip(_DataPointer).Take(Count).ToArray();
            _DataPointer += Count;
            return result;
        }
        public byte[] PopBytes(int Count, int GoToOffset)
        {
            Seek(GoToOffset);
            return PopBytes(Count);
        }

        public byte[] PopBytesReversed(int count)
        {
            byte[] result = new byte[count];
            for(int i = count - 1; i >= 0; i--)
            {
                result[i] = PopByte();
            }

            return result;
        }
        #endregion

        #region Shorts
        public short PopShort()
        {
            return BitConverter.ToInt16(PopBytes(2), 0);
        }
        public short PopShortReversed()
        {
            return BitConverter.ToInt16(PopBytesReversed(2), 0);
        }
        public short PopShort(int GoToOffset)
        {
            Seek(GoToOffset);
            return PopShort();
        }
        public short[] PopShorts(int Count)
        {
            short[] arr = new short[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = PopShort();
            }

            return arr;
        }
        public short[] PopShorts(int Count, int GoToOffset)
        {
            Seek(GoToOffset);
            return PopShorts(Count);
        }
        public ushort PopUShort()
        {
            return (ushort)PopShort();
        }
        public ushort PopUShort(int GoToOffset)
        {
            Seek(GoToOffset);
            return PopUShort();
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
        public ushort[] PopUShorts(int Count, int GoToOffset)
        {
            Seek(GoToOffset);
            return PopUShorts(Count);
        }
        #endregion

        #region Ints
        public int PopInt()
        {
            return BitConverter.ToInt32(PopBytes(4), 0);
        }
        public int PopInt(int GoToOffset)
        {
            Seek(GoToOffset);
            return PopInt();
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
        public int[] PopInts(int Count, int GoToOffset)
        {
            Seek(GoToOffset);
            return PopInts(Count);
        }

        public uint PopUInt()
        {
            return (uint)PopInt();
        }
        public uint PopUInt(int GoToOffset)
        {
            Seek(GoToOffset);
            return PopUInt();
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
        public uint[] PopUInts(int Count, int GoToOffset)
        {
            Seek(GoToOffset);
            return PopUInts(Count);
        }

        public IntPtr PopIntPtr()
        {
            return (IntPtr)PopInt();
        }
        public IntPtr PopIntPtr(int GoToOffset)
        {
            Seek(GoToOffset);
            return PopIntPtr();
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
        public IntPtr[] PopIntPtrs(int Count, int GoToOffset)
        {
            Seek(GoToOffset);
            return PopIntPtrs(Count);
        }
        #endregion

        #region Longs
        public long PopLong()
        {
            return BitConverter.ToInt64(PopBytes(8), 0);
        }
        public long PopLong(int goToOffset)
        {
            Seek(goToOffset);
            return PopLong();
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
        public long[] PopLongs(int count, int goToOffset)
        {
            Seek(goToOffset);
            return PopLongs(count);
        }

        public ulong PopULong()
        {
            return (ulong)PopLong();
        }
        public ulong PopULong(int goToOffset)
        {
            Seek(goToOffset);
            return PopUInt();
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
        public ulong[] PopULongs(int count, int goToOffset)
        {
            Seek(goToOffset);
            return PopULongs(count);
        }
        #endregion

        #region BinaryObjects
        public T PopIBinaryObject<T>() where T : IBinaryObject, new()
        {
            T binaryObject = new T();
            binaryObject.SetData(PopBytes(binaryObject.ByteSize));
            return binaryObject;
        }
        public T PopIBinaryObject<T>(int goToOffset) where T : IBinaryObject, new()
        {
            Seek(goToOffset);
            return PopIBinaryObject<T>();
        }

        public T[] PopIBinaryObjects<T>(int count) where T : IBinaryObject, new()
        {
            T[] binaryObject = new T[count];
            for (int i = 0; i < count; i++)
            {
                binaryObject[i].SetData(PopBytes(binaryObject[i].ByteSize));
            }

            return binaryObject;
        }
        #endregion

        #region Strings
        public string PopFixedLengthString(int length)
        {
            List<byte> bytes = new List<byte>();
            int i;
            for(i = 0; i < length; i++)
            {
                var readByte = PopByte();
                if (readByte == 0)
                {
                    _DataPointer += (length - i - 1);
                    break;
                }
                bytes.Add(readByte);

            }
            return Encoding.Default.GetString(bytes.ToArray());
        }
        public string[] PopLengthedStrings(int length, int count)
        {
            string[] results = new string[count];
            for(int i = 0; i < count; ++i)
            {
                results[i] = PopFixedLengthString(length);
            }
            return results;
        }

        public string PopCString()
        {
            StringBuilder sb = new StringBuilder();
            byte b = PopByte();
            while(b != 0)
            {
                sb.Append((char)b);
                b = PopByte();
            }
            return sb.ToString();
        }

        public string[] PopCStrings(int count)
        {
            var result = new string[count];
            for(int i = 0; i < count; i++)
            {
                result[i] = PopCString();
            }
            return result;
        }
        #endregion
        #endregion

        #region IBinaryObject
        public int ByteSize => _Data.Count;

        public byte[] GetBytes()
        {
            return _Data.ToArray();
        }
        public SetDataResult SetData(byte[] Memory)
        {
            _Data = new List<byte>(Memory);
            return SetDataResult.Success;
        }
        #endregion
    }
}
