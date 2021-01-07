using Common.Memory;
using System;
using System.Collections.Generic;
using X3Tools.Generics;

namespace X3Tools.Bases.SectorBase_Objects.Meta
{
    /// <summary>
    /// A base class for a meta object that has child SectorObjects.
    /// </summary>
    public abstract class SectorObjectMetaWithChildren : MemoryObject, ISectorObjectMeta
    {
        public LinkedListStart<SectorObject>[] Children = new LinkedListStart<SectorObject>[SectorObject.MAIN_TYPE_COUNT];

        public SectorObjectMetaWithChildren()
        {
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                Children[i] = new LinkedListStart<SectorObject>();
            }
        }

        /// <summary>
        /// Returns the first child of the object with a given maintype. Returns null if the the object does not have a child of that maintype.
        /// </summary>
        /// <param name="main_Type"></param>
        /// <returns></returns>
        public SectorObject GetFirstChild(SectorObject.Main_Type main_Type)
        {
            LinkedListStart<SectorObject> list = Children[(int)main_Type];
            if (!list.pFirst.IsValid || !list.pFirst.obj.IsValid)
            {
                return null;
            }

            return list.pFirst.obj;
        }

        /// <summary>
        /// Returns the last child of the object with a given maintype. Returns null if the the object does not have a child of that maintype.
        /// </summary>
        /// <param name="main_Type"></param>
        /// <returns></returns>
        public SectorObject GetLastChild(SectorObject.Main_Type main_Type)
        {
            LinkedListStart<SectorObject> list = Children[(int)main_Type];
            if (!list.pLast.IsValid || !list.pLast.obj.IsValid)
            {
                return null;
            }

            return list.pLast.obj;
        }
        public SectorObject[] GetChildren()
        {
            List<SectorObject> children = new List<SectorObject>();
            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                children.AddRange(GetChildren((SectorObject.Main_Type)i));
            }
            return children.ToArray();
        }

        public SectorObject[] GetChildren(SectorObject.Main_Type main_Type)
        {
            LinkedListStart<SectorObject> list = Children[(int)main_Type];
            if (!list.pFirst.IsValid || !list.pFirst.obj.IsValid)
            {
                return new SectorObject[0];
            }
            List<SectorObject> children = new List<SectorObject>();
            var so = list.pFirst.obj;
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
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);

            Children = collection.PopIMemoryObjects<LinkedListStart<SectorObject>>(SectorObject.MAIN_TYPE_COUNT);

            SetUniqueData(collection);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                Children[i].SetLocation(hProcess, address + LinkedListStart<SectorObject>.ByteSizeConst * i);
            }
        }

        protected abstract void SetUniqueData(ObjectByteList obl);

        #endregion
    }
}
