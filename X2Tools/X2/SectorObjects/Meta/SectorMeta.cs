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
    /// The meta data exclusive to Sector type objects
    /// </summary>
    public class SectorMeta : IMemoryObject
    {
        public const int ByteSize = 12;
        public IntPtr FirstChild;
        public IntPtr LastChild;
        public SectorMeta(IntPtr hProcess, IntPtr Address)
        {
            SetData(MemoryControl.Read(hProcess, Address, ByteSize));
        }

        public void SetData(byte[] Memory)
        {
            FirstChild = (IntPtr)BitConverter.ToInt32(Memory, 0);
            LastChild = (IntPtr)BitConverter.ToInt32(Memory, 8);
        }

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }
    }
}
