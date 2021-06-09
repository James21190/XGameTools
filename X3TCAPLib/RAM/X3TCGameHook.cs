using CommonToolLib.Memory;
using System;
using System.Diagnostics;
using X3TCAPLib.RAM.Bases.Sector;
using X3TCAPLib.RAM.Bases.Story;
using X3TCAPLib.RAM.Bases.B3D;
using X3TCAPLib.RAM.Bases.Galaxy;
using XCommonLib.RAM;
using X3TCAPLib.RAM.Bases.Sector.SectorObject_TypeData;

namespace X3TCAPLib.RAM
{
    public class X3TCGameHook : GameHook
    {
        public enum RaceID : ushort
        {
            NA,
            Argon,
            Boron,
            Split,
            Paranid,
            Teladi,
            Xenon,
            Khaak,
            Pirate,
            Gonor,
            Player,

            Unowned = 12,
            Friendly,
            Unknown,

            ATF = 17,
            Terran,
            Yaki,
            None = 65535
        }

        public enum MainType
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

            Cockpit = 25,

            Debris = 28,
            Wreck,
            Factory_Wreck,
            Ship_Wreck
        }

        public enum GlobalAddressesX3TC
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
        #endregion

        #region TypeData
        public override int TypeData_Ship_Count => pTypeData_CountArr.GetObjectInArray((int)MainType.Ship).Value;
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship GetTypeData_Ship(int subType)
        {
            return ppTypeData_Ship.obj.GetObjectInArray(subType);
        }
        #endregion

        public X3TCGameHook(Process process)
        {
            HookIntoProcess(process);

            #region Bases
            ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pSectorBase);
            ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pStoryBase);
            ppGalaxyBase = new MemoryObjectPointer<MemoryObjectPointer<GalaxyBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pGalaxyBase);
            ppB3DBase = new MemoryObjectPointer<MemoryObjectPointer<B3DBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pB3DBase);
            #endregion

            #region TypeData
            pTypeData_CountArr = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeDataCountArray);
            ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Ship);

            #endregion
        }

        ~X3TCGameHook()
        {
            Unhook();
        }

        public override string GetRaceIDName(ushort id)
        {
            return ((RaceID)id).ToString();
        }
        public override string GetMainTypeName(int id)
        {
            return ((MainType)id).ToString();
        }
    }
}
