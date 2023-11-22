using CommonToolLib.ProcessHooking;
using System;

namespace X2Lib.RAM.Bases.B3D
{
    public class RenderObject : XCommonLib.RAM.Bases.B3D.RenderObject
    {
        #region Memory Fields
        public override int ID { get; set; }
        #endregion

        #region Common
        #endregion

        #region MemoryObject
        public override int ByteSize => 488;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            ID = objectByteList.PopInt(0x24);
            return SetDataResult.Success;
        }
        #endregion
    }
}
