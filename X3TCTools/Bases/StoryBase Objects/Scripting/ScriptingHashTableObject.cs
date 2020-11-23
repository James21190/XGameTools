using Common.Memory;
using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting
{
    public class ScriptingHashTableObject : MemoryObject
    {

        public int id;

        public ScriptingHashTable hashTable = new ScriptingHashTable();

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
            hashTable = collection.PopIMemoryObject<ScriptingHashTable>(0x8);
        }
        #endregion
    }
}
