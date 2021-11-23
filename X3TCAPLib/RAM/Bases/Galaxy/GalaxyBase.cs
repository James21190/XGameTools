using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Galaxy
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


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            base.SetDataFromMemoryObjectConverter(objectByteList);
        }
        #endregion
    }
}
