﻿using CommonToolLib.Memory;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using X3Tools.RAM.Bases.B3D;
using X3Tools.RAM.Bases.Galaxy;
using X3Tools.RAM.Bases.Input;
using X3Tools.RAM.Bases.Sector;
using X3Tools.RAM.Bases.Story;
using X3Tools.RAM.Bases.SystemBase_Objects;

namespace X3Tools.RAM
{
    public class GameHook : ApplicationHook
    {

        #region Pointers
        private static MemoryObjectPointer<MemoryObjectPointer<SectorBase>> ppSectorBase;
        private static MemoryObjectPointer<MemoryObjectPointer<SystemBase>> ppSystemBase;
        private static MemoryObjectPointer<MemoryObjectPointer<StoryBase>> ppStoryBase;
        private static MemoryObjectPointer<MemoryObjectPointer<GalaxyBase>> ppGalaxyBase;
        #region TypeData
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Bullet>> ppTypeData_Bullet;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData>> ppTypeData_1;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Background>> ppTypeData_Background;

        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Sun>> ppTypeData_Sun;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Planet>> ppTypeData_Planet;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Dock>> ppTypeData_Dock;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Factory>> ppTypeData_Factory;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>> ppTypeData_Ship;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Laser>> ppTypeData_Laser;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Shield>> ppTypeData_Shield;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_Missile>> ppTypeData_10;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_11>> ppTypeData_11;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_12>> ppTypeData_12;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_13>> ppTypeData_13;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_14>> ppTypeData_14;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_15>> ppTypeData_15;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_16>> ppTypeData_16;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_17>> ppTypeData_17;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_18>> ppTypeData_18;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_19>> ppTypeData_19;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_20>> ppTypeData_20;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_21>> ppTypeData_21;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_22>> ppTypeData_22;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_23>> ppTypeData_23;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_24>> ppTypeData_24;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_25>> ppTypeData_25;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_26>> ppTypeData_26;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_27>> ppTypeData_27;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_28>> ppTypeData_28;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_29>> ppTypeData_29;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_30>> ppTypeData_30;
        private static MemoryObjectPointer<MemoryObjectPointer<TypeData_31>> ppTypeData_31;

        #endregion
        private static MemoryObjectPointer<MemoryObjectPointer<InputBase>> ppInputBase;
        private static MemoryObjectPointer<MemoryObjectPointer<B3DBase>> ppB3DBase;
        private static MemoryObjectPointer<MemoryInt32> pTypeDataCountArray;
        public static MemoryObjectPointer<MemoryByte> pProcessEventSwitchArray;
        public static MemoryObjectPointer<MemoryInt32> pProcessEventSwitch;
        public static MemoryObjectPointer<MemoryInt32> pBytesAllocated;
        public static MemoryObjectPointer<MemoryInt32> pBlocksAllocated;
        #endregion

        #region Pointer Objects
        /// <summary>
        /// An up to date representation of the game's SectorObjectManager.
        /// </summary>
        public static SectorBase sectorObjectManager => ppSectorBase.obj.obj;
        /// <summary>
        /// An up to date representation of the game's SystemBase.
        /// </summary>
        public static SystemBase systemBase => ppSystemBase.obj.obj;
        /// <summary>
        /// An up to date representation of the game's GateSystemObject.
        /// </summary>
        public static GalaxyBase galaxyBase => ppGalaxyBase.obj.obj;
        /// <summary>
        /// An up to date representation of the game's StoryBase.
        /// </summary>
        public static StoryBase storyBase { get { StoryBase sbase = ppStoryBase.obj.obj; return sbase; } }

        public static InputBase inputBase => ppInputBase.obj.obj;
        public static B3DBase b3DBase => ppB3DBase.obj.obj;

