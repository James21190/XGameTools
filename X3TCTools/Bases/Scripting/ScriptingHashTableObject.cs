using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases.Scripting
{
    public class ScriptingHashTableObject : MemoryObject
    {

        public const int ByteSize = 32;

        public int id;

        public ScriptingHashTable hashTable = new ScriptingHashTable();

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);
            id = collection.PopInt();
            hashTable = collection.PopIMemoryObject<ScriptingHashTable>(0x8);
        }
        #endregion
    }
}
