using CommonToolLib.ProcessHooking;
using System;
using System.Diagnostics;
using X3TCAPLib.RAM.Bases.B3D;
using X3TCAPLib.RAM.Bases.Galaxy;
using X3TCAPLib.RAM.Bases.Sector;
using X3TCAPLib.RAM.Bases.Sector.SectorObject_TypeData;
using X3TCAPLib.RAM.Bases.Story;
using X3TCAPLib.RAM.Bases.System;

namespace X3TCAPLib.RAM
{
    public class X3TCGameHook : X3TCAPGameHookBase
    {
        public enum GlobalAddresses_X3TC
        {
            pSystemBase = 0x00603064,
            pGalaxyBase = 0x00604634,
            pSectorBase = 0x00604640,
            pCockpitBase = 0x00604638,
            pStoryBase = 0x00604718,
            pInputBase = 0x0057FDA0,
            pB3DBase = 0x0060464c,
            ProcessEventSwitchArray = 0x004a4d18,
            ProcessEventSwitch = 0x004a4b20,

            #region TypeData
            pTypeData_Bullet = 0x006030e8,
            pTypeData_1 = 0x006030ec,
            pTypeData_Background = 0x006030f0,
            pTypeData_Sun = 0x006030f4,
            pTypeData_Planet = 0x006030f8,
            pTypeData_Dock = 0x006030FC,
            pTypeData_Factory = 0x00603100,
            pTypeData_Ship = 0x00603104,
            pTypeData_Laser = 0x00603108,
            pTypeData_Shield = 0x0060310c,
            pTypeData_10 = 0x00603110,
            pTypeData_11 = 0x00603114,
            pTypeData_12 = 0x00603118,
            pTypeData_13 = 0x0060311c,
            pTypeData_14 = 0x00603120,
            pTypeData_15 = 0x00603124,
            pTypeData_16 = 0x00603128,
            pTypeData_17 = 0x0060312c,
            pTypeData_18 = 0x00603130,
            pTypeData_19 = 0x00603134,
            pTypeData_20 = 0x00603138,
            pTypeData_21 = 0x0060313c,
            pTypeData_22 = 0x00603140,
            pTypeData_23 = 0x00603144,
            pTypeData_24 = 0x00603148,
            pTypeData_25 = 0x0060314c,
            pTypeData_26 = 0x00603150,
            pTypeData_27 = 0x00603154,
            pTypeData_28 = 0x00603158,
            pTypeData_29 = 0x0060315c,
            pTypeData_30 = 0x00603160,
            pTypeData_31 = 0x00603164,
            pTypeDataCountArray = 0x00603168,
            #endregion

            BytesAllocated = 0x00604728,
        }
        public override string GameName => "X3TC";

        #region Pointers
        #region Bases
        public MemoryObjectPointer<MemoryObjectPointer<SectorBase>> ppSectorBase;
        public MemoryObjectPointer<MemoryObjectPointer<StoryBase>> ppStoryBase;
        public MemoryObjectPointer<MemoryObjectPointer<GalaxyBase>> ppGalaxyBase;
        public MemoryObjectPointer<MemoryObjectPointer<B3DBase>> ppB3DBase;
        public MemoryObjectPointer<MemoryObjectPointer<SystemBase>> ppSystemBase;
        #endregion
        #region TypeData
        public MemoryObjectPointer<MemoryInt32> pTypeData_CountArr;
        public MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>> ppTypeData_Ship;
        #endregion
        #endregion

        #region Objects
        public override XCommonLib.RAM.Bases.Sector.SectorBase SectorBase => ppSectorBase != null ? ppSectorBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Story.StoryBase StoryBase => ppStoryBase != null ? ppStoryBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Galaxy.GalaxyBase GalaxyBase => ppGalaxyBase != null ? ppGalaxyBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.B3D.B3DBase B3DBase => ppB3DBase != null ? ppB3DBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.System.SystemBase SystemBase => ppSystemBase != null ? ppSystemBase.obj.obj : null;
        #endregion