        public static TypeData GetTypeData(SectorObject.SectorObjectType type)
        {
            TypeData typeData;
            switch (type.MainTypeEnum)
            {
                case SectorObject.Main_Type.Bullet: typeData = ppTypeData_Bullet.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)1: typeData = ppTypeData_1.obj.GetObjectInArray(type.SubType); break;
                case SectorObject.Main_Type.Background: typeData = ppTypeData_Background.obj.GetObjectInArray(type.SubType); break;

                case SectorObject.Main_Type.Sun: typeData = ppTypeData_Sun.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)4: typeData = ppTypeData_Planet.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)5: typeData = ppTypeData_Dock.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)6: typeData = ppTypeData_Factory.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)7: typeData = ppTypeData_Ship.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)8: typeData = ppTypeData_Laser.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)9: typeData = ppTypeData_Shield.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)10: typeData = ppTypeData_10.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)11: typeData = ppTypeData_11.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)12: typeData = ppTypeData_12.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)13: typeData = ppTypeData_13.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)14: typeData = ppTypeData_14.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)15: typeData = ppTypeData_15.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)16: typeData = ppTypeData_16.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)17: typeData = ppTypeData_17.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)18: typeData = ppTypeData_18.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)19: typeData = ppTypeData_19.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)20: typeData = ppTypeData_20.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)21: typeData = ppTypeData_21.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)22: typeData = ppTypeData_22.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)23: typeData = ppTypeData_23.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)24: typeData = ppTypeData_24.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)25: typeData = ppTypeData_25.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)26: typeData = ppTypeData_26.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)27: typeData = ppTypeData_27.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)28: typeData = ppTypeData_28.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)29: typeData = ppTypeData_29.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)30: typeData = ppTypeData_30.obj.GetObjectInArray(type.SubType); break;
                case (SectorObject.Main_Type)31: typeData = ppTypeData_31.obj.GetObjectInArray(type.SubType); break;

                default: throw new NotImplementedException();
            }

            typeData.ObjectType = type;

            return typeData;
        }

        public static TypeData GetTypeData(int mainType, int subType)
        {
            return GetTypeData(new SectorObject.SectorObjectType(mainType, subType));
        }

        public static TypeData GetTypeData(SectorObject.Main_Type mainType, int subType)
        {
            return GetTypeData(new SectorObject.SectorObjectType(mainType, subType));
        }

        public static int GetTypeDataCount(int MainType)
        {
            return pTypeDataCountArray.GetObjectInArray(MainType).Value;
        }

        #endregion

        /// <summary>
        /// The object responsible for managing code that can be executed by the game.
        /// </summary>
        public static GameCodeRunner gameCodeRunner { private set; get; }
        public static EventManager eventManager { private set; get; }

        private static GameVersions m_GameVersion;
        public static GameVersions GameVersion { get => m_GameVersion; private set { if (m_GameVersion == GameVersions.None) { m_GameVersion = value; } } }

        public static new IntPtr hProcess;

        public static GameHook DefaultHook()
        {
            // Hook into the game memory
            Process processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
            Process processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            Process processX3FL = Process.GetProcessesByName("X3FL").FirstOrDefault();

            if (processX3TC != null)
            {
                return new GameHook(processX3TC, GameHook.GameVersions.X3TC);
            }
            else if (processX3AP != null)
            {
                return new GameHook(processX3AP, GameHook.GameVersions.X3AP);
            }
            else if (processX3FL != null)
            {
                return new GameHook(processX3FL, GameHook.GameVersions.X3FL);
            }

            return null;
        }

        public GameHook(Process process, GameVersions gameVersion)
        {
            if (GameVersion == GameVersions.None)
            {
                GameVersion = gameVersion;
            }
            else if (GameVersion != gameVersion)
            {
                throw new ArgumentException("Game version consistant between game hooks.");
            }
            // Get a handle to the process
            HookIntoProcess(process);
            hProcess = base.hProcess;

            switch (GameVersion)
            {
                #region X3TC
                case GameVersions.X3TC:
                    // Create references to MemoryObjects
                    ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pSectorObjectManager);
                    ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pStoryBase);
                    ppSystemBase = new MemoryObjectPointer<MemoryObjectPointer<SystemBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pSystemBase);
                    ppGalaxyBase = new MemoryObjectPointer<MemoryObjectPointer<GalaxyBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pGateSystemObject);

                    #region TypeData
                    ppTypeData_Bullet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Bullet>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Bullet);
                    ppTypeData_1 = new MemoryObjectPointer<MemoryObjectPointer<TypeData>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_1);
                    ppTypeData_Background = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Background>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Background);

                    ppTypeData_Sun = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Sun>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Sun);
                    ppTypeData_Planet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Planet>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Planet);
                    ppTypeData_Dock = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Dock>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Dock);
                    ppTypeData_Factory = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Factory>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Factory);
                    ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Ship);
                    ppTypeData_Laser = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Laser>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Laser);
                    ppTypeData_Shield = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Shield>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_Shield);
                    ppTypeData_10 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Missile>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_10);
                    ppTypeData_11 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_11>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_11);
                    ppTypeData_12 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_12>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_12);
                    ppTypeData_13 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_13>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_13);
                    ppTypeData_14 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_14>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_14);
                    ppTypeData_15 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_15>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_15);
                    ppTypeData_16 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_16>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_16);
                    ppTypeData_17 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_17>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_17);
                    ppTypeData_18 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_18>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_18);
                    ppTypeData_19 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_19>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_19);
                    ppTypeData_20 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_20>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_20);
                    ppTypeData_21 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_21>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_21);
                    ppTypeData_22 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_22>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_22);
                    ppTypeData_23 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_23>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_23);
                    ppTypeData_24 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_24>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_24);
                    ppTypeData_25 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_25>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_25);
                    ppTypeData_26 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_26>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_26);
                    ppTypeData_27 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_27>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_27);
                    ppTypeData_28 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_28>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_28);
                    ppTypeData_29 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_29>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_29);
                    ppTypeData_30 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_30>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_30);
                    ppTypeData_31 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_31>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData_31);
                    #endregion

                    ppInputBase = new MemoryObjectPointer<MemoryObjectPointer<InputBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pInputBase);
                    ppB3DBase = new MemoryObjectPointer<MemoryObjectPointer<B3DBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pCameraBase);
                    pTypeDataCountArray = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeDataCountArray);
                    pProcessEventSwitchArray = new MemoryObjectPointer<MemoryByte>(hProcess, (IntPtr)GlobalAddressesX3TC.ProcessEventSwitchArray);
                    pProcessEventSwitch = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3TC.ProcessEventSwitch);

                    pBytesAllocated = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3TC.BytesAllocated);
                    //pBlocksAllocated = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3TC.BlocksAllocated);

                    // Create events
                    eventManager = new EventManager(hProcess);
                    eventManager.CreateNewEvent("OnGameTick", (IntPtr)0x00404acc, new byte[] {
                    // MOV EAX 0x004b1370
                    0xB8, 0x70, 0x13, 0x4B, 0x00,
                    // CALL EAX
                    0xFF, 0xD0,
                    // MOV EAX 0x004D2D90
                    0xB8, 0x90, 0x2D, 0x4D, 0x00,
                    // CALL EAX
                    0xFF, 0xD0,
                    // RET
                    0xC3
                    }, 3);
                    break;
                #endregion
                #region X3AP
                case GameVersions.X3AP:
                    // Create references to MemoryObjects
                    ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pSectorObjectManager);
                    ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pStoryBase);
                    ppSystemBase = new MemoryObjectPointer<MemoryObjectPointer<SystemBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pSystemBase);
                    ppGalaxyBase = new MemoryObjectPointer<MemoryObjectPointer<GalaxyBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pGateSystemObject);

                    #region TypeData
                    ppTypeData_Bullet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Bullet>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Bullet);
                    ppTypeData_1 = new MemoryObjectPointer<MemoryObjectPointer<TypeData>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_1);
                    ppTypeData_Background = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Background>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Background);

                    ppTypeData_Sun = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Sun>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Sun);
                    ppTypeData_Planet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Planet>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Planet);
                    ppTypeData_Dock = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Dock>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Dock);
                    ppTypeData_Factory = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Factory>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Factory);
                    ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Ship);
                    ppTypeData_Laser = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Laser>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Laser);
                    ppTypeData_Shield = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Shield>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_Shield);
                    ppTypeData_10 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Missile>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_10);
                    ppTypeData_11 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_11>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_11);
                    ppTypeData_12 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_12>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_12);
                    ppTypeData_13 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_13>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_13);
                    ppTypeData_14 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_14>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_14);
                    ppTypeData_15 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_15>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_15);
                    ppTypeData_16 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_16>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_16);
                    ppTypeData_17 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_17>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_17);
                    ppTypeData_18 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_18>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_18);
                    ppTypeData_19 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_19>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_19);
                    ppTypeData_20 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_20>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_20);
                    ppTypeData_21 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_21>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_21);
                    ppTypeData_22 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_22>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_22);
                    ppTypeData_23 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_23>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_23);
                    ppTypeData_24 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_24>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_24);
                    ppTypeData_25 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_25>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_25);
                    ppTypeData_26 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_26>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_26);
                    ppTypeData_27 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_27>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_27);
                    ppTypeData_28 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_28>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_28);
                    ppTypeData_29 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_29>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_29);
                    ppTypeData_30 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_30>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_30);
                    ppTypeData_31 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_31>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData_31);
                    #endregion

                    ppInputBase = new MemoryObjectPointer<MemoryObjectPointer<InputBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pInputBase);
                    //ppCameraBase = new MemoryObjectPointer<MemoryObjectPointer<CameraBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pCameraBase);
                    pTypeDataCountArray = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeDataCountArray);
                    pProcessEventSwitchArray = new MemoryObjectPointer<MemoryByte>(hProcess, (IntPtr)GlobalAddressesX3AP.ProcessEventSwitchArray);
                    pProcessEventSwitch = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3AP.ProcessEventSwitch);

                    pBytesAllocated = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3AP.BytesAllocated);
                    pBlocksAllocated = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3AP.BlocksAllocated);

                    //// Create events
                    //eventManager = new EventManager(hProcess);
                    //eventManager.CreateNewEvent("OnGameTick", (IntPtr)0x00404acc, new byte[] {
                    //// MOV EAX 0x004b1370
                    //0xB8, 0x70, 0x13, 0x4B, 0x00,
                    //// CALL EAX
                    //0xFF, 0xD0,
                    //// MOV EAX 0x004D2D90
                    //0xB8, 0x90, 0x2D, 0x4D, 0x00,
                    //// CALL EAX
                    //0xFF, 0xD0,
                    //// RET
                    //0xC3
                    //}, 3);

                    break;
                #endregion
                #region X3FL
                case GameVersions.X3FL:
                    // Create references to MemoryObjects
                    ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(hProcess, (IntPtr)GlobalAddressesX3FL.pSectorBase);
                    ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddressesX3FL.pStoryBase);
                    ppSystemBase = new MemoryObjectPointer<MemoryObjectPointer<SystemBase>>(hProcess, (IntPtr)GlobalAddressesX3FL.pSystemBase);
                    //ppGalaxyBase = new MemoryObjectPointer<MemoryObjectPointer<GalaxyBase>>(hProcess, (IntPtr)GlobalAddressesX3FL.pGateSystemObject);

                    #region TypeData
                    //ppTypeData_Bullet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Bullet>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Bullet);
                    //ppTypeData_1 = new MemoryObjectPointer<MemoryObjectPointer<TypeData>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_1);
                    //ppTypeData_Background = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Background>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Background);

                    //ppTypeData_Sun = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Sun>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Sun);
                    //ppTypeData_Planet = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Planet>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Planet);
                    //ppTypeData_Dock = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Dock>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Dock);
                    //ppTypeData_Factory = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Factory>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Factory);
                    //ppTypeData_Ship = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Ship>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Ship);
                    //ppTypeData_Laser = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Laser>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Laser);
                    //ppTypeData_Shield = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Shield>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_Shield);
                    //ppTypeData_10 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_Missile>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_10);
                    //ppTypeData_11 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_11>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_11);
                    //ppTypeData_12 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_12>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_12);
                    //ppTypeData_13 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_13>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_13);
                    //ppTypeData_14 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_14>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_14);
                    //ppTypeData_15 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_15>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_15);
                    //ppTypeData_16 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_16>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_16);
                    //ppTypeData_17 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_17>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_17);
                    //ppTypeData_18 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_18>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_18);
                    //ppTypeData_19 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_19>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_19);
                    //ppTypeData_20 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_20>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_20);
                    //ppTypeData_21 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_21>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_21);
                    //ppTypeData_22 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_22>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_22);
                    //ppTypeData_23 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_23>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_23);
                    //ppTypeData_24 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_24>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_24);
                    //ppTypeData_25 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_25>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_25);
                    //ppTypeData_26 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_26>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_26);
                    //ppTypeData_27 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_27>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_27);
                    //ppTypeData_28 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_28>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_28);
                    //ppTypeData_29 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_29>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_29);
                    //ppTypeData_30 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_30>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_30);
                    //ppTypeData_31 = new MemoryObjectPointer<MemoryObjectPointer<TypeData_31>>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeData_31);
                    #endregion

                    //ppInputBase = new MemoryObjectPointer<MemoryObjectPointer<InputBase>>(hProcess, (IntPtr)GlobalAddressesX3FL.pInputBase);
                    //ppCameraBase = new MemoryObjectPointer<MemoryObjectPointer<CameraBase>>(hProcess, (IntPtr)GlobalAddressesX3FL.pCameraBase);
                    //pTypeDataCountArray = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3FL.pTypeDataCountArray);
                    //pProcessEventSwitchArray = new MemoryObjectPointer<MemoryByte>(hProcess, (IntPtr)GlobalAddressesX3FL.ProcessEventSwitchArray);
                    //pProcessEventSwitch = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3FL.ProcessEventSwitch);

                    //pBytesAllocated = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3FL.BytesAllocated);
                    //pBlocksAllocated = new MemoryObjectPointer<MemoryInt32>(hProcess, (IntPtr)GlobalAddressesX3FL.BlocksAllocated);

                    //// Create events
                    //eventManager = new EventManager(hProcess);
                    //eventManager.CreateNewEvent("OnGameTick", (IntPtr)0x00404acc, new byte[] {
                    //// MOV EAX 0x004b1370
                    //0xB8, 0x70, 0x13, 0x4B, 0x00,
                    //// CALL EAX
                    //0xFF, 0xD0,
                    //// MOV EAX 0x004D2D90
                    //0xB8, 0x90, 0x2D, 0x4D, 0x00,
                    //// CALL EAX
                    //0xFF, 0xD0,
                    //// RET
                    //0xC3
                    //}, 3);

                    break;
                #endregion
                default: throw new GameVersionInvalidException();
            }

            gameCodeRunner = new GameCodeRunner();

        }

        ~GameHook()
        {
            if (hProcess != IntPtr.Zero)
            {
                Unhook();
            }
        }

        public void InitGameCodeRunner()
        {
            gameCodeRunner = new GameCodeRunner();
        }

        public enum Language
        {
            Russian = 7,

            French = 33,
            Spanish,

            Italian = 39,

            Czech = 42,

            English = 44,

            Polish = 48,
            German,

            Japanese = 81,
        }

        #region Global Addresses
        public enum GlobalAddressesX3TC
        {
            pSystemBase = 0x00603064,
            pGateSystemObject = 0x00604634,
            pSectorObjectManager = 0x00604640,
            pCockpitBase = 0x00604638,
            pStoryBase = 0x00604718,
            pInputBase = 0x0057FDA0,
            pCameraBase = 0x0060464c,
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

        public enum GlobalAddressesX3AP
        {
            pSystemBase = 0x00609104,
            pGateSystemObject = 0x0060a6d4,
            pSectorObjectManager = 0x0060a6e0,
            pCockpitBase = 0x0060a6d8,
            pStoryBase = 0x0060a7b8,
            pInputBase = 0x00581e30,
            //pCameraBase = 0,
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

        public enum GlobalAddressesX3FL
        {
            pSystemBase = 0x00cba580,
            //pGateSystemObject = 0x0060a6d4,
            pSectorBase = 0x00cba4bc,
            //pCockpitBase = 0x0060a6d8,
            pStoryBase = 0x00cbc348,
            //pInputBase = 0x00581e30,
            //pCameraBase = 0,
            //ProcessEventSwitchArray = 0x004a5aa8,
            //ProcessEventSwitch = 0x004a58b0,

            #region TypeData
            //pTypeData_Bullet = 0x00609188,
            //pTypeData_1 = 0x0060918c,
            //pTypeData_Background = 0x00609190,
            //pTypeData_Sun = 0x00609194,
            //pTypeData_Planet = 0x00609198,
            //pTypeData_Dock = 0x0060919c,
            //pTypeData_Factory = 0x006091a0,
            //pTypeData_Ship = 0x006091a4,
            //pTypeData_Laser = 0x006091a8,
            //pTypeData_Shield = 0x006091ac,
            //pTypeData_10 = 0x006091b0,
            //pTypeData_11 = 0x006091b4,
            //pTypeData_12 = 0x006091b8,
            //pTypeData_13 = 0x006091bc,
            //pTypeData_14 = 0x006091c0,
            //pTypeData_15 = 0x006091c4,
            //pTypeData_16 = 0x006091c8,
            //pTypeData_17 = 0x006091cc,
            //pTypeData_18 = 0x006091d0,
            //pTypeData_19 = 0x006091d4,
            //pTypeData_20 = 0x006091d8,
            //pTypeData_21 = 0x006091dc,
            //pTypeData_22 = 0x006091e0,
            //pTypeData_23 = 0x006091e4,
            //pTypeData_24 = 0x006091e8,
            //pTypeData_25 = 0x006091ec,
            //pTypeData_26 = 0x006091f0,
            //pTypeData_27 = 0x006091f4,
            //pTypeData_28 = 0x006091f8,
            //pTypeData_29 = 0x006091fc,
            //pTypeData_30 = 0x00609200,
            //pTypeData_31 = 0x00609204,
            //pTypeDataCountArray = 0x00609208,
            #endregion

            //BytesAllocated = 0x0060a7c8,
            //BlocksAllocated = 0x0060abd0,
        }
        #endregion
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

        public static Color GetRaceColor(RaceID race)
        {
            switch (race)
            {
                case RaceID.Argon: return Color.LightBlue;
                case RaceID.ATF: return Color.Gray;
                case RaceID.Boron: return Color.Aqua;
                case RaceID.Friendly: return Color.LightSeaGreen;
                case RaceID.Gonor: return Color.Gold;
                case RaceID.Khaak: return Color.BlueViolet;
                case RaceID.Paranid: return Color.SandyBrown;
                case RaceID.Pirate: return Color.IndianRed;
                case RaceID.Player: return Color.LawnGreen;
                case RaceID.Split: return Color.DarkOrange;
                case RaceID.Teladi: return Color.Green;
                case RaceID.Terran: return Color.SkyBlue;
                case RaceID.Unowned: return Color.Pink;
                case RaceID.Xenon: return Color.Red;
                case RaceID.Yaki: return Color.GreenYellow;
                case RaceID.Unknown: return Color.Honeydew;
                default: return Color.White;
            }
        }

        public enum GameVersions
        {
            None,
            X3TC,
            X3AP,
            X3FL
        }
    }
}
