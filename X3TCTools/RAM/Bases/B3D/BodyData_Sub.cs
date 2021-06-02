using CommonToolLib.Memory;
using System;

namespace X3Tools.RAM.Bases.B3D
{
    public class BodyData_Sub : MemoryObject
    {
        public short SubLength;

        public MemoryObjectPointer<MemoryObjectPointer<BodyData_Sub_Sub0x10>> ppSub = new MemoryObjectPointer<MemoryObjectPointer<BodyData_Sub_Sub0x10>>();

        public MemoryObjectPointer<BodyData> pParentBodyData = new MemoryObjectPointer<BodyData>();

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 96;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            SubLength = objectByteList.PopShort(4);

            ppSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<BodyData_Sub_Sub0x10>>>(16);

            pParentBodyData = objectByteList.PopIMemoryObject<MemoryObjectPointer<BodyData>>(84);
        }
    }
}
