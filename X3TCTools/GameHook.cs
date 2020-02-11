using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;
using X3TCTools.SectorObjects;
using X3TCTools.Bases;

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

        public GameHook(Process process)
        {
            // Get a handle to the process
            HookIntoProcess(process);
            
            // Create references to MemoryObjects
            ppSectorObjectManager = new MemoryObjectPointer<MemoryObjectPointer<SectorObjectManager>>(hProcess,(IntPtr)GlobalAddresses.pSectorObjectManager);
            ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddresses.pStoryBase);
            ppSystemBase = new MemoryObjectPointer<MemoryObjectPointer<SystemBase>>(hProcess, (IntPtr)GlobalAddresses.pSystemBase);
            ppGateSystemObject = new MemoryObjectPointer<MemoryObjectPointer<GateSystemObject>>(hProcess, (IntPtr)GlobalAddresses.pGateSystemObject);
            ppTypeData = new MemoryObjectPointer<MemoryObjectPointer<TypeData>>(hProcess, (IntPtr)GlobalAddresses.pTypeData);
            ppInputBase = new MemoryObjectPointer<MemoryObjectPointer<InputBase>>(hProcess, (IntPtr)GlobalAddresses.pInputBase);

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
            } ,3);

            gameCodeRunner = new GameCodeRunner(this);
        }

        public enum GlobalAddresses
        {
            pSystemBase =           0x00603064,
            pGateSystemObject =     0x00604634,
            pSectorObjectManager =  0x00604640,
            pCockpitBase =          0x00604638,
            pStoryBase =            0x00604718,
            pTypeData =             0x006030e8,
            pInputBase =            0x0057FDA0
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
    }
}
