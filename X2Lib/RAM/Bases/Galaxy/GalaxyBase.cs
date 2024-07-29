using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Bases.Galaxy;

namespace X2Lib.RAM.Bases.Galaxy
{
    public class GalaxyBase : XCommonLib.RAM.Bases.Galaxy.GalaxyBase
    {
        public const int GALAXY_WIDTH = 24;
        public const int GALAXY_HEIGHT = 20;
        public const int GALAXY_SIZE = GALAXY_WIDTH * GALAXY_HEIGHT;

        #region Memory Fields
        #endregion

        #region Common
        public override int GalaxyWidth => GALAXY_WIDTH;
        public override int GalaxyHeight => GALAXY_HEIGHT;
        public override SectorData[] Sectors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region IMemoryObject
        public override int ByteSize => throw new NotImplementedException();


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
