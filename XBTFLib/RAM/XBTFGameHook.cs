using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.B3D;
using XCommonLib.RAM.Bases.Galaxy;
using XCommonLib.RAM.Bases.Sector;
using XCommonLib.RAM.Bases.Sector.SectorObject_TypeData;
using XCommonLib.RAM.Bases.Story;
using XCommonLib.RAM.Bases.System;

namespace XBTFLib.RAM
{
    public class XBTFGameHook : GameHook
    {
        public override string GameName => "XBTF";

        public override SectorBase SectorBase => ppSectorBase.obj.obj;

        public override StoryBase StoryBase => throw new NotImplementedException();

        public override GalaxyBase GalaxyBase => throw new NotImplementedException();

        public override B3DBase B3DBase => throw new NotImplementedException();

        public override SystemBase SystemBase => throw new NotImplementedException();

        public override short[] TypeData_Counts => throw new NotImplementedException();

        #region Pointers
        public MemoryObjectPointer<MemoryObjectPointer<XBTFLib.RAM.Bases.Sector.SectorBase>> ppSectorBase;
        #endregion


        public XBTFGameHook(Process process)
        {
            HookIntoProcess(process);

            //#region Bases
            ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<XBTFLib.RAM.Bases.Sector.SectorBase>>(this, (IntPtr)GlobalAddresses_XBTF.pSectorBase);
            //ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(this, (IntPtr)GlobalAddresses_X2.pStoryBase);
            //ppB3DBase = new MemoryObjectPointer<MemoryObjectPointer<B3DBase>>(this, (IntPtr)GlobalAddresses_X2.pB3DBase);
            //#endregion
            //
            //#region TypeData
            //pTypeData_CountArr = new MemoryObjectPointer<MemoryInt16>(this, (IntPtr)GlobalAddresses_X2.pTypeDataCountArray);
            //ppTypeData_Bullet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Bullet>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Bullet);
            //ppTypeData_Sector = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Sector>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Sector);
            //ppTypeData_Background = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Background>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Background);
            //ppTypeData_Sun = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Sun>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Sun);
            //ppTypeData_Planet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Planet>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Planet);
            //ppTypeData_Dock = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Dock>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Dock);
            //ppTypeData_Factory = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Factory>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Factory);
            //ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Ship);
            //ppTypeData_Laser = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Laser>>(this, (IntPtr)GlobalAddresses_X2.pTypeData_Laser);
            //#endregion
        }

        public enum MainType_XBTF
        {
        }

        public enum GlobalAddresses_XBTF
        {
            pSectorBase = 0x004ec660
        }

        public override GeneralMainType GetMainType(short mainType)
        {
            throw new NotImplementedException();
        }

        public override short GetMainTypeID(GeneralMainType mainType)
        {
            throw new NotImplementedException();
        }

        public override GeneralRaces GetRaceByID(ushort raceID)
        {
            return GeneralRaces.None;
        }

        public override int GetTypeDataCount_Ship()
        {
            throw new NotImplementedException();
        }

        public override TypeData_Asteroid GetTypeData_Asteroid(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Background GetTypeData_Background(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Bullet GetTypeData_Bullet(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Camera GetTypeData_Camera(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Cockpit GetTypeData_Cockpit(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Debris GetTypeData_Debris(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Dock GetTypeData_Dock(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Factory GetTypeData_Factory(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Factory_Wreck GetTypeData_Factory_Wreck(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Gate GetTypeData_Gate(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Laser GetTypeData_Laser(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Missile GetTypeData_Missile(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Nebula GetTypeData_Nebula(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Planet GetTypeData_Planet(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Sector GetTypeData_Sector(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Shield GetTypeData_Shield(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Ship GetTypeData_Ship(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Ship_Wreck GetTypeData_Ship_Wreck(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Special GetTypeData_Special(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Station_Interior GetTypeData_Station_Interior(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Sun GetTypeData_Sun(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Type_23 GetTypeData_Type_23(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Type_24 GetTypeData_Type_24(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Type_26 GetTypeData_Type_26(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Type_27 GetTypeData_Type_27(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Ware_B GetTypeData_Ware_B(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Ware_E GetTypeData_Ware_E(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Ware_F GetTypeData_Ware_F(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Ware_M GetTypeData_Ware_M(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Ware_N GetTypeData_Ware_N(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Ware_T GetTypeData_Ware_T(int subType)
        {
            throw new NotImplementedException();
        }

        public override TypeData_Wreck GetTypeData_Wreck(int subType)
        {
            throw new NotImplementedException();
        }
    }
}
