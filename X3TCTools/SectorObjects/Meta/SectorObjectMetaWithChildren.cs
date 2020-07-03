using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.SectorObjects.Meta
{
    public abstract class SectorObjectMetaWithChildren : MemoryObject, ISectorObjectMeta
    {
        public LinkedListStart<SectorObject>[] Children = new LinkedListStart<SectorObject>[SectorObject.MAIN_TYPE_COUNT];

        public SectorObjectMetaWithChildren()
        {
            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
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
            var list = Children[(int)main_Type];
            if (!list.pFirst.IsValid || !list.pFirst.obj.IsValid) return null;
            return list.pFirst.obj;
        }

        /// <summary>
        /// Returns the last child of the object with a given maintype. Returns null if the the object does not have a child of that maintype.
        /// </summary>
        /// <param name="main_Type"></param>
        /// <returns></returns>
        public SectorObject GetLastChild(SectorObject.Main_Type main_Type)
        {
            var list = Children[(int)main_Type];
            if (!list.pLast.IsValid || !list.pLast.obj.IsValid) return null;
            return list.pLast.obj;
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(Children);
            
            return collection.GetBytes();
        }
        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);

            Children = collection.PopIMemoryObjects<LinkedListStart<SectorObject>>(SectorObject.MAIN_TYPE_COUNT);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                Children[i].SetLocation(hProcess, address + LinkedListStart<SectorObject>.ByteSize * i);
            }
        }
        public override int GetByteSize()
        {
            return LinkedListStart<SectorObject>.ByteSize * SectorObject.MAIN_TYPE_COUNT;
        }
        #endregion
    }
}
