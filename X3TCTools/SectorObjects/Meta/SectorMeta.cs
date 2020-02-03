using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.SectorObjects.Meta
{
    public class SectorMeta : MemoryObject, ISectorObjectMeta
    {
        public const int ByteSize = 384;

        public ChildList[] ChildrenList = new ChildList[SectorObject.MAIN_TYPE_COUNT];
        public SectorMeta()
        {
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                ChildrenList[i] = new ChildList();
            }
        }
        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(ChildrenList);
            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public ChildList[] GetChildrenList()
        {
            return ChildrenList;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);
            collection.PopFirst(ref ChildrenList);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            foreach (var list in ChildrenList)
                list.SetLocation(hProcess, address);
        }
    }
}
