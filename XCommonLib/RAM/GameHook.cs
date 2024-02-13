﻿using CommonToolLib.ProcessHooking;
using System;
using System.Drawing;
using XCommonLib.RAM.Bases.B3D;
using XCommonLib.RAM.Bases.Galaxy;
using XCommonLib.RAM.Bases.Sector;
using XCommonLib.RAM.Bases.Sector.SectorObject_TypeData;
using XCommonLib.RAM.Bases.Story;
using XCommonLib.RAM.Bases.System;

namespace XCommonLib.RAM
{
    public abstract class GameHook : ApplicationHook
    {
        #region Enums
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
            Ship_Wreck,
            Station_Interior,


            Nebula,

            UnknownType_21,
            UnknownType_22,
            UnknownType_23,
            UnknownType_24,
            UnknownType_26,
            UnknownType_27
        }
        public enum GeneralRaces : short
        {
            ATF,
            Argon,
            Boron,
            Friendly,
            Gonor,
            Khaak,
            NA,
            None,
            Paranid,
            Pirate,
            Player,
            Split,
            Teladi,
            Terran,
            Unknown,
            Unowned,
            Xenon,
            Yaki,
            Enemy,
            Neutral
        }
        #endregion

        public static readonly int MainTypeCount = 32;

        #region Fields
        /// <summary>
        /// The name of the game.
        /// </summary>
        public abstract string GameName { get; }
        /// <summary>
        /// An EventManager instance attached to the game.
        /// </summary>
        public InjectionManager InjectionManager { get; protected set; }
        /// <summary>
        /// A DataFileManager that is configured to fetch data for this version of the game.
        /// </summary>
        public DataFileManager DataFileManager;

