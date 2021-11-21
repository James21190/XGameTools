using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.B3D
{
    public class B3DBase : XCommonLib.RAM.Bases.B3D.B3DBase
    {
        #region Memory Fields
        #endregion

        #region Common
        #endregion

        #region IMemoryObject
        public override int ByteSize => throw new NotImplementedException();

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromObjectByteList(MemoryObjectConverter objectByteList)
        {
            base.SetDataFromObjectByteList(objectByteList);
        }
        #endregion
    }
}
