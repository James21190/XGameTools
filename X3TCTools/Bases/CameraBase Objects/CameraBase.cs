using Common.Memory;
using System;
using X3Tools.Bases.CameraBase_Objects;
using X3Tools.Generics;

namespace X3Tools.Bases
{
    public class CameraBase : MemoryObject
    {
        public MemoryObjectPointer<HashTable<Camera>> pCameraHashTable = new MemoryObjectPointer<HashTable<Camera>>();
        public MemoryObjectPointer<HashTable<MemoryInt32>> pSceneHashTable = new MemoryObjectPointer<HashTable<MemoryInt32>>();
        public MemoryObjectPointer<HashTable<BodyData>> pBodyHashTable = new MemoryObjectPointer<HashTable<BodyData>>();

        public MemoryObjectPointer<HashTable<MemoryInt32>> pModelCollectionHashTable = new MemoryObjectPointer<HashTable<MemoryInt32>>();
        public CameraBase()
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

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);
            pCameraHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<Camera>>>(0xc);
            pSceneHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<MemoryInt32>>>();
            pBodyHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<BodyData>>>();

            pModelCollectionHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<MemoryInt32>>>(0x80);

        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pCameraHashTable.SetLocation(hProcess, address + 0xc);
            pSceneHashTable.SetLocation(hProcess, address + 0x10);
            pBodyHashTable.SetLocation(hProcess, address + 0x14);
            pModelCollectionHashTable.SetLocation(hProcess, address + 0x80);
        }
    }
}
