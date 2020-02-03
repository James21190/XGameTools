using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Memory;


namespace X2Tools.X2.SectorObjects.Meta
{
    /// <summary>
    /// The meta data exclusive to Ship type objects
    /// </summary>
    public class ShipMeta : IMemoryObject
    {
        public const int ByteSize = 1084;
        public IntPtr pFirstChild;
        public IntPtr LastChild;

        public ShipMeta(IntPtr hProcess, IntPtr Address)
        {
            SetData(MemoryControl.Read(hProcess, Address, ByteSize));
        }

        public void SetData(byte[] Memory)
        {
            pFirstChild = (IntPtr)BitConverter.ToInt32(Memory, 0);
            LastChild = (IntPtr)BitConverter.ToInt32(Memory, 8);
        }

        public byte[] GetBytes()
        {
            return new byte[ByteSize];
        }
        public int GetByteSize()
        {
            return ByteSize;
        }

    }
}
