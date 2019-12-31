using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Memory;

namespace X2Tools.X2.SectorObjects.Meta
{
    class GateMeta : IMemoryObject
    {
        public const int ByteSize = 108;

        public GateMeta(IntPtr hProcess, IntPtr Address)
        {
            SetData(MemoryControl.Read(hProcess, Address, ByteSize));
        }

        public GateMeta(byte[] Memory)
        {
            SetData(Memory);
        }

        public void SetData(byte[] Memory)
        {
            
        }

        public byte[] GetBytes()
        {
            byte[] arr = new byte[ByteSize];

            return arr;
        }

        public int GetByteSize()
        {
            return ByteSize;
        }
    }
}
