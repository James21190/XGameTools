using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;


namespace X3Tools.Bases.CameraBase_Objects
{
    public class BodyData : MemoryObject
    {
        public int ID;
        public MemoryObjectPointer<MemoryObjectPointer<BodyData_Sub>> ppSub;
        public short SubLength;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 0x60;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            ID = objectByteList.PopInt(0x8);
            ppSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<BodyData_Sub>>>();
            SubLength = objectByteList.PopShort();
        }
    }
}
