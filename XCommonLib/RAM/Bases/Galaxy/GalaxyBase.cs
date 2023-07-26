using CommonToolLib.ProcessHooking;

namespace XCommonLib.RAM.Bases.Galaxy
{
    public abstract class GalaxyBase : MemoryObject
    {
        public abstract SectorData[] Sectors { get; set; }
        public abstract int GalaxyWidth { get; }
        public abstract int GalaxyHeight { get; }


        public virtual int GetSectorIndex(int sectorX, int sectorY)
        {
            return sectorY + sectorX * GalaxyHeight;
        }
    }
}
