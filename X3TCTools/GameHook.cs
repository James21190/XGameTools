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
    public class GameHook
    {
        public SectorObjectManager SectorObjectManager { private set; get; }
        public GameCodeRunner GameCodeRunner { private set; get; }
        public EventManager EventManager { private set; get; }
        public SystemBase SystemBase { private set; get; }
        public GateSystemObject gateSystemObject { private set; get; }
        public IntPtr hProcess { private set; get; }

        public GameHook(Process process)
        {
            // Get a handle to the process
            hProcess = MemoryControl.OpenProcess((uint)MemoryControl.ProcessAccessFlags.All, 0, (uint)process.Id);
            EventManager = new EventManager(hProcess);
            // Create events
            EventManager.CreateNewEvent("OnGameTick", (IntPtr)0x00404acc, new byte[] {
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

            SectorObjectManager = new SectorObjectManager(this);
            GameCodeRunner = new GameCodeRunner(this);
            SystemBase = new SystemBase(this);
            gateSystemObject = new GateSystemObject(this);
        }

        public void ReloadAll()
        {
            SystemBase.Reload();
            SectorObjectManager.Reload();
        }

        public enum GlobalAddresses
        {
            SystemBase = 0x00603064,
            GateSystemObject = 0x00604634,
            SectorObjectManager = 0x00604640
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
