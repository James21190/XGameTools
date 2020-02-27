using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;
using X3TCTools.SectorObjects;
using X3TCTools.Bases;
using System.Drawing;

namespace X3TCTools
{
    public class GameHook : ApplicationHook
    {

        #region Pointers
        private MemoryObjectPointer<MemoryObjectPointer<SectorObjectManager>> ppSectorObjectManager;
        private MemoryObjectPointer<MemoryObjectPointer<SystemBase>> ppSystemBase;
        private MemoryObjectPointer<MemoryObjectPointer<StoryBase>> ppStoryBase;
        private MemoryObjectPointer<MemoryObjectPointer<GateSystemObject>> ppGateSystemObject;
        private MemoryObjectPointer<MemoryObjectPointer<TypeData>> ppTypeData;
        private MemoryObjectPointer<MemoryObjectPointer<InputBase>> ppInputBase;
        private MemoryObjectPointer<MemoryObjectPointer<CameraBase>> ppCameraBase;
        #endregion

        #region Pointer Objects
        /// <summary>
        /// An up to date representation of the game's SectorObjectManager.
        /// </summary>
        public SectorObjectManager sectorObjectManager { get { return ppSectorObjectManager.obj.obj; } }
        /// <summary>
        /// An up to date representation of the game's SystemBase.
        /// </summary>
        public SystemBase systemBase { get { return ppSystemBase.obj.obj; } }
        /// <summary>
        /// An up to date representation of the game's GateSystemObject.
        /// </summary>
        public GateSystemObject gateSystemObject { get { return ppGateSystemObject.obj.obj; } }
        /// <summary>
        /// An up to date representation of the game's StoryBase.
        /// </summary>
        public StoryBase storyBase { get { return ppStoryBase.obj.obj; } }

        public InputBase inputBase { get { return ppInputBase.obj.obj; } }
        public CameraBase cameraBase { get { return ppCameraBase.obj.obj; } }

        public TypeData GetTypeData(int MainType, int SubType)
        {
            return ppTypeData.GetObjectInArray(MainType).GetObjectInArray(SubType);
        }

        #endregion
        /// <summary>
        /// The object responsible for managing code that can be executed by the game.
        /// </summary>
        public GameCodeRunner gameCodeRunner { private set; get; }
        public EventManager eventManager { private set; get; }

        public readonly GameVersion gameVersion;

        public GameHook(Process process, GameVersion gameVersion)
        {
            this.gameVersion = gameVersion;
            // Get a handle to the process
            HookIntoProcess(process);

            switch (gameVersion) {
                case GameVersion.X3TC:
                    // Create references to MemoryObjects
                    ppSectorObjectManager = new MemoryObjectPointer<MemoryObjectPointer<SectorObjectManager>>(hProcess, (IntPtr)GlobalAddressesX3TC.pSectorObjectManager);
                    ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pStoryBase);
                    ppSystemBase = new MemoryObjectPointer<MemoryObjectPointer<SystemBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pSystemBase);
                    ppGateSystemObject = new MemoryObjectPointer<MemoryObjectPointer<GateSystemObject>>(hProcess, (IntPtr)GlobalAddressesX3TC.pGateSystemObject);
                    ppTypeData = new MemoryObjectPointer<MemoryObjectPointer<TypeData>>(hProcess, (IntPtr)GlobalAddressesX3TC.pTypeData);
                    ppInputBase = new MemoryObjectPointer<MemoryObjectPointer<InputBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pInputBase);
                    ppCameraBase = new MemoryObjectPointer<MemoryObjectPointer<CameraBase>>(hProcess, (IntPtr)GlobalAddressesX3TC.pCameraBase);

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
                //case GameVersion.X3AP:
                //    // Create references to MemoryObjects
                //    ppSectorObjectManager = new MemoryObjectPointer<MemoryObjectPointer<SectorObjectManager>>(hProcess, (IntPtr)GlobalAddressesX3AP.pSectorObjectManager);
                //    ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pStoryBase);
                //    //ppSystemBase = new MemoryObjectPointer<MemoryObjectPointer<SystemBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pSystemBase);
                //    //ppGateSystemObject = new MemoryObjectPointer<MemoryObjectPointer<GateSystemObject>>(hProcess, (IntPtr)GlobalAddressesX3AP.pGateSystemObject);
                //    //ppTypeData = new MemoryObjectPointer<MemoryObjectPointer<TypeData>>(hProcess, (IntPtr)GlobalAddressesX3AP.pTypeData);
                //    ppInputBase = new MemoryObjectPointer<MemoryObjectPointer<InputBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pInputBase);
                //    //ppCameraBase = new MemoryObjectPointer<MemoryObjectPointer<CameraBase>>(hProcess, (IntPtr)GlobalAddressesX3AP.pCameraBase);

                //    //// Create events
                //    //eventManager = new EventManager(hProcess);
                //    //eventManager.CreateNewEvent("OnGameTick", (IntPtr)0x00404acc, new byte[] {
                //    //// MOV EAX 0x004b1370
                //    //0xB8, 0x70, 0x13, 0x4B, 0x00,
                //    //// CALL EAX
                //    //0xFF, 0xD0,
                //    //// MOV EAX 0x004D2D90
                //    //0xB8, 0x90, 0x2D, 0x4D, 0x00,
                //    //// CALL EAX
                //    //0xFF, 0xD0,
                //    //// RET
                //    //0xC3
                //    //}, 3);

                //    break;
                default: throw new NotImplementedException(string.Format("{0} game version is not currently supported.", gameVersion));
            }
            

        }

        ~GameHook()
        {
            if (hProcess != IntPtr.Zero)
                Unhook();
        }

        public void InitGameCodeRunner()
        {
            gameCodeRunner = new GameCodeRunner(this);
        }

        public enum GlobalAddressesX3TC
        {
            pSystemBase =           0x00603064,
            pGateSystemObject =     0x00604634,
            pSectorObjectManager =  0x00604640,
            pCockpitBase =          0x00604638,
            pStoryBase =            0x00604718,
            pTypeData =             0x006030e8,
            pInputBase =            0x0057FDA0,
            pCameraBase =           0x0060464c,
        }

        public enum GlobalAddressesX3AP
        {
            //pSystemBase = 0,
            //pGateSystemObject = 0,
            pSectorObjectManager = 0x60a6e0,
            //pCockpitBase = 0,
            pStoryBase = 0x60a7b8,
            //pTypeData = 0,
            pInputBase = 0x581e30,
            //pCameraBase = 0,
        }
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

        public enum GameVersion
        {
            X3TC,
            X3AP
        }
    }
}
