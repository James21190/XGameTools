using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3Tools.Generics;
using X3Tools.Sector_Objects;
using X3Tools.Sector_Objects.Meta;

namespace X3TCTools.Bases.Sector_Objects.Meta.R
{
    public abstract class SectorObjectMetaWithChildrenR : MemoryObject, ISectorObjectMeta
    {
        LinkedListStart<SectorObject> Children = new LinkedListStart<SectorObject>();

        public SectorObject[] GetChildren()
        {
            List<SectorObject> children = new List<SectorObject>();
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                children.AddRange(GetChildren((SectorObject.Main_Type)i));
            }
            return children.ToArray();
        }

        public SectorObject[] GetChildren(SectorObject.Main_Type main_Type)
        {
            List<SectorObject> children = new List<SectorObject>();
            var so = Children.pFirst.obj;
            while (so.IsValid)
            {
                if(so.ObjectType.MainTypeEnum == main_Type)
                    children.Add(so);
                so = so.pNext.obj;
            }

            return children.ToArray();
        }

        public SectorObject GetFirstChild(SectorObject.Main_Type main_Type)
        {
            throw new NotSupportedException();
        }

        public SectorObject GetLastChild(SectorObject.Main_Type main_Type)
        {
            throw new NotSupportedException();
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();

            collection.Append(Children);

            return collection.GetBytes();
        }
        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);

            Children = collection.PopIMemoryObject<LinkedListStart<SectorObject>>();

            SetUniqueData(collection);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            Children.SetLocation(hProcess, address);
        }

        protected abstract void SetUniqueData(ObjectByteList obl);

        #endregion
    }
}
