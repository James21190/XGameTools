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
    public class X3APGameHook : GameHook
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

        public enum GlobalAddressesX3AP
        {
            pSystemBase = 0x00609104,
            pGalaxyBase = 0x0060a6d4,
            pSectorBase = 0x0060a6e0,
            pCockpitBase = 0x0060a6d8,
            pStoryBase = 0x0060a7b8,
            pInputBase = 0x00581e30,
            //pB3DBase = 0x0060464c,
            ProcessEventSwitchArray = 0x004a5aa8,
            ProcessEventSwitch = 0x004a58b0,

            #region TypeData
            pTypeData_Bullet = 0x00609188,
            pTypeData_1 = 0x0060918c,
            pTypeData_Background = 0x00609190,
            pTypeData_Sun = 0x00609194,
            pTypeData_Planet = 0x00609198,
            pTypeData_Dock = 0x0060919c,
            pTypeData_Factory = 0x006091a0,
            pTypeData_Ship = 0x006091a4,
            pTypeData_Laser = 0x006091a8,
            pTypeData_Shield = 0x006091ac,
            pTypeData_10 = 0x006091b0,
            pTypeData_11 = 0x006091b4,
            pTypeData_12 = 0x006091b8,
            pTypeData_13 = 0x006091bc,
            pTypeData_14 = 0x006091c0,
            pTypeData_15 = 0x006091c4,
            pTypeData_16 = 0x006091c8,
            pTypeData_17 = 0x006091cc,
            pTypeData_18 = 0x006091d0,
            pTypeData_19 = 0x006091d4,
            pTypeData_20 = 0x006091d8,
            pTypeData_21 = 0x006091dc,
            pTypeData_22 = 0x006091e0,
            pTypeData_23 = 0x006091e4,
            pTypeData_24 = 0x006091e8,
            pTypeData_25 = 0x006091ec,
            pTypeData_26 = 0x006091f0,
            pTypeData_27 = 0x006091f4,
            pTypeData_28 = 0x006091f8,
            pTypeData_29 = 0x006091fc,
            pTypeData_30 = 0x00609200,
            pTypeData_31 = 0x00609204,
            pTypeDataCountArray = 0x00609208,
            #endregion

            BytesAllocated = 0x0060a7c8,
            BlocksAllocated = 0x0060abd0,
        }
        public override string GameName => "X3AP";
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

        public X3APGameHook(Process process)
        {
            HookIntoProcess(process);

            #region Bases
            ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pSectorBase);
            ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pStoryBase);
            ppGalaxyBase = new MemoryObjectPointer<MemoryObjectPointer<GalaxyBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pGalaxyBase);
            //ppB3DBase = new MemoryObjectPointer<MemoryObjectPointer<B3DBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pB3DBase);
            #endregion

            #region TypeData
            pTypeData_CountArr = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeDataCountArray);
            ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Ship);

            #endregion
        }

        ~X3APGameHook()
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
