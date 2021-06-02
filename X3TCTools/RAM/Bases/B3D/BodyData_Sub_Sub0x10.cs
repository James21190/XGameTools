using CommonToolLib.Memory;
using System;

namespace X3Tools.RAM.Bases.B3D
{
    public class BodyData_Sub_Sub0x10 : MemoryObject
    {
        public MemoryObjectPointer<ModelData> pModelData = new MemoryObjectPointer<ModelData>();

        public override int ByteSize => 0x70;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            pModelData = objectByteList.PopIMemoryObject<MemoryObjectPointer<ModelData>>(0x64);
        }
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}
