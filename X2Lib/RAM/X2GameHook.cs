using CommonToolLib.ProcessHooking;
using System;
using System.Diagnostics;
using X2Lib.RAM.Bases.Sector;
using X2Lib.RAM.Bases.Story;
using XCommonLib.RAM.Bases.Sector.SectorObject_TypeData;

namespace X2Lib.RAM
{
    public class X2GameHook : XCommonLib.RAM.GameHook
    {
        // Taken from TC. Possible inaccuracy.
        internal enum RaceID_X2 : ushort
        {
            Argon = 1,
            Boron,
            Split,
            Paranid,
            Teladi,
            Xenon,
            Khaak,
            Pirates,
            Gonor,
            Player = 10,
            EnemyRace,
            NeutralRace,
            FriendlyRace,
            Unknown,
            Race1,
            Race2,
            Race3,
            Race4,
            Race5,

            None = 65534,
        }

        // Taken from TC. Possible inaccuracy.
        internal enum MainType_X2
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

            Type_21 = 21,
            Station_Interior,

            Cockpit = 25,

            Debris = 28,
            Wreck,
            Factory_Wreck,
            Ship_Wreck
        }

        public enum GlobalAddresses_X2
        {
            TypeDataArray = 0x15d65b0,
            pSectorBase = 0x15d66a8,
            pStoryBase = 0x15d6700
        }
        public override string GameName => "X2";

        #region Pointers
        #region Bases
        public MemoryObjectPointer<MemoryObjectPointer<SectorBase>> ppSectorBase;
        public MemoryObjectPointer<MemoryObjectPointer<StoryBase>> ppStoryBase;
        #endregion
        #region TypeData
        #endregion
        #endregion

        #region Objects
        public override XCommonLib.RAM.Bases.Sector.SectorBase SectorBase => ppSectorBase != null ? ppSectorBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Story.StoryBase StoryBase => ppStoryBase != null ? ppStoryBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Galaxy.GalaxyBase GalaxyBase => throw new NotImplementedException();
        public override XCommonLib.RAM.Bases.B3D.B3DBase B3DBase => throw new NotImplementedException();

        #endregion

        #region TypeData
        public override int TypeData_Ship_Count => throw new NotImplementedException();
        public override TypeData_Ship GetTypeData_Ship(int subType)
        {
            throw new NotImplementedException();
        }
        #endregion

        public X2GameHook(Process process)
        {
            HookIntoProcess(process);

            #region Bases
            ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(hProcess, (IntPtr)GlobalAddresses_X2.pSectorBase);
            ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddresses_X2.pStoryBase);
            #endregion

            #region TypeData
            #endregion
        }

        ~X2GameHook()
        {
            Unhook();
        }

        public override GeneralRaces GetRaceByID(ushort raceID)
        {
            switch (((RaceID_X2)raceID))
            {
                case RaceID_X2.Argon: return GeneralRaces.Argon;
                case RaceID_X2.Boron: return GeneralRaces.Boron;
                case RaceID_X2.Split: return GeneralRaces.Split;
                case RaceID_X2.Teladi: return GeneralRaces.Teladi;
                case RaceID_X2.Paranid: return GeneralRaces.Paranid;
                case RaceID_X2.Player: return GeneralRaces.Player;
                case RaceID_X2.Xenon: return GeneralRaces.Xenon;
                case RaceID_X2.Khaak: return GeneralRaces.Khaak;
                case RaceID_X2.None: return GeneralRaces.None;
                case RaceID_X2.Gonor: return GeneralRaces.Gonor;
                case RaceID_X2.EnemyRace: return GeneralRaces.Enemy;
            }
            throw new NotImplementedException("RaceID of " + ((RaceID_X2)raceID).ToString() + " was not assigned.");
        }
        public override GeneralMainType GetMainType(short mainType)
        {
            switch ((MainType_X2)mainType)
            {
                case MainType_X2.Ship: return GeneralMainType.Ship;
                case MainType_X2.Sun: return GeneralMainType.Sun;
                case MainType_X2.Sector: return GeneralMainType.Sector;
                case MainType_X2.Planet: return GeneralMainType.Planet;
                case MainType_X2.Dock: return GeneralMainType.Dock;
                case MainType_X2.Shield: return GeneralMainType.Shield;
                case MainType_X2.Laser: return GeneralMainType.Laser;
                case MainType_X2.Asteroid: return GeneralMainType.Asteroid;
                case MainType_X2.Gate: return GeneralMainType.Gate;
                case MainType_X2.Debris: return GeneralMainType.Debris;
                case MainType_X2.Factory: return GeneralMainType.Factory;
                case MainType_X2.Type_21: return GeneralMainType.X2_21;
                case MainType_X2.Station_Interior: return GeneralMainType.Station_Interior;
            }
            throw new NotImplementedException("MainType of " + ((MainType_X2)mainType).ToString() + " was not assigned.");
        }

        public override short GetMainTypeID(GeneralMainType mainType)
        {
            switch (mainType)
            {
                case GeneralMainType.Ship: return (short)MainType_X2.Ship;
                case GeneralMainType.Sector: return (short)MainType_X2.Sector;
            }
            throw new NotImplementedException("MainType of " + (mainType).ToString() + " was not assigned.");
        }

        public override void AttachEventManager()
        {
            // Initialize code injector
            EventManager = new EventManager(this.hProcess);

            // OnGameTick event
            EventManager.CreateNewEvent("OnGameTick", (IntPtr)0x00402982, new byte[]
            {
                0xb8,0xe0,0x13,0x46,0x00, // MOV EAX, 004613e0
                0xff, 0xd0, // Call EAX
                0xa1, 0x00, 0x67, 0x5d, 0x01, // MOV EAX, pStoryBase
                0xc3 // Ret
            }, 3);

            // OnDamage
            EventManager.CreateNewEvent("OnObjectDestroyed", (IntPtr)0x0043368c, new byte[]
            {
                0x8b, 0xce,// Mov ECX, ESI
                0xb8,0x70,0xf8,0x41,0x00, // MOV EAX, 004613e0
                0xff, 0xd0, // Call EAX
                0xc3 // Ret
            }, 0);
        }
    }
}
