using Common.Memory;
using Common.Vector;
using System;
using X3TCTools.Generics;

namespace X3TCTools.Bases
{
    public class InputBase : MemoryObject
    {
        public int X2FunctionIndex;

        public int Paused;

        public MemoryObjectPointer<HashTable<MemoryInt32>> pHashTable1;
        public MemoryObjectPointer<HashTable<MemoryInt32>> pHashTable2;

        public int EventObjectID;

        public Vector3 NextLocation;

        public int AbsTime;

        public int IsModified;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 0x531;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);

            collection.Skip(0x4dc);
            collection.PopFirst(ref EventObjectID);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
    }
}
