using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using X2Tools.X2.SectorObjects;
using CommonToolLib;
using CommonToolLib.Memory;

namespace X2Tools.X2
{
    public class GameCodeRunner
    {
        public const int RefreshRate = 10;

        private readonly EventManager.GameCode m_ObjectCreationInjection = new EventManager.GameCode(ScriptAssembler.SystemModDirectory + "ObjectCreation.x2code");
        private readonly EventManager.GameCode m_ObjectDestroyInjection = new EventManager.GameCode(ScriptAssembler.SystemModDirectory + "ObjectDestroy.x2code");
        private readonly EventManager.GameCode m_ObjectClaimInjection = new EventManager.GameCode(ScriptAssembler.SystemModDirectory + "ObjectClaim.x2code");
        private readonly EventManager.GameCode m_ObjectDockInjection = new EventManager.GameCode(ScriptAssembler.SystemModDirectory + "ObjectDock.x2code");
        public IntPtr pObjectCreationInjection { get; private set; }
        public IntPtr pObjectDestroyInjection { get; private set; }
        public IntPtr pObjectClaimInjection { get; private set; }
        public IntPtr pObjectDockInjection { get; private set; }

        private GameHook GameHook;
        public GameCodeRunner(GameHook gameHook)
        {
            GameHook = gameHook;

            // Subscribe all scripts

            pObjectCreationInjection =  GameHook.EventManager.Subscribe("OnGameTick", m_ObjectCreationInjection);
            pObjectDestroyInjection = GameHook.EventManager.Subscribe("OnGameTick", m_ObjectDestroyInjection);
            pObjectClaimInjection = GameHook.EventManager.Subscribe("OnGameTick", m_ObjectClaimInjection);
            pObjectDockInjection = GameHook.EventManager.Subscribe("OnGameTick", m_ObjectDockInjection);
        }

        #region Game functions

        /// <summary>
        /// Creates a sector object with given type.
        /// </summary>
        /// <param name="MainType"></param>
        /// <param name="SubType"></param>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public SectorObject CreateSectorObject(SectorObject.Main_Type MainType, int SubType, SectorObject Parent = null)
        {
            // Wait until available
            while (MemoryControl.ReadInt(GameHook.hProcess, pObjectCreationInjection) != 0)
            {
                Thread.Sleep(RefreshRate);
            }

            // Write the type required
            MemoryControl.Write(GameHook.hProcess, pObjectCreationInjection, BitConverter.GetBytes(SectorObject.ToFullType(MainType, SubType)));

            // Write parent if required
            if (Parent != null)
                MemoryControl.Write(GameHook.hProcess, pObjectCreationInjection + 8, BitConverter.GetBytes((int)Parent.pThis));
            else
                MemoryControl.Write(GameHook.hProcess, pObjectCreationInjection + 8, BitConverter.GetBytes((int)0));

            // Check if type has been written correctly
            var WrittenType = MemoryControl.ReadInt(GameHook.hProcess, pObjectCreationInjection);
            if (WrittenType != SectorObject.ToFullType(MainType, SubType))
            {
                MemoryControl.Write(GameHook.hProcess, pObjectClaimInjection, BitConverter.GetBytes(0));
                throw new Exception(string.Format("Attempted to create incorect type 0x{0} when it should be 0x{1}.", WrittenType.ToString("X"), SectorObject.ToFullType(MainType, SubType).ToString("X")));
            }

            var written = MemoryControl.Read(GameHook.hProcess, pObjectCreationInjection,4);
            // Write to start process
            MemoryControl.Write(GameHook.hProcess, pObjectCreationInjection + 12, new byte[] { 1 });

            IntPtr addr = IntPtr.Zero;

            // Wait for flag to clear
            while (MemoryControl.Read(GameHook.hProcess, pObjectCreationInjection + 12, 4)[0] != 0)
            {
                Thread.Sleep(RefreshRate);
            }
            addr = (IntPtr)MemoryControl.ReadInt(GameHook.hProcess, pObjectCreationInjection + 4);

            if (addr == IntPtr.Zero)
            {
                return null;
            }



            var newSectorObject = new SectorObject();
            newSectorObject.SetLocation(GameHook.hProcess, addr);
            return newSectorObject;
        }
        /// <summary>
        /// Docks a SectorObject to a non sector SectorObject.
        /// Must have no parent.
        /// </summary>
        /// <param name="sectorObject"></param>
        /// <param name="Parent"></param>
        public void DockObject(SectorObject sectorObject, SectorObject Parent)
        {
            // Wait until available
            while (MemoryControl.ReadInt(GameHook.hProcess, pObjectCreationInjection) != 0)
            {
                Thread.Sleep(RefreshRate);
            }

            MemoryControl.Write(GameHook.hProcess, pObjectDockInjection, BitConverter.GetBytes((int)sectorObject.pThis));
            MemoryControl.Write(GameHook.hProcess, pObjectDockInjection + 4, BitConverter.GetBytes((int)Parent.pThis));
        }

