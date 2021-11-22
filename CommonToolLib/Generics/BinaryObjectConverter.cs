using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonToolLib.Generics
{
    /// <summary>
    /// A byte array that can combine IBinaryObjects and seperate them.
    /// </summary>
    public class BinaryObjectConverter : IBinaryObject
    {
        private List<byte> _Data;
        protected int _DataPointer { get; private set; } = 0;

        public BinaryObjectConverter()
        {
            _Data = new List<byte>();
        }

        public BinaryObjectConverter(byte[] data)
        {
            _Data = new List<byte>(data);
        }


        public void Seek(int index)
        {
            _DataPointer = 0;
        }

        #region Appends
        public void Append(byte value)
        {
            _Data.Add(value);
        }
        public void Append(byte[] arr)
        {
            _Data.AddRange(arr);
        }

        public void Append(short value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }
        public void Append(ushort value)
        {
            _Data.AddRange(BitConverter.GetBytes(value));
        }

        public void Append(int value)
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

        #region Pops
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

        public short PopShort()
        {
            return BitConverter.ToInt16(PopBytes(2), 0);
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

        public long PopLong()
        {
            return BitConverter.ToInt64(PopBytes(8), 0);
        }
        public long PopLong(int GoToOffset)
        {
            Seek(GoToOffset);
            return PopLong();
        }

        public long[] PopLongs(int Count)
        {
            long[] arr = new long[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = PopLong();
            }

            return arr;
        }
        public long[] PopLongs(int Count, int GoToOffset)
        {
            Seek(GoToOffset);
            return PopLongs(Count);
        }

        public ulong PopULong()
        {
            return (ulong)PopLong();
        }
        public ulong PopULong(int GoToOffset)
        {
            Seek(GoToOffset);
            return PopUInt();
        }

        public ulong[] PopULongs(int Count)
        {
            ulong[] arr = new ulong[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = PopULong();
            }

            return arr;
        }
        public ulong[] PopULongs(int Count, int GoToOffset)
        {
            Seek(GoToOffset);
            return PopULongs(Count);
        }

        public T PopIBinaryObject<T>() where T : IBinaryObject, new()
        {
            T binaryObject = new T();
            binaryObject.SetData(PopBytes(binaryObject.ByteSize));
            return binaryObject;
        }
        public T[] PopIBinaryObject<T>(int count) where T : IBinaryObject, new()
        {
            T[] binaryObject = new T[count];
            for (int i = 0; i < count; i++)
            {
                binaryObject[i].SetData(PopBytes(binaryObject[i].ByteSize));
            }

            return binaryObject;
        }

        #endregion

        #region IBinaryObject
        public int ByteSize => _Data.Count;

        public byte[] GetBytes()
        {
            return _Data.ToArray();
        }
        public void SetData(byte[] Memory)
        {
            _Data = new List<byte>(Memory);
        }
        #endregion
    }
}
