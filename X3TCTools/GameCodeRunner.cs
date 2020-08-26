using Common.Memory;
using System;
using System.Threading;
using X3TCTools.SectorObjects;

namespace X3TCTools
{
    public class GameCodeRunner
    {
        private const int WaitTime = 10;

        private IntPtr pCreateObjectInjection;

        public GameCodeRunner()
        {

            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    pCreateObjectInjection = GameHook.eventManager.Subscribe("OnGameTick", new EventManager.GameCode(".\\Data\\TC\\Mods\\System\\CreateObject.x3tccode"));
                    break;
            }
        }

        /// <summary>
        /// Creates a new SectorObject with specified type. If parent is null, no parent will be set.
        /// </summary>
        /// <param name="mainType"></param>
        /// <param name="subType"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public SectorObject CreateSectorObject(SectorObject.Main_Type mainType, int subType, SectorObject parent = null)
        {
            if (pCreateObjectInjection == IntPtr.Zero)
            {
                throw new Exception("CreateObject code injection not found.");
            }

            if (parent != null)
            {
                MemoryControl.Write(GameHook.hProcess, pCreateObjectInjection + 4, BitConverter.GetBytes((int)parent.pThis));
            }

            MemoryControl.Write(GameHook.hProcess, pCreateObjectInjection, BitConverter.GetBytes(SectorObject.ToFullType(mainType, subType)));

            MemoryControl.Write(GameHook.hProcess, pCreateObjectInjection + 12, BitConverter.GetBytes(1));

            while (MemoryControl.ReadInt(GameHook.hProcess, pCreateObjectInjection + 12) != 0)
            {
                Thread.Sleep(WaitTime);
            }

            SectorObject result = new SectorObject();
            result.SetLocation(GameHook.hProcess, (IntPtr)MemoryControl.ReadInt(GameHook.hProcess, pCreateObjectInjection + 8));

            return result;
        }
    }
}
