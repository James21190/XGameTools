using CommonToolLib.ProcessHooking;
using System;

namespace X2Lib.RAM.Bases.Galaxy
{
    public class GalaxyBase : XCommonLib.RAM.Bases.Galaxy.GalaxyBase
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