        #region Bases
        public bool SectorBaseAvailable
        {
            get
            {
                try
                {
                    var temp = SectorBase;
                }
                catch(Exception e)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// The SectorBase is responsible for managing all in-sector objects.
        /// Returns null if not found.
        /// </summary>
        public abstract SectorBase SectorBase { get; }
        public bool StoryBaseAvailable
        {
            get
            {
                try
                {
                    var temp = StoryBase;
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }
        public abstract StoryBase StoryBase { get; }
        public bool GalaxyBaseAvailable
        {
            get
            {
                try
                {
                    var temp = GalaxyBase;
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }
        public abstract GalaxyBase GalaxyBase { get; }
        public bool B3DBaseAvailable
        {
            get
            {
                try
                {
                    var temp = B3DBase;
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }
        public abstract B3DBase B3DBase { get; }
        public bool SystemBaseAvailable
        {
            get
            {
                try
                {
                    var temp = SystemBase;
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }
        public abstract SystemBase SystemBase { get; }
        #endregion

        #region SectorObject TypeData
        public abstract short[] TypeData_Counts { get; }
        public abstract int GetTypeDataCount_Ship();
        public abstract TypeData_Bullet GetTypeData_Bullet(int subType);
        public abstract TypeData_Sector GetTypeData_Sector(int subType);
        public abstract TypeData_Background GetTypeData_Background(int subType);
        public abstract TypeData_Sun GetTypeData_Sun(int subType);
        public abstract TypeData_Planet GetTypeData_Planet(int subType);
        public abstract TypeData_Dock GetTypeData_Dock(int subType);
        public abstract TypeData_Factory GetTypeData_Factory(int subType);
        public abstract TypeData_Ship GetTypeData_Ship(int subType);
        public abstract TypeData_Laser GetTypeData_Laser(int subType);
        public abstract TypeData_Shield GetTypeData_Shield(int subType);
        public abstract TypeData_Missile GetTypeData_Missile(int subType);
        public abstract TypeData_Ware_E GetTypeData_Ware_E(int subType);
        public abstract TypeData_Ware_N GetTypeData_Ware_N(int subType);
        public abstract TypeData_Ware_B GetTypeData_Ware_B(int subType);
        public abstract TypeData_Ware_F GetTypeData_Ware_F(int subType);
        public abstract TypeData_Ware_M GetTypeData_Ware_M(int subType);
        public abstract TypeData_Ware_T GetTypeData_Ware_T(int subType);
        public abstract TypeData_Asteroid GetTypeData_Asteroid(int subType);
        public abstract TypeData_Gate GetTypeData_Gate(int subType);
        public abstract TypeData_Camera GetTypeData_Camera(int subType);
        public abstract TypeData_Special GetTypeData_Special(int subType);
        public abstract TypeData_Nebula GetTypeData_Nebula(int subType);
        public abstract TypeData_Station_Interior GetTypeData_Station_Interior(int subType);
        public abstract TypeData_Type_23 GetTypeData_Type_23(int subType);
        public abstract TypeData_Type_24 GetTypeData_Type_24(int subType);
        public abstract TypeData_Cockpit GetTypeData_Cockpit(int subType);
        public abstract TypeData_Type_26 GetTypeData_Type_26(int subType);
        public abstract TypeData_Type_27 GetTypeData_Type_27(int subType);
        public abstract TypeData_Debris GetTypeData_Debris(int subType);
        public abstract TypeData_Wreck GetTypeData_Wreck(int subType);
        public abstract TypeData_Factory_Wreck GetTypeData_Factory_Wreck(int subType);
        public abstract TypeData_Ship_Wreck GetTypeData_Ship_Wreck(int subType);

        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Attach a new EventManager to the game.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void AttachInjectionManager()
        {
            InjectionManager = new InjectionManager(hProcess);
        }
        #region SectorObject MainTypes

        public GeneralMainType GetMainTypeByID(SectorObject.SectorObjectType type)
        {
            return GetMainType(type.MainType);
        }
        public abstract GeneralMainType GetMainType(short mainType);

        /// <summary>
        /// Returns the numeric ID of a MainType.
        /// </summary>
        /// <param name="mainType"></param>
        /// <returns></returns>
        public abstract short GetMainTypeID(GeneralMainType mainType);

        /// <summary>
        /// Returns the name of a given MainType.
        /// </summary>
        /// <param name="mainType"></param>
        /// <returns></returns>
        public string GetMainTypeName(short mainType) { return GetMainTypeName(GetMainType(mainType)); }
        /// <summary>
        /// Returns the name of a given MainType.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetMainTypeName(GeneralMainType type)
        {
            return type.ToString();
            //switch (type)
            //{
            //    case GeneralMainType.Ship: return "Ship";
            //    case GeneralMainType.Sector: return "Sector";
            //    case GeneralMainType.Asteroid: return "Asteroid";
            //    case GeneralMainType.Bullet: return "Bullet";
            //    case GeneralMainType.Sun: return "Sun";
            //    case GeneralMainType.Planet: return "Planet";
            //    case GeneralMainType.Dock: return "Dock";
            //}
            //throw new NotImplementedException("Maintype of " + type + " was not assigned a name.");
        }
        #endregion

        #region Races
        public abstract GeneralRaces GetRaceByID(ushort raceID);

        public string GetRaceIDName(ushort raceID) { return GetRaceIDName(GetRaceByID(raceID)); }
        public static string GetRaceIDName(GeneralRaces raceID)
        {
            return raceID.ToString();
            //switch (raceID)
            //{
            //    case GeneralRaces.Argon: return "Argon";
            //    case GeneralRaces.Boron: return "Boron";
            //    case GeneralRaces.Split: return "Split";
            //    case GeneralRaces.Teladi: return "Teladi";
            //    case GeneralRaces.Paranid: return "Paranid";
            //    case GeneralRaces.Gonor: return "Gonor";
            //    case GeneralRaces.Khaak: return "Khaak";
            //    case GeneralRaces.Xenon: return "Xenon";
            //    case GeneralRaces.Player: return "Player";
            //    case GeneralRaces.Unowned: return "Unowned";
            //    case GeneralRaces.NA: return "NA";
            //}
            //throw new NotImplementedException("RaceID of " + raceID + " was not assigned a name.");
        }
        public Color GetRaceColor(ushort raceID) { return GetRaceColor(GetRaceByID(raceID)); }
        public static Color GetRaceColor(GeneralRaces raceID)
        {
            switch (raceID)
            {
                case GeneralRaces.Argon: return Color.Aqua;
                case GeneralRaces.Boron: return Color.SeaGreen;
                case GeneralRaces.Split: return Color.Orange;
                case GeneralRaces.Teladi: return Color.GreenYellow;
                case GeneralRaces.Paranid: return Color.YellowGreen;
                case GeneralRaces.Gonor: return Color.Bisque;
                case GeneralRaces.Khaak: return Color.Purple;
                case GeneralRaces.Xenon: return Color.IndianRed;
                case GeneralRaces.Player: return Color.LawnGreen;
                case GeneralRaces.Unowned: return Color.Gray;
                case GeneralRaces.Pirate: return Color.MediumPurple;
                case GeneralRaces.ATF:
                case GeneralRaces.Terran: return Color.Sienna;
                case GeneralRaces.Friendly:
                case GeneralRaces.Unknown:
                case GeneralRaces.Enemy:
                case GeneralRaces.Neutral:
                case GeneralRaces.NA:
                case GeneralRaces.None: return Color.LightGray;
            }
            throw new NotImplementedException("RaceID of " + raceID + " was not assigned a color.");
        }
        #endregion
        #endregion

        public GameHook()
        {
            // Create a new DataFileManager at the data's path.
            DataFileManager = new DataFileManager(string.Format(".\\DATA\\{0}\\", GameName));
        }
    }
}
