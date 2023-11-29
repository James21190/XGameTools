using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Generics;

namespace X2Lib.RAM.Bases.B3D
{
    public class B3DBase : XCommonLib.RAM.Bases.B3D.B3DBase
    {
        #region Memory Fields

        public MemoryObjectPointer<HashTable<RenderObject>> pRenderObjectHashTable;

        #endregion
        public override XCommonLib.RAM.Bases.B3D.RenderObject First => throw new NotImplementedException();
        public override XCommonLib.RAM.Bases.B3D.RenderObject Last => throw new NotImplementedException();


        public override XCommonLib.RAM.Bases.B3D.RenderObject GetRenderObject(int id)
        {
            return pRenderObjectHashTable.obj.GetObject(id);
        }

        public override XCommonLib.RAM.Bases.B3D.RenderObject[] GetRenderObjects()
        {
            var table = pRenderObjectHashTable.obj;
            var ids = table.ScanContents();
            RenderObject[] result = new RenderObject[ids.Length];
            for(int i = 0; i < ids.Length; i++)
            {
                result[i] = table.GetObject(ids[i]); 
            }

            return result;
        }

        #region IMemoryObject
        public override int ByteSize => 0xc6ec;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter moc)
        {
            pRenderObjectHashTable = moc.PopIMemoryObject<MemoryObjectPointer<HashTable<RenderObject>>>(0xc);

            return SetDataResult.Success;
        }
        #endregion
    }
}
