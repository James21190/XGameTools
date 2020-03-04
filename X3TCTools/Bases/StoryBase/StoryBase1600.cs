using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases
{
    public class StoryBase1600 : MemoryObject
    {

        public const int ByteSize = 32;

        public HashTableDynamicValue hashTable = new HashTableDynamicValue();

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
            hashTable = collection.PopIMemoryObject<HashTableDynamicValue>(0x8);
        }
        #endregion
    }
}
