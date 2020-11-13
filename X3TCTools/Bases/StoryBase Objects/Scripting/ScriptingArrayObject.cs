using Common.Memory;
using System;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting
{
    public class ScriptingArrayObject : MemoryObject
    {
        public int id;

        public int length;
        public int count;
        public MemoryObjectPointer<DynamicValue> pArray = new MemoryObjectPointer<DynamicValue>();

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 32;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);
            id = collection.PopInt();
            length = collection.PopInt(8);
            count = collection.PopInt();
            pArray = collection.PopIMemoryObject<MemoryObjectPointer<DynamicValue>>();
        }
        #endregion
    }
}