        #region TypeData
        public override short[] TypeData_Counts
        {
            get
            {
                short[] values = new short[XCommonLib.RAM.GameHook.MainTypeCount];
                for (int i = 0; i < XCommonLib.RAM.GameHook.MainTypeCount; i++)
                    values[i] = (short)(pTypeData_CountArr.GetObjectInArray(i).Value);
                return values;
            }
        }
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Bullet GetTypeData_Bullet(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Sector GetTypeData_Sector(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Background GetTypeData_Background(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Sun GetTypeData_Sun(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Planet GetTypeData_Planet(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Dock GetTypeData_Dock(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Factory GetTypeData_Factory(int subType)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship GetTypeData_Ship(int subType)
        {
            return ppTypeData_Ship.obj.GetObjectInArray(subType);
        }
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Laser GetTypeData_Laser(int subType)
        {
            throw new NotImplementedException();
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

        public X3TCGameHook(Process process)
        {
            HookIntoProcess(process);

            #region Bases
            ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(this, (IntPtr)GlobalAddresses_X3TC.pSectorBase);
            ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(this, (IntPtr)GlobalAddresses_X3TC.pStoryBase);
            ppGalaxyBase = new MemoryObjectPointer<MemoryObjectPointer<GalaxyBase>>(this, (IntPtr)GlobalAddresses_X3TC.pGalaxyBase);
            ppB3DBase = new MemoryObjectPointer<MemoryObjectPointer<B3DBase>>(this, (IntPtr)GlobalAddresses_X3TC.pB3DBase);
            ppSystemBase = new MemoryObjectPointer<MemoryObjectPointer<SystemBase>>(this, (IntPtr)GlobalAddresses_X3TC.pSystemBase);
            #endregion

            #region TypeData
            pTypeData_CountArr = new MemoryObjectPointer<MemoryInt32>(this, (IntPtr)GlobalAddresses_X3TC.pTypeDataCountArray);
            ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(this, (IntPtr)GlobalAddresses_X3TC.pTypeData_Ship);

            #endregion
        }

        ~X3TCGameHook()
        {
            Unhook();
        }

        public override void AttachInjectionManager()
        {
            // Initialize code injector
            InjectionManager = new InjectionManager(this.hProcess);

            // OnGameTick event
            InjectionManager.CreateNewEvent("OnGameTick", (IntPtr)0x00404a87, new byte[]
            {
                0x81, 0xa0, 0x08, 0x01, 0x00, 0x00, 0xff, 0xbf, 0xff, 0xff, // and [eax + 0x108] 0xffffbfff
                0xbd, 0x01, 0x00, 0x00, 0x00 // mov ebp 0x1
            }, 6);
        }

        public override GeneralRaces GetRaceByID(ushort raceID)
        {
            switch (((RaceID_X3TCAP)raceID))
            {
                case RaceID_X3TCAP.Argon: return GeneralRaces.Argon;
                case RaceID_X3TCAP.Boron: return GeneralRaces.Boron;
                case RaceID_X3TCAP.Split: return GeneralRaces.Split;
                case RaceID_X3TCAP.Teladi: return GeneralRaces.Teladi;
                case RaceID_X3TCAP.Paranid: return GeneralRaces.Paranid;
                case RaceID_X3TCAP.Player: return GeneralRaces.Player;
                case RaceID_X3TCAP.Xenon: return GeneralRaces.Xenon;
                case RaceID_X3TCAP.Khaak: return GeneralRaces.Khaak;
                case RaceID_X3TCAP.None: return GeneralRaces.None;
                case RaceID_X3TCAP.Friendly: return GeneralRaces.Friendly;
                case RaceID_X3TCAP.Terran: return GeneralRaces.Terran;
                case RaceID_X3TCAP.ATF: return GeneralRaces.ATF;
                case RaceID_X3TCAP.Yaki: return GeneralRaces.Yaki;
                case RaceID_X3TCAP.Pirate: return GeneralRaces.Pirate;
                case RaceID_X3TCAP.Gonor: return GeneralRaces.Gonor;
                case RaceID_X3TCAP.NA: return GeneralRaces.NA;
                case RaceID_X3TCAP.Unowned: return GeneralRaces.Unowned;
            }
            throw new NotImplementedException("RaceID of " + ((RaceID_X3TCAP)raceID).ToString() + " was not assigned.");
        }
        public override GeneralMainType GetMainType(short mainType)
        {
            switch ((MainType_X3TCAP)mainType)
            {
                case MainType_X3TCAP.Ship: return GeneralMainType.Ship;
                case MainType_X3TCAP.Sun: return GeneralMainType.Sun;
                case MainType_X3TCAP.Sector: return GeneralMainType.Sector;
                case MainType_X3TCAP.Planet: return GeneralMainType.Planet;
                case MainType_X3TCAP.Dock: return GeneralMainType.Dock;
                case MainType_X3TCAP.Shield: return GeneralMainType.Shield;
                case MainType_X3TCAP.Laser: return GeneralMainType.Laser;
                case MainType_X3TCAP.Asteroid: return GeneralMainType.Asteroid;
                case MainType_X3TCAP.Gate: return GeneralMainType.Gate;
                case MainType_X3TCAP.Debris: return GeneralMainType.Debris;
                case MainType_X3TCAP.Factory: return GeneralMainType.Factory;
                case MainType_X3TCAP.Special: return GeneralMainType.Special;
                case MainType_X3TCAP.Bullet: return GeneralMainType.Bullet;
                case MainType_X3TCAP.Missile: return GeneralMainType.Missile;
                case MainType_X3TCAP.Ware_F: return GeneralMainType.Ware_F;
                case MainType_X3TCAP.Ware_T: return GeneralMainType.Ware_T;
                case MainType_X3TCAP.Ware_E: return GeneralMainType.Ware_E;
                case MainType_X3TCAP.Ware_B: return GeneralMainType.Ware_B;
                case MainType_X3TCAP.Type_27: return GeneralMainType.UnknownType_27;
                case MainType_X3TCAP.Background: return GeneralMainType.Background;
                case MainType_X3TCAP.Ware_N: return GeneralMainType.Ware_N;
                case MainType_X3TCAP.Ware_M: return GeneralMainType.Ware_M;
                case MainType_X3TCAP.Camera: return GeneralMainType.Camera;
                case MainType_X3TCAP.Type_21: return GeneralMainType.UnknownType_21;
                case MainType_X3TCAP.Type_22: return GeneralMainType.UnknownType_22;
                case MainType_X3TCAP.Type_23: return GeneralMainType.UnknownType_23;
                case MainType_X3TCAP.Type_24: return GeneralMainType.UnknownType_24;
                case MainType_X3TCAP.Cockpit: return GeneralMainType.Cockpit;
                case MainType_X3TCAP.Type_26: return GeneralMainType.UnknownType_26;
                case MainType_X3TCAP.Wreck: return GeneralMainType.Wreck;
                case MainType_X3TCAP.Factory_Wreck: return GeneralMainType.Factory_Wreck;
                case MainType_X3TCAP.Ship_Wreck: return GeneralMainType.Ship_Wreck;
            }
            throw new NotImplementedException("MainType of " + ((MainType_X3TCAP)mainType).ToString() + " was not assigned.");
        }

        public override short GetMainTypeID(GeneralMainType mainType)
        {
            switch (mainType)
            {
                case GeneralMainType.Ship: return (short)MainType_X3TCAP.Ship;
                case GeneralMainType.Sector: return (short)MainType_X3TCAP.Sector;
            }
            throw new NotImplementedException("MainType of " + (mainType).ToString() + " was not assigned.");
        }

    }
}
