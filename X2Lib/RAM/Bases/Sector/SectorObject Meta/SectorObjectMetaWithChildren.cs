using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.Sector.SectorObject_Meta;
using XCommonLib.RAM.Generics;

namespace X2Lib.RAM.Bases.Sector.SectorObject_Meta
{
    public abstract class SectorObjectMetaWithChildren : MemoryObject, ISectorObjectMeta
    {
        public LinkedListStart<SectorObject> Children;
        public XCommonLib.RAM.Bases.Sector.SectorObject[] GetChildren()
        {
            List<SectorObject> result = new List<SectorObject>();
            var so = Children.pFirst.obj;

            while (so.IsValid)
            {
                result.Add(so);
                so = so.pNext.obj;
            }

            return result.ToArray();
        }

        public XCommonLib.RAM.Bases.Sector.SectorObject[] GetChildren(int main_Type)
        {
            List<SectorObject> result = new List<SectorObject>();
            var so = Children.pFirst.obj;

            while (so.IsValid)
            {
                if(so.ObjectType.MainType == main_Type)
                    result.Add(so);
                so = so.pNext.obj;
            }

            return result.ToArray();
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            MemoryObjectConverter collection = new MemoryObjectConverter();

            collection.Append(Children);

            return collection.GetBytes();
        }
        public override SetDataResult SetData(byte[] Memory)
        {
            MemoryObjectConverter collection = new MemoryObjectConverter(Memory, ParentMemoryBlock, pThis);

            Children = collection.PopIMemoryObject<LinkedListStart<SectorObject>>();

            SetUniqueData(collection);

            return SetDataResult.Success;
        }
        #endregion
        protected abstract void SetUniqueData(MemoryObjectConverter obl);
    }
}
