using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonToolLib.Memory;

namespace X3Tools.RAM.Bases.B3D
{
    public class ModelData : MemoryObject
    {
        public override int ByteSize => 0x18;

        public short Sub0xc_Count;

        public MemoryObjectPointer<MemoryInt64> pSub0xc = new MemoryObjectPointer<MemoryInt64>();

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            Sub0xc_Count = objectByteList.PopShort(0x8);

            pSub0xc = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryInt64>>(0xc);
        }

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}
