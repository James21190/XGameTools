using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Generics;

namespace X3TCAPLib.RAM.Bases.B3D
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
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.B3D.RenderObject[] GetRenderObjects()
        {
            throw new NotImplementedException();
        }

        #region IMemoryObject
        public override int ByteSize => throw new NotImplementedException();


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter moc)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
