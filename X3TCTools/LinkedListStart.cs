using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools
{
    public class LinkedListStart : Common.Memory.IMemoryObject
    {
        public IntPtr pFirst;
        public int Unknown;
        public IntPtr pLast;
        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public int GetByteSize()
        {
            throw new NotImplementedException();
        }

        public void SetData(byte[] Memory)
        {
            throw new NotImplementedException();
        }
    }
}
