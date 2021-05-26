using CommonToolLib.Memory;
using System;
using X3Tools.RAM.Generics;

namespace X3Tools.RAM.Bases.B3D
{
    public class B3DBase : MemoryObject
    {
        public MemoryObjectPointer<BodyData> pFirstBodyData = new MemoryObjectPointer<BodyData>();
        public int BodyDataListNull;
        public MemoryObjectPointer<BodyData> pLastBodyData = new MemoryObjectPointer<BodyData>();
        public MemoryObjectPointer<HashTable<RenderObject>> pRenderObjectHashTable = new MemoryObjectPointer<HashTable<RenderObject>>();
        public MemoryObjectPointer<HashTable<MemoryInt32>> pSceneHashTable = new MemoryObjectPointer<HashTable<MemoryInt32>>();
        public MemoryObjectPointer<HashTable<BodyData>> pBodyHashTable = new MemoryObjectPointer<HashTable<BodyData>>();

        public int EngineFlags;
        public MemoryObjectPointer<RenderObject> pFirstRenderObject = new MemoryObjectPointer<RenderObject>();
        public int RenderObjectListNull;
        public MemoryObjectPointer<RenderObject> pLastRenderObject = new MemoryObjectPointer<RenderObject>();

        public MemoryObjectPointer<HashTable<MemoryInt32>> pModelCollectionHashTable = new MemoryObjectPointer<HashTable<MemoryInt32>>();
        public B3DBase()
        {

        }

        public BodyData GetBodyData(int id)
        {
            return pBodyHashTable.obj.GetObject(id + 1);
        }

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 27208;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            pFirstBodyData = objectByteList.PopIMemoryObject<MemoryObjectPointer<BodyData>>();
            BodyDataListNull = objectByteList.PopInt();
            pLastBodyData = objectByteList.PopIMemoryObject<MemoryObjectPointer<BodyData>>();
            pRenderObjectHashTable = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<RenderObject>>>();
            pSceneHashTable = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<MemoryInt32>>>();
            pBodyHashTable = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<BodyData>>>();

            EngineFlags = objectByteList.PopInt(0x24);
            pFirstRenderObject = objectByteList.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            RenderObjectListNull = objectByteList.PopInt();
            pLastRenderObject = objectByteList.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();

            pModelCollectionHashTable = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<MemoryInt32>>>(0x80);

        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pRenderObjectHashTable.SetLocation(hProcess, address + 0xc);
            pSceneHashTable.SetLocation(hProcess, address + 0x10);
            pBodyHashTable.SetLocation(hProcess, address + 0x14);
            pModelCollectionHashTable.SetLocation(hProcess, address + 0x80);
        }
    }
}
