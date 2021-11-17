using CommonToolLib.Memory;
using System.Drawing;
using System.IO;
using System;
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

        #region SectorObject MainTypes
        public static readonly int MainTypeCount = 32;
        public enum GeneralMainType
        {
            Bullet,
            Sector,
            Background,
            Sun,
            Planet,
            Dock,
            Factory,
            Ship,
            Laser,
            Shield,
            Missile,
            Ware_E,
            Ware_N,
            Ware_B,
            Ware_F,
            Ware_M,
            Ware_T,
            Asteroid,
            Gate,
            Camera,
            Special,
            Cockpit,
            Debris,
            Wreck,
            Factory_Wreck,
            Ship_Wreck
        }
        public GeneralMainType GetMainTypeByID(SectorObject.SectorObjectType type)
        {
            return GetMainType(type.MainType);
        }
        public abstract GeneralMainType GetMainType(short mainType);
        public  string GetMainTypeName(short mainType) { return GetMainTypeName(GetMainType(mainType)); }
        public string GetMainTypeName(GeneralMainType type)
        {
            switch (type)
            {
                case GeneralMainType.Ship: return "Ship";
            }
            throw new NotImplementedException("Maintype of " + type + " was not assigned a name.");
        }
        #endregion

        #region Races
        public enum GeneralRaces
        {
            Argon,
            Boron,
            Split,
            Teladi,
            Paranid,
            Xenon,
            Unowned,
            Khaak,
            Gonor,
            Player,
            Unknown,
            None,
            Friendly,
            Terran,
            ATF,
            Yaki,
            Pirate
        }
        public abstract GeneralRaces GetRaceByID(ushort raceID);

        public string GetRaceIDName(ushort raceID) { return GetRaceIDName(GetRaceByID(raceID)); }
        public string GetRaceIDName(GeneralRaces raceID)
        {
            switch (raceID)
            {
                case GeneralRaces.Argon: return "Argon";
                case GeneralRaces.Boron: return "Boron";
                case GeneralRaces.Split: return "Split";
                case GeneralRaces.Teladi: return "Teladi";
                case GeneralRaces.Paranid: return "Paranid";
                case GeneralRaces.Gonor: return "Gonor";
                case GeneralRaces.Khaak: return "Khaak";
                case GeneralRaces.Xenon: return "Xenon";
                case GeneralRaces.Player: return "Player";
                case GeneralRaces.Unowned: return "Unowned";
            }
            throw new NotImplementedException("RaceID of " + raceID + " was not assigned a name.");
        }
        public Color GetRaceColor(ushort raceID) { return GetRaceColor(GetRaceByID(raceID)); }
        public Color GetRaceColor(GeneralRaces raceID)
        {
            switch (raceID)
            {
                case GeneralRaces.Argon: return Color.Aqua;
                case GeneralRaces.Boron: return Color.SeaGreen;
                case GeneralRaces.Split: return Color.Orange;
                case GeneralRaces.Teladi: return Color.GreenYellow;
                case GeneralRaces.Paranid: return Color.YellowGreen;
                case GeneralRaces.Gonor: return Color.Chartreuse;
                case GeneralRaces.Khaak: return Color.Purple;
                case GeneralRaces.Xenon: return Color.IndianRed;
                case GeneralRaces.Player: return Color.LawnGreen;
                case GeneralRaces.Unowned: return Color.Gray;
                case GeneralRaces.Friendly:
                case GeneralRaces.Pirate:
                case GeneralRaces.None: return Color.LightGray;
            }
            throw new NotImplementedException("RaceID of " + raceID + " was not assigned a color.");
        }
        #endregion

        public abstract string GameName { get; }


        public GameHook()
        {
            DataFileManager = new DataFileManager(string.Format(".\\DATA\\{0}\\", GameName));
        }

        public DataFileManager DataFileManager;

    }
}
