using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Memory
{
    /// <summary>
    /// List that can convert objects to bytes and can pop objects.
    /// </summary>
    public class ObjectByteList : IMemoryObject
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

        #region IMemoryObject
        public int GetByteSize()
        {
            return m_Data.Count();
        }

        public void SetData(byte[] Memory)
        {
            m_Data = new List<byte>(Memory);
        }

        public byte[] GetBytes()
        {
            return m_Data.ToArray();
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {

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

        #region Pops and Appends

        #region Byte Array
        public void PopFirst(ref byte[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = m_Data[m_ReadPointer++];
            }
        }

        public void PopFirst(ref byte[] arr, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref arr);
        }

        public void Append(byte[] arr)
        {
            m_Data.AddRange(arr);
        }
        #endregion

        #region 1 Byte int
        public void PopFirst(ref byte value)
        {
            value = m_Data[m_ReadPointer++];
        }

        public void PopFirst(ref byte value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }

        public void Append(byte value)
        {
            m_Data.Add(value);
        }
        #endregion

        #region 2 Byte int
        public void PopFirst(ref short value)
        {
            byte[] data = new byte[2];

            data[0] = m_Data[m_ReadPointer++];
            data[1] = m_Data[m_ReadPointer++];

            value = BitConverter.ToInt16(data, 0);
        }

        public void PopFirst(ref short value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }
        public void Append(short value)
        {
            m_Data.AddRange(BitConverter.GetBytes(value));
        }

        public void PopFirst(ref ushort value)
        {
            short temp = (short)value;
            PopFirst(ref temp);
            value = (ushort)temp;
        }

        public void PopFirst(ref ushort value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }
        public void Append(ushort value)
        {
            m_Data.AddRange(BitConverter.GetBytes(value));
        }
        #endregion

        #region 4 Byte int
        public void PopFirst(ref int value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_Data[m_ReadPointer++];
            }

            value = BitConverter.ToInt32(data, 0);
        }

        public void PopFirst(ref int value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }

        public void Append(int value)
        {
            m_Data.AddRange(BitConverter.GetBytes(value));
        }

        public void PopFirst(ref uint value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_Data[m_ReadPointer++];
            }

            value = BitConverter.ToUInt32(data, 0);
        }
        public void PopFirst(ref uint value, int GoToOffset)
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }
        public void Append(uint value)
        {
            m_Data.AddRange(BitConverter.GetBytes(value));
        }
        
        public void PopFirst(ref IntPtr value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_Data[m_ReadPointer++];
            }

            value = (IntPtr)BitConverter.ToInt32(data, 0);
        }
        public void Append(IntPtr value)
        {
            Append((int)value);
        }
        #endregion

        #region IMemoryObject Arr
        public void PopFirst<T>(ref T[] arr) where T : IMemoryObject
        {
            for(int i = 0; i < arr.Length; i++)
            {
                byte[] data = new byte[arr[i].GetByteSize()];
                PopFirst(ref data);
                arr[i].SetData(data);
            }
        }

        public void PopFirst<T>(ref T[] arr, int GoToOffset) where T: IMemoryObject
        {
            GoTo(GoToOffset);
            PopFirst(ref arr);
        }
        public void Append<T>(T[] arr) where T : IMemoryObject
        {
            foreach(var obj in arr)
            {
                Append(obj.GetBytes());
            }
        }

        public void PopFirst<T>(ref T[,] arr) where T : IMemoryObject
        {
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    byte[] data = new byte[arr[x, y].GetByteSize()];
                    PopFirst(ref data);
                    arr[x, y].SetData(data);
                }
            }
        }

        public void PopFirst<T>(ref T[,] arr, int GoToOffset) where T:IMemoryObject
        {
            GoTo(GoToOffset);
            PopFirst(ref arr);
        }

        public void Append<T>(T[,] arr) where T : IMemoryObject
        {
            foreach (var obj in arr)
            {
                Append(obj.GetBytes());
            }
        }
        #endregion

        #region IMemoryObject
        public void PopFirst<T>(ref T obj) where T : IMemoryObject
        {
            byte[] data = new byte[obj.GetByteSize()];

            for(int i = 0; i < obj.GetByteSize(); i++)
            {
                data[i] = m_Data[m_ReadPointer++];
            }

            obj.SetData(data);
        }

        public void PopFirst<T>(ref T value, int GoToOffset) where T: IMemoryObject
        {
            GoTo(GoToOffset);
            PopFirst(ref value);
        }

        public void Append(IMemoryObject memoryObject)
        {
            m_Data.AddRange(memoryObject.GetBytes());
        }
        #endregion
        public void PopRemaining(ref byte[] arr)
        {
            arr = m_Data.Skip(m_ReadPointer).ToArray();
            m_ReadPointer = m_Data.Count;
        }

        #endregion

    }
}
