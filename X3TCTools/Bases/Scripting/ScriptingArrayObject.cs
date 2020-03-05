using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases.Scripting
{
    public class ScriptingArrayObject : MemoryObject
    {

        public const int ByteSize = 32;

        public int id;

        public int length;
        public int count;
        public MemoryObjectPointer<DynamicValue> pArray = new MemoryObjectPointer<DynamicValue>();

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
            length = collection.PopInt(8);
            count = collection.PopInt();
            pArray = collection.PopIMemoryObject<MemoryObjectPointer<DynamicValue>>();
        }
        #endregion
    }
}
