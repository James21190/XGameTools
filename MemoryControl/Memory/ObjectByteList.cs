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
        private List<byte> m_data = new List<byte>();

        public ObjectByteList()
        {

        }
        public ObjectByteList(byte[] Data)
        {
            m_data = new List<byte>(Data);
        }

        public int GetByteSize()
        {
            return m_data.Count();
        }

        public void SetData(byte[] Memory)
        {
            m_data = new List<byte>(Memory);
        }

        public byte[] GetBytes()
        {
            return m_data.ToArray();
        }

        #region Byte Array
        public void PopFirst(ref byte[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = m_data[0];
                m_data.RemoveAt(0);
            }
        }
        public void Append(byte[] arr)
        {
            m_data.AddRange(arr);
        }
        #endregion

        #region 1 Byte int
        public void Append(byte value)
        {
            m_data.Add(value);
        }
        public void PopFirst(ref byte value)
        {
            value = m_data[0];
            m_data.RemoveAt(0);
        }
        #endregion

        #region 2 Byte int
        public void Append(short value)
        {
            m_data.AddRange(BitConverter.GetBytes(value));
        }
        public void PopFirst(ref short value)
        {
            byte[] data = new byte[2];

            for (int i = 0; i < 2; i++)
            {
                data[i] = m_data[0];
                m_data.RemoveAt(0);
            }

            value = BitConverter.ToInt16(data, 0);
        }

        public void Append(ushort value)
        {
            m_data.AddRange(BitConverter.GetBytes(value));
        }

        public void PopFirst(ref ushort value)
        {
            byte[] data = new byte[2];

            for (int i = 0; i < 2; i++)
            {
                data[i] = m_data[0];
                m_data.RemoveAt(0);
            }

            value = BitConverter.ToUInt16(data, 0);
        }
        #endregion

        #region 4 Byte int
        public void Append(int value)
        {
            m_data.AddRange(BitConverter.GetBytes(value));
        }
        public void PopFirst(ref int value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_data[0];
                m_data.RemoveAt(0);
            }

            value = BitConverter.ToInt32(data, 0);
        }

        public void Append(uint value)
        {
            m_data.AddRange(BitConverter.GetBytes(value));
        }
        public void PopFirst(ref uint value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_data[0];
                m_data.RemoveAt(0);
            }

            value = BitConverter.ToUInt32(data, 0);
        }
        public void Append(IntPtr value)
        {
            Append((int)value);
        }
        public void PopFirst(ref IntPtr value)
        {
            byte[] data = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                data[i] = m_data[0];
                m_data.RemoveAt(0);
            }

            value = (IntPtr)BitConverter.ToInt32(data, 0);
        }
        #endregion

        #region IMemoryObject Arr
        public void Append<T>(T[] arr) where T : IMemoryObject
        {
            foreach(var obj in arr)
            {
                Append(obj.GetBytes());
            }
        }
        public void PopFirst<T>(ref T[] arr) where T : IMemoryObject
        {
            for(int i = 0; i < arr.Length; i++)
            {
                byte[] data = new byte[arr[i].GetByteSize()];
                PopFirst(ref data);
                arr[i].SetData(data);
            }
        }

        public void Append<T>(T[,] arr) where T : IMemoryObject
        {
            foreach (var obj in arr)
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
        #endregion

        #region IMemoryObject
        public void Append(IMemoryObject memoryObject)
        {
            m_data.AddRange(memoryObject.GetBytes());
        }
        public void PopFirst<T>(ref T obj) where T : IMemoryObject
        {
            byte[] data = new byte[obj.GetByteSize()];

            for(int i = 0; i < obj.GetByteSize(); i++)
            {
                data[i] = m_data[0];
                m_data.RemoveAt(0);
            }

            obj.SetData(data);
        }
        #endregion
        public void PopRemaining(ref byte[] arr)
        {
            arr = m_data.ToArray();
            m_data.Clear();
        }

    }
}
