using CommonToolLib.Memory;
using System.IO;
using XCommonLib.RAM.Bases.B3D;
using XCommonLib.RAM.Bases.Galaxy;
using XCommonLib.RAM.Bases.Sector;
using XCommonLib.RAM.Bases.Sector.SectorObject_TypeData;
using XCommonLib.RAM.Bases.Story;

namespace XCommonLib.RAM
{
    public abstract class GameHook : ApplicationHook
    {
        #region Bases
        /// <summary>
        /// The SectorBase is responsible for managing all in-sector objects.
        /// Returns null if not found.
        /// </summary>
        public abstract SectorBase SectorBase { get; }
        public abstract StoryBase StoryBase { get; }
        public abstract GalaxyBase GalaxyBase { get; }
        public abstract B3DBase B3DBase { get; }
        #endregion

        #region SectorObject TypeData
        public abstract int TypeData_Ship_Count { get; }
        public abstract TypeData_Ship GetTypeData_Ship(int subType);
        #endregion


        public static readonly int MainTypeCount = 32;
        public abstract string GameName { get; }
        public abstract string GetRaceIDName(ushort id);
        public abstract string GetMainTypeName(int id);


        public GameHook()
        {
            DataFileManager = new DataFileManager(string.Format(".\\DATA\\{0}\\", GameName));
        }

        public DataFileManager DataFileManager;

    }
}
