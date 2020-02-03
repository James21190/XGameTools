using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.SectorObjects.Meta
{
    public class ChildList : IMemoryObject
    {
        public MemoryObjectPointer<SectorObject> pFirst;
        public int pDefault;
        public MemoryObjectPointer<SectorObject> pLast;

        public ChildList()
        {
            pFirst = new MemoryObjectPointer<SectorObject>();
            pLast = new MemoryObjectPointer<SectorObject>();
        }

        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(pFirst.address);
            collection.Append(pDefault);
            collection.Append(pLast.address);

            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return 12;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);

            collection.PopFirst(ref pFirst.address);
            collection.PopFirst(ref pDefault);
            collection.PopFirst(ref pLast.address);
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pFirst.SetLocation(hProcess, address);
            pLast.SetLocation(hProcess, address);
        }
    }
}
