using CommonToolLib.Memory;
using System;


namespace X3Tools.RAM.Bases.B3D
{
    public class BodyData : MemoryObject, INumericIDObject
    {
        public int ID;
        public MemoryObjectPointer<MemoryObjectPointer<BodyData_Sub>> ppSub;
        public short SubLength;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 0x60;

        int INumericIDObject.ID => ID;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            ID = objectByteList.PopInt(0x8);
            ppSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<BodyData_Sub>>>();
            SubLength = objectByteList.PopShort();
        }
    }
}
