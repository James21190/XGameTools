using CommonToolLib.ProcessHooking;
using System;
using System.Diagnostics;
using X2Lib.RAM.Bases.Sector;
using X2Lib.RAM.Bases.Sector.SectorObject_TypeData;
using X2Lib.RAM.Bases.Story;

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
            Pirate,
            Gonor,
            Player = 10,
            Enemy,
            Neutral,
            Friendly,
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
            Nebula,
            Station_Interior,
            Type_23,
            Type_24,
            Cockpit,
            Type_26,
            Type_27,
            Debris,
            Wreck,
            Factory_Wreck,
            Ship_Wreck
        }

        public enum GlobalAddresses_X2
        {
            pSectorBase = 0x15d66a8,
            pStoryBase = 0x15d6700,

            #region TypeData
            pTypeData_Ship = 0x015d65cc,

            pTypeDataCountArray = 0x015d6620
            #endregion
        }
        public override string GameName => "X2";

        #region Pointers
        #region Bases
        public MemoryObjectPointer<MemoryObjectPointer<SectorBase>> ppSectorBase;
        public MemoryObjectPointer<MemoryObjectPointer<StoryBase>> ppStoryBase;
        #endregion
        #region TypeData
        public MemoryObjectPointer<MemoryInt16> pTypeData_CountArr;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>> ppTypeData_Ship;
        #endregion
        #endregion

        #region Objects
        public override XCommonLib.RAM.Bases.Sector.SectorBase SectorBase => ppSectorBase != null ? ppSectorBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Story.StoryBase StoryBase => ppStoryBase != null ? ppStoryBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Galaxy.GalaxyBase GalaxyBase => throw new NotImplementedException();
        public override XCommonLib.RAM.Bases.B3D.B3DBase B3DBase => throw new NotImplementedException();

        #endregion

        #region TypeData
        public override short[] TypeData_Counts
        {
            get
            {
                short[] values = new short[XCommonLib.RAM.GameHook.MainTypeCount];
                for (int i = 0; i < XCommonLib.RAM.GameHook.MainTypeCount; i++)
                    values[i] = pTypeData_CountArr.GetObjectInArray(i).Value;
                return values;
            }
        }
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship GetTypeData_Ship(int subType)
        {
            return ppTypeData_Ship.obj.GetObjectInArray(subType);
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
            pTypeData_CountArr = new MemoryObjectPointer<MemoryInt16>(hProcess, (IntPtr)GlobalAddresses_X2.pTypeDataCountArray);
            ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(hProcess, (IntPtr)GlobalAddresses_X2.pTypeData_Ship);
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
                case RaceID_X2.Enemy: return GeneralRaces.Enemy;
                case RaceID_X2.Pirate: return GeneralRaces.Pirate;
                case RaceID_X2.Friendly: return GeneralRaces.Friendly;
                case RaceID_X2.Neutral: return GeneralRaces.Neutral;
            }
            throw new NotImplementedException("RaceID of " + ((RaceID_X2)raceID).ToString() + " was not assigned.");
        }
        public override GeneralMainType GetMainType(short mainType)
        {
            switch ((MainType_X2)mainType)
            {
                case MainType_X2.Background: return GeneralMainType.Background;
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
                case MainType_X2.Nebula: return GeneralMainType.Nebula;
                case MainType_X2.Station_Interior: return GeneralMainType.Station_Interior;
                case MainType_X2.Missile: return GeneralMainType.Missile;
                case MainType_X2.Ware_T: return GeneralMainType.Ware_T;
                case MainType_X2.Ware_E: return GeneralMainType.Ware_E;
                case MainType_X2.Special: return GeneralMainType.Special;
                case MainType_X2.Ware_F: return GeneralMainType.Ware_F;
                case MainType_X2.Bullet: return GeneralMainType.Bullet;
                case MainType_X2.Ware_B: return GeneralMainType.Ware_B;
                case MainType_X2.Ware_N: return GeneralMainType.Ware_N;
                case MainType_X2.Ware_M: return GeneralMainType.Ware_M;
                case MainType_X2.Camera: return GeneralMainType.Camera;
                case MainType_X2.Type_23: return GeneralMainType.Type_23;
                case MainType_X2.Type_24: return GeneralMainType.Type_24;
                case MainType_X2.Type_26: return GeneralMainType.Type_26;
                case MainType_X2.Type_27: return GeneralMainType.Type_27;
                case MainType_X2.Cockpit: return GeneralMainType.Cockpit;
                case MainType_X2.Wreck: return GeneralMainType.Wreck;
                case MainType_X2.Factory_Wreck: return GeneralMainType.Factory_Wreck;
                case MainType_X2.Ship_Wreck: return GeneralMainType.Ship_Wreck;
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

        public override void AttachInjectionManager()
        {
            // Initialize code injector
            InjectionManager = new InjectionManager(this.hProcess);

            // OnGameTick event
            InjectionManager.CreateNewEvent("OnGameTick", (IntPtr)0x00402982, new byte[]
            {
                0xb8,0xe0,0x13,0x46,0x00, // MOV EAX, 004613e0
                0xff, 0xd0, // Call EAX
                0xa1, 0x00, 0x67, 0x5d, 0x01 // MOV EAX, pStoryBase
            }, 1);

            // OnDamage
            InjectionManager.CreateNewEvent("OnObjectDestroyed", (IntPtr)0x0043368c, new byte[]
            {
                0x8b, 0xce,// Mov ECX, ESI
                0xb8,0x70,0xf8,0x41,0x00, // MOV EAX, 0041F870
                0xff, 0xd0, // Call EAX
                0x56, // Push ESI
                0xb8,0x45,0x6b,0x4e,0x00, // MOV EAX, 004e6b45
                0xff, 0xd0, // Call EAX
                0x83, 0xc4, 0x04 // Add ESP, 0x4
            }, 7);
        }
    }
}
