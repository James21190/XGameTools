using CommonToolLib.ProcessHooking;
using System;

namespace X2Lib.RAM.Bases.B3D
{
    public class RenderObject : XCommonLib.RAM.Bases.B3D.RenderObject
    {
        #region Memory Fields
        #endregion

        #region Common
        #endregion

        public override bool IsValid => throw new NotImplementedException();

        #region MemoryObject
        public override int ByteSize => throw new NotImplementedException();

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            base.SetDataFromMemoryObjectConverter(objectByteList);
        }
        #endregion
    }
}
