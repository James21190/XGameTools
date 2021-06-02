using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using XCommonLib.RAM.Bases.Sector.Meta;
using XCommonLib.RAM.Generics;

namespace X3TCAPLib.RAM.Bases.Sector.SectorObject_Meta
{
    /// <summary>
    /// A base class for a meta object that has child SectorObjects.
    /// </summary>
    public abstract class SectorObjectMetaWithChildren : MemoryObject, ISectorObjectMeta
    {
        public LinkedListStart<SectorObject>[] Children = new LinkedListStart<SectorObject>[X3TCGameHook.MainTypeCount];

        public SectorObjectMetaWithChildren()
        {
            for (int i = 0; i < X3TCGameHook.MainTypeCount; i++)
            {
                Children[i] = new LinkedListStart<SectorObject>();
            }
        }
        public XCommonLib.RAM.Bases.Sector.SectorObject[] GetChildren()
        {
            List<XCommonLib.RAM.Bases.Sector.SectorObject> children = new List<XCommonLib.RAM.Bases.Sector.SectorObject>();
            for (int i = 0; i < X3TCGameHook.MainTypeCount; i++)
            {
                children.AddRange(GetChildren(i));
            }
            return children.ToArray();
        }

        public XCommonLib.RAM.Bases.Sector.SectorObject[] GetChildren(int main_Type)
        {
            LinkedListStart<SectorObject> list = Children[main_Type];
            if (!list.pFirst.IsValid || !list.pFirst.obj.IsValid)
            {
                return new SectorObject[0];
            }
            List<SectorObject> children = new List<SectorObject>();
            SectorObject so = list.pFirst.obj;
            while (so.IsValid)
            {
                children.Add(so);
                so = so.pNext.obj;
            }

            return children.ToArray();
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
            ObjectByteList collection = new ObjectByteList(Memory, hProcess, pThis);

            Children = collection.PopIMemoryObjects<LinkedListStart<SectorObject>>(X3TCGameHook.MainTypeCount);

            SetUniqueData(collection);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            for (int i = 0; i < X3TCGameHook.MainTypeCount; i++)
            {
                Children[i].SetLocation(hProcess, address + LinkedListStart<SectorObject>.ByteSizeConst * i);
            }
        }

        protected abstract void SetUniqueData(ObjectByteList obl);

        #endregion
    }
}
