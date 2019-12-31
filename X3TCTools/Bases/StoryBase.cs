using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases.Unimplemented
{
    public class StoryBase : IMemoryObject
    {
        public const int byteSize = 5648;

        public IntPtr pHashTable;

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public int GetByteSize()
        {
            return byteSize;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);
            collection.PopFirst(ref pHashTable);
        }
    }
}
