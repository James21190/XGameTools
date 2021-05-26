using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonToolLib.Memory
{
    /// <summary>
    /// List that can convert objects to bytes and can pop objects.
    /// </summary>
    public class ObjectByteList : MemoryObject
    {
        private List<byte> m_Data = new List<byte>();

        private int m_ReadPointer = 0;

        public ObjectByteList()
        {

        }
        public ObjectByteList(byte[] Data)
        {
            m_Data = new List<byte>(Data);
        }

        public ObjectByteList(byte[] Data, IntPtr hProcess, IntPtr address)
        {
            m_Data = new List<byte>(Data);
            SetLocation(hProcess, address);
        }

        #region IMemoryObject
        public override int ByteSize => m_Data.Count();

        public override void SetData(byte[] Memory)
        {
            m_Data = new List<byte>(Memory);
        }

        public override byte[] GetBytes()
        {
            return m_Data.ToArray();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }

        #endregion

        public void Skip(int count)
        {
            m_ReadPointer += count;
        }

        public void GoTo(int offset)
        {
            m_ReadPointer = offset;
        }

        #region Depreciated
        [Obsolete("This method is no longer supported. Please use PopBytes instead.")]
        public void PopFirst(ref byte[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = m_Data[m_ReadPointer++];
            }
        }

        [Obsolete("This method is no longer supported. Please use PopBytes instead.")]
        public void PopFirst(ref byte[] arr, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref arr);
        }

        [Obsolete("This method is no longer supported. Please use PopByte instead.")]
        public void PopFirst(ref byte value)
        {
            value = m_Data[m_ReadPointer++];
        }

        [Obsolete("This method is no longer supported. Please use PopByte instead.")]
        public void PopFirst(ref byte value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }

        [Obsolete("This method is no longer supported. Please use PopShort instead.")]
        public void PopFirst(ref short value)
        {
            byte[] data = new byte[2];

            data[0] = m_Data[m_ReadPointer++];
            data[1] = m_Data[m_ReadPointer++];

            value = BitConverter.ToInt16(data, 0);
        }
        [Obsolete("This method is no longer supported. Please use PopShort instead.")]
        public void PopFirst(ref short value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }

        [Obsolete("This method is no longer supported. Please use PopUShort instead.")]
        public void PopFirst(ref ushort value)
        {
            short temp = (short)value;
            PopFirst(ref temp);
            value = (ushort)temp;
        }
        [Obsolete("This method is no longer supported. Please use PopUShort instead.")]
        public void PopFirst(ref ushort value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }

        [Obsolete("This method is no longer supported. Please use PopInt instead.")]
        public void PopFirst(ref int value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_Data[m_ReadPointer++];
            }

            value = BitConverter.ToInt32(data, 0);
        }
        [Obsolete("This method is no longer supported. Please use PopInt instead.")]
        public void PopFirst(ref int value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }

        [Obsolete("This method is no longer supported. Please use PopIntPtr instead.")]
        public void PopFirst(ref IntPtr value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_Data[m_ReadPointer++];
            }

            value = (IntPtr)BitConverter.ToInt32(data, 0);
        }

        [Obsolete("This method is no longer supported. Please use PopUInt instead.")]
        public void PopFirst(ref uint value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_Data[m_ReadPointer++];
            }

            value = BitConverter.ToUInt32(data, 0);
        }

        [Obsolete("This method is no longer supported. Please use PopUInt instead.")]
        public void PopFirst(ref uint value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }
        [Obsolete("This method is no longer supported. Please use PopIMemoryObjects instead.")]
        public void PopFirst<T>(ref T[] arr) where T : IMemoryObject
        {
            for (int i = 0; i < arr.Length; i++)
            {
                byte[] data = new byte[arr[i].ByteSize];
                PopFirst(ref data);
                arr[i].SetData(data);
            }
        }

        [Obsolete("This method is no longer supported. Please use PopIMemoryObjects instead.")]
        public void PopFirst<T>(ref T[] arr, int GoToOffset) where T : IMemoryObject
        {
            GoTo(GoToOffset);
            PopFirst(ref arr);
        }
        [Obsolete("This method is no longer supported. Please use PopIMemoryObjects instead.")]
        public void PopFirst<T>(ref T[,] arr) where T : IMemoryObject
        {
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    byte[] data = new byte[arr[x, y].ByteSize];
                    PopFirst(ref data);
                    arr[x, y].SetData(data);
                }
            }
        }
        [Obsolete("This method is no longer supported. Please use PopIMemoryObjects instead.")]
        public void PopFirst<T>(ref T[,] arr, int GoToOffset) where T : IMemoryObject
        {
            GoTo(GoToOffset);
            PopFirst(ref arr);
        }

        [Obsolete("This method is no longer supported. Please use PopIMemoryObject instead.")]
        public void PopFirst<T>(ref T obj) where T : IMemoryObject
        {
            byte[] data = new byte[obj.ByteSize];

            for (int i = 0; i < obj.ByteSize; i++)
            {
                data[i] = m_Data[m_ReadPointer++];
            }

            obj.SetData(data);
        }
        [Obsolete("This method is no longer supported. Please use PopIMemoryObject instead.")]
        public void PopFirst<T>(ref T value, int GoToOffset) where T : IMemoryObject
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }
        #endregion

        #region Appends

        public void Append(byte[] arr)
        {
            m_Data.AddRange(arr);
        }
        public void Append(byte value)
        {
            m_Data.Add(value);
        }
        public void Append(short value)
        {
            m_Data.AddRange(BitConverter.GetBytes(value));
        }
        public void Append(ushort value)
        {
            m_Data.AddRange(BitConverter.GetBytes(value));
        }
        public void Append(int value)
        {
            m_Data.AddRange(BitConverter.GetBytes(value));
        }
        public void Append(uint value)
        {
            m_Data.AddRange(BitConverter.GetBytes(value));
        }
        public void Append(IntPtr value)
        {
            Append((int)value);
        }
        public void Append<T>(T[] arr) where T : IMemoryObject
        {
            foreach (T obj in arr)
            {
                Append(obj.GetBytes());
            }
        }
        public void Append<T>(T[,] arr) where T : IMemoryObject
        {
            foreach (T obj in arr)
            {
                Append(obj.GetBytes());
            }
        }
        public void Append(IMemoryObject memoryObject)
        {
            m_Data.AddRange(memoryObject.GetBytes());
        }
        #endregion

        #region Pops

        public byte PopByte()
        {
            return m_Data[m_ReadPointer++];
        }

        public byte[] PopBytes(int Count)
        {
            byte[] result = m_Data.Skip(m_ReadPointer).Take(Count).ToArray();
            m_ReadPointer += Count;
            return result;
        }

        public short PopShort()
        {
            return BitConverter.ToInt16(PopBytes(2), 0);
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

        public ushort PopUShort()
        {
            return (ushort)PopShort();
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

        public int PopInt()
        {
            return BitConverter.ToInt32(PopBytes(4), 0);
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

        public uint PopUInt()
        {
            return (uint)PopInt();
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

        public IntPtr PopIntPtr()
        {
            return (IntPtr)PopInt();
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

        public long PopLong()
        {
            return BitConverter.ToInt64(PopBytes(8), 0);
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

        public ulong PopULong()
        {
            return (ulong)PopLong();
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

        public T PopIMemoryObject<T>() where T : IMemoryObject, new()
        {
            T memoryObject = new T();

            memoryObject.SetLocation(hProcess, pThis + m_ReadPointer);
            memoryObject.SetData(PopBytes(memoryObject.ByteSize));

            return memoryObject;
        }

        public T[] PopIMemoryObjects<T>(int Count) where T : IMemoryObject, new()
        {
            T[] memoryObjects = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                memoryObjects[i] = new T();
                memoryObjects[i].SetLocation(hProcess, pThis + m_ReadPointer);
                memoryObjects[i].SetData(PopBytes(memoryObjects[i].ByteSize));
            }

            return memoryObjects;
        }


        #region GoTo

        public byte PopByte(int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopByte();
        }
        public byte[] PopBytes(int Count, int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopBytes(Count);
        }

        public short PopShort(int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopShort();
        }
        public short[] PopShorts(int Count, int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopShorts(Count);
        }

        public ushort PopUShort(int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopUShort();
        }
        public ushort[] PopUShorts(int Count, int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopUShorts(Count);
        }

        public int PopInt(int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopInt();
        }
        public int[] PopInts(int Count, int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopInts(Count);
        }

        public uint PopUInt(int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopUInt();
        }
        public uint[] PopUInts(int Count, int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopUInts(Count);
        }

        public IntPtr PopIntPtr(int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopIntPtr();
        }
        public IntPtr[] PopIntPtrs(int Count, int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopIntPtrs(Count);
        }

        public long PopLong(int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopLong();
        }
        public long[] PopLongs(int Count, int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopLongs(Count);
        }

        public ulong PopULong(int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopUInt();
        }
        public ulong[] PopULongs(int Count, int GoToOffset)
        {
            GoTo(GoToOffset);
            return PopULongs(Count);
        }

        public T PopIMemoryObject<T>(int GoToOffset) where T : IMemoryObject, new()
        {
            GoTo(GoToOffset);
            return PopIMemoryObject<T>();
        }
        public T[] PopIMemoryObjects<T>(int Count, int GoToOffset) where T : IMemoryObject, new()
        {
            GoTo(GoToOffset);
            return PopIMemoryObjects<T>(Count);
        }

        #endregion

        #endregion
        public void PopRemaining(ref byte[] arr)
        {
            arr = m_Data.Skip(m_ReadPointer).ToArray();
            m_ReadPointer = m_Data.Count;
        }

    }
}
