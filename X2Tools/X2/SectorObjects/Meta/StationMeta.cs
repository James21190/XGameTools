using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Memory;

namespace X2Tools.X2.SectorObjects.Meta
{
    class StationMeta : IMemoryObject
    {
        public const int ByteSize = 0;

        public byte[] GetBytes()
        {
            return new byte[0];
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetData(byte[] Memory)
        {
            
        }
    }
}
