using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using X2Tools.X2.TypeData;
using X2Tools.X2.SectorObjects;
using X2Tools.X2;
using CommonToolLib;
using CommonToolLib.Memory;

namespace X2Tools
{
    /// <summary>
    /// The main hook into the game that contains objects useful in manipulating ram.
    /// </summary>
    public class GameHook : ApplicationHook
    {

        /// <summary>
        /// The unit that is considered 1 by the game's fixed point calculations
        /// </summary>
        public const int FixedPointUnit = 65536;
        /// <summary>
        /// The game process handle
        /// </summary>

        #region Pointers
        private MemoryObjectPointer<MemoryObjectPointer<SectorObjectManager>> ppSectorObjectManager;

        #endregion

        /// <summary>
        /// The object responcible for managing SectorObjects
        /// </summary>
        public SectorObjectManager SectorObjectManager
        {
            get { return ppSectorObjectManager.obj.obj; }
        }

        /// <summary>
        /// A collection of the type data in the game's memory
        /// </summary>
        public TypeDataManager TypeDataArray
        {
            private set;
            get;
        }

        public EventManager EventManager { get; private set; }

        public GameCodeRunner GameCodeRunner
        {
            private set;
            get;
        }
        #region Constructors
        public GameHook(Process GameProcess)
        {
            // Get a handle to the process
            HookIntoProcess(GameProcess);

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

            // Setup Pointers
            ppSectorObjectManager = new MemoryObjectPointer<MemoryObjectPointer<SectorObjectManager>>(hProcess, (IntPtr)GlobalAddresses.pSectorObjectManager);

            // Create main objects
            TypeDataArray = new TypeDataManager(hProcess);
            GameCodeRunner = new GameCodeRunner(this);
        }
        #endregion

        #region Destructors
        ~GameHook()
        {
            if(hProcess != null)
                MemoryControl.CloseHandle(hProcess);
        }
        #endregion

        #region Public Methods
        #endregion
    }
}
