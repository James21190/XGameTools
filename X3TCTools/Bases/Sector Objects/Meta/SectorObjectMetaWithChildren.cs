using Common.Memory;
using System;
using X3TCTools.Generics;

namespace X3TCTools.Sector_Objects.Meta
{
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
                Children[i].SetLocation(hProcess, address + LinkedListStart<SectorObject>.ByteSize * i);
            }
        }

        protected abstract void SetUniqueData(ObjectByteList obl);
        #endregion
    }
}
