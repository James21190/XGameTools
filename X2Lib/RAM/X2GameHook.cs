using CommonToolLib.ProcessHooking;
using System;
using System.Diagnostics;
using X2Lib.RAM.Bases.B3D;
using X2Lib.RAM.Bases.Sector;
using X2Lib.RAM.Bases.Sector.SectorObject_TypeData;
using X2Lib.RAM.Bases.Story;

namespace X2Lib.RAM
{
    public class X2GameHook : XCommonLib.RAM.GameHook
    {
        // Taken from TC. Possible inaccuracy.
        public enum RaceID_X2 : ushort
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
        public enum MainType_X2
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
            pSystemBase = 0x15A453C,
            pB3DBase = 0x015d66ac,

            #region TypeData
            pTypeData_Bullet = 0x015d65b0,
            pTypeData_Sector = 0x015d65b4,
            pTypeData_Background = 0x015d65b8,
            pTypeData_Sun = 0x015d65bc,
            pTypeData_Planet = 0x015d65c0,
            pTypeData_Dock = 0x015d65c4,
            pTypeData_Factory = 0x015d65c8,
            pTypeData_Ship = 0x015d65cc,
            pTypeData_Laser = 0x015d65d0,

            pTypeDataCountArray = 0x015d6620
            #endregion
        }
        public override string GameName => "X2";

        #region Pointers
        #region Bases
        public MemoryObjectPointer<MemoryObjectPointer<SectorBase>> ppSectorBase;
        public MemoryObjectPointer<MemoryObjectPointer<StoryBase>> ppStoryBase;
        public MemoryObjectPointer<MemoryObjectPointer<B3DBase>> ppB3DBase;
        #endregion
        #region TypeData
        public MemoryObjectPointer<MemoryInt16> pTypeData_CountArr;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Bullet>> ppTypeData_Bullet;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Sector>> ppTypeData_Sector;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Background>> ppTypeData_Background;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Sun>> ppTypeData_Sun;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Planet>> ppTypeData_Planet;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Dock>> ppTypeData_Dock;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Factory>> ppTypeData_Factory;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>> ppTypeData_Ship;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Laser>> ppTypeData_Laser;
        #endregion
        #endregion

        #region Objects
        public override XCommonLib.RAM.Bases.Sector.SectorBase SectorBase => ppSectorBase != null ? ppSectorBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Story.StoryBase StoryBase => ppStoryBase != null ? ppStoryBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Galaxy.GalaxyBase GalaxyBase => throw new NotImplementedException();
        public override XCommonLib.RAM.Bases.B3D.B3DBase B3DBase => ppB3DBase != null ? ppB3DBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.System.SystemBase SystemBase => throw new NotImplementedException();

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

        public override int GetTypeDataCount_Ship()
        {
            return TypeData_Counts[(int)MainType_X2.Ship];
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Bullet GetTypeData_Bullet(int subType)
        {
            return ppTypeData_Bullet.obj.GetObjectInArray(subType);
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Sector GetTypeData_Sector(int subType)
        {
            return ppTypeData_Sector.obj.GetObjectInArray(subType);
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Background GetTypeData_Background(int subType)
        {
            return ppTypeData_Background.obj.GetObjectInArray(subType);
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Sun GetTypeData_Sun(int subType)
        {
            return ppTypeData_Sun.obj.GetObjectInArray(subType);
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Planet GetTypeData_Planet(int subType)
        {
            return ppTypeData_Planet.obj.GetObjectInArray(subType);
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Dock GetTypeData_Dock(int subType)
        {
            return ppTypeData_Dock.obj.GetObjectInArray(subType);
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Factory GetTypeData_Factory(int subType)
        {
            return ppTypeData_Factory.obj.GetObjectInArray(subType);
        }
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship GetTypeData_Ship(int subType)
        {
            return ppTypeData_Ship.obj.GetObjectInArray(subType);
        }
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Laser GetTypeData_Laser(int subType)
        {
            return ppTypeData_Laser.obj.GetObjectInArray(subType);
        }
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Shield GetTypeData_Shield(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Missile GetTypeData_Missile(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ware_E GetTypeData_Ware_E(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ware_N GetTypeData_Ware_N(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ware_B GetTypeData_Ware_B(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ware_F GetTypeData_Ware_F(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ware_M GetTypeData_Ware_M(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ware_T GetTypeData_Ware_T(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Asteroid GetTypeData_Asteroid(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Gate GetTypeData_Gate(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Camera GetTypeData_Camera(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Special GetTypeData_Special(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Nebula GetTypeData_Nebula(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Station_Interior GetTypeData_Station_Interior(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Type_23 GetTypeData_Type_23(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Type_24 GetTypeData_Type_24(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Cockpit GetTypeData_Cockpit(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Type_26 GetTypeData_Type_26(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Type_27 GetTypeData_Type_27(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Debris GetTypeData_Debris(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Wreck GetTypeData_Wreck(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Factory_Wreck GetTypeData_Factory_Wreck(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship_Wreck GetTypeData_Ship_Wreck(int subType)
        {
            throw new NotImplementedException();
        }

        #endregion

        public X2GameHook(Process process)
        {
            HookIntoProcess(process);

            #region Bases
            ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(this, (IntPtr)GlobalAddresses_X2.pSectorBase);
            ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(this, (IntPtr)GlobalAddresses_X2.pStoryBase);
            ppB3DBase = new MemoryObjectPointer<MemoryObjectPointer<B3DBase>>(this, (IntPtr)GlobalAddresses_X2.pB3DBase);
            #endregion

            #region TypeData
            pTypeData_CountArr = new MemoryObjectPointer<MemoryInt16>(this, (IntPtr)GlobalAddresses_X2.pTypeDataCountArray);
            ppTypeData_Bullet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Bullet>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Bullet);
            ppTypeData_Sector = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Sector>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Sector);
            ppTypeData_Background = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Background>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Background);
            ppTypeData_Sun = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Sun>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Sun);
            ppTypeData_Planet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Planet>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Planet);
            ppTypeData_Dock = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Dock>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Dock);
            ppTypeData_Factory = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Factory>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Factory);
            ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Ship);
            ppTypeData_Laser = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Laser>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Laser);
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
                case RaceID_X2.Unknown: return GeneralRaces.Unknown;
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
                case MainType_X2.Type_23: return GeneralMainType.UnknownType_23;
                case MainType_X2.Type_24: return GeneralMainType.UnknownType_24;
                case MainType_X2.Type_26: return GeneralMainType.UnknownType_26;
                case MainType_X2.Type_27: return GeneralMainType.UnknownType_27;
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
