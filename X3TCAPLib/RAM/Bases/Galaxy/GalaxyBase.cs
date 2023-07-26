using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Galaxy
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
        public override XCommonLib.RAM.Bases.Galaxy.SectorData[] Sectors { get; set; }
        #endregion

        #region IMemoryObject
        public const int BYTE_SIZE = 0xfb410;
        public override int ByteSize => BYTE_SIZE;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            Sectors = objectByteList.PopIMemoryObjects<SectorData>(GALAXY_SIZE,0x10);
        }

        #endregion
    }
}
