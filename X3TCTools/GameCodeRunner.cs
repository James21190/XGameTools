using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Memory;
using X3TCTools.SectorObjects;
using X3TCTools.SectorObjects.Meta;

namespace X3TCTools
{
    public class GameCodeRunner
    {
        private GameHook m_GameHook;

        private const int WaitTime = 10;

        private IntPtr pCreateObjectInjection;

        public GameCodeRunner(GameHook gameHook)
        {
            m_GameHook = gameHook;

            switch (GameHook.GameVersion) {
                case GameHook.GameVersions.X3TC:
                pCreateObjectInjection = m_GameHook.eventManager.Subscribe("OnGameTick", new EventManager.GameCode(".\\Mods\\System\\CreateObject.x3tccode"));
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
            if(pCreateObjectInjection == IntPtr.Zero)
            {
                throw new Exception("CreateObject code injection not found.");
            }

            if(parent != null)
                MemoryControl.Write(m_GameHook.hProcess, pCreateObjectInjection + 4, BitConverter.GetBytes((int)parent.pThis));
            MemoryControl.Write(m_GameHook.hProcess, pCreateObjectInjection, BitConverter.GetBytes((int)SectorObject.ToFullType(mainType, subType)));

            MemoryControl.Write(m_GameHook.hProcess, pCreateObjectInjection + 12, BitConverter.GetBytes((int)1));

            while (MemoryControl.ReadInt(m_GameHook.hProcess, pCreateObjectInjection + 12) != 0)
                Thread.Sleep(WaitTime);

            var result = new SectorObject();
            result.SetLocation(m_GameHook.hProcess, (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, pCreateObjectInjection + 8));

            return result;
        }
    }
}
