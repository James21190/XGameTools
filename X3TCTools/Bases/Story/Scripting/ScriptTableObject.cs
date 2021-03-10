using Common.Memory;
using System;

namespace X3Tools.Bases.Story.Scripting
{
    public class ScriptTableObject : MemoryObject
    {

        public int id;

        public ScriptTableObject_Inner hashTable = new ScriptTableObject_Inner();

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 32;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, this.hProcess, pThis);
            id = collection.PopInt();
            hashTable = collection.PopIMemoryObject<ScriptTableObject_Inner>(0x8);
        }
        #endregion
    }
}
