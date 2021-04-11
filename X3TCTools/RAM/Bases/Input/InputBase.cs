using Common.Memory;
using Common.Vector;
using System;
using X3Tools.RAM.Generics;

namespace X3Tools.RAM.Bases.Input
{
    public class InputBase : MemoryObject
    {
        public int X2FunctionIndex;

        public int Paused;

        public MemoryObjectPointer<HashTable<MemoryInt32>> pHashTable1;
        public MemoryObjectPointer<HashTable<MemoryInt32>> pHashTable2;

        public int ScriptingObjectID;

        public Vector3 NextLocation;

        public int AbsTime;

        public int IsModified;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 0x531;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            X2FunctionIndex = objectByteList.PopInt(0x418);

            Paused = objectByteList.PopInt(0x4a0);

            pHashTable1 = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<MemoryInt32>>>(0x4bc);
            pHashTable2 = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<MemoryInt32>>>();

            ScriptingObjectID = objectByteList.PopInt(0x4dc);

            NextLocation = objectByteList.PopIMemoryObject<Vector3>();

            AbsTime = objectByteList.PopInt(0x4f8);

            IsModified = objectByteList.PopInt(0x500);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
    }
}
