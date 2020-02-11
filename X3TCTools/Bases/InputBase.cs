using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases
{
    public class InputBase : MemoryObject
    {

        public const int ByteSize = 0x531;

        // Skip0x4dc
        public int EventObjectID;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);

            collection.Skip(0x4dc);
            collection.PopFirst(ref EventObjectID);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
    }
}