        public void DestroyObject(SectorObject sectorObject)
        {
            MemoryControl.Write(GameHook.hProcess, pObjectDestroyInjection, BitConverter.GetBytes((int)sectorObject.pThis));
            MemoryControl.Write(GameHook.hProcess, pObjectDestroyInjection + 4, new byte[] { 1 });
            while(MemoryControl.ReadInt(GameHook.hProcess, pObjectDestroyInjection + 4) != 0)
            {
                Thread.Sleep(RefreshRate);
            }
        }
        public void SetOwnerRace(SectorObject sectorObject, Race race)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Macros
        public void LoadAllObjects(SectorObject.Main_Type MainType)
        {
            int Padding = 1000000;
            int YValue = 1000000;
            int SubMax = 0;
            switch ((SectorObject.Main_Type)MainType)
            {
                // 0 and 8
                case SectorObject.Main_Type.Projectile:
                case SectorObject.Main_Type.ShipGun:
                    SubMax = SectorObject.WEAPON_SUBTYPE_COUNT;
                    break;
                // 1
                // 2
                case SectorObject.Main_Type.Type_2:
                    SubMax = SectorObject.TYPE_2_SUBTYPE_COUNT;
                    break;
                // 3
                case SectorObject.Main_Type.Sun:
                    SubMax = SectorObject.SUN_SUBTYPE_COUNT;
                    break;
                // 4
                case SectorObject.Main_Type.Planet:
                    SubMax = SectorObject.PLANET_SUBTYPE_COUNT;
                    break;
                // 5
                case SectorObject.Main_Type.Dock:
                    SubMax = SectorObject.DOCK_SUBTYPE_COUNT;
                    break;
                // 6
                case SectorObject.Main_Type.Factory:
                    SubMax = SectorObject.FACTORY_SUBTYPE_COUNT;
                    break;
                // 7
                case SectorObject.Main_Type.Ship:
                    SubMax = SectorObject.SHIP_SUBTYPE_COUNT;
                    break;
                // 9
                case SectorObject.Main_Type.Shield:
                    SubMax = SectorObject.SHIELD_SUBTYPE_COUNT;
                    break;
                // 10
                case SectorObject.Main_Type.Missile:
                    SubMax = SectorObject.MISSILE_SUBTYPE_COUNT;
                    break;
                // 11
                case SectorObject.Main_Type.Ware_Energy:
                    SubMax = SectorObject.WARE_ENERGY_SUBTYPE_COUNT;
                    break;
                // 12
                case SectorObject.Main_Type.Ware_Mission:
                    SubMax = SectorObject.WARE_MISSION_SUBTYPE_COUNT;
                    break;
                // 13
                case SectorObject.Main_Type.Ware_Agriculture:
                    SubMax = SectorObject.TYPE_13_SUBTYPE_COUNT;
                    break;
                // 14
                case SectorObject.Main_Type.Ware_Processed:
                    SubMax = SectorObject.WARE_PROCESSED_SUBTYPE_COUNT;
                    break;
                // 15
                case SectorObject.Main_Type.Ware_Ores:
                    SubMax = SectorObject.WARE_ORES_SUBTYPE_COUNT;
                    break;
                // 16
                case SectorObject.Main_Type.Ware_Technology:
                    SubMax = SectorObject.WARE_TECHNOLOGY_SUBTYPE_COUNT;
                    break;
                // 17
                case SectorObject.Main_Type.Asteroid:
                    SubMax = SectorObject.ASTEROID_SUBTYPE_COUNT;
                    break;
                // 18
                case SectorObject.Main_Type.Gate:
                    SubMax = SectorObject.GATE_SUBTYPE_COUNT;
                    break;
                // 19
                case SectorObject.Main_Type.Type_19:
                    SubMax = SectorObject.TYPE_19_SUBTYPE_COUNT;
                    break;
                // 20
                case SectorObject.Main_Type.Miscellaneous:
                    SubMax = SectorObject.MISCELLANEOUS_SUBTYPE_COUNT;
                    break;
                // 21
                case SectorObject.Main_Type.Nebula:
                    SubMax = SectorObject.NEBULA_SUBTYPE_COUNT;
                    break;
                // 22
                case SectorObject.Main_Type.Station_Internal:
                    SubMax = SectorObject.STATION_INTERNAL_SUBTYPE_COUNT;
                    break;
            }

            for(int Sub = 0; Sub < SubMax; Sub++)
            {
                var SO = CreateSectorObject((SectorObject.Main_Type)MainType, Sub, GameHook.SectorObjectManager.GetSpace());
                var data = SO.pData.obj;
                data.Position = new CommonToolLib.Vector.Vector3(((int)MainType) * Padding, YValue, Sub * Padding);
                data.WriteToMemory();
            }

            
        }
        #endregion
    }
}
