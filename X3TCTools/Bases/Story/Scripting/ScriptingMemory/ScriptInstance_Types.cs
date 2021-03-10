﻿using X3Tools.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.Bases.Story.Scripting.ScriptingMemory.AP;
using X3Tools.Bases.Story.Scripting.ScriptingMemory.TC;

namespace X3Tools.Bases.Story.Scripting
{
    public partial class ScriptInstance
    {
        public enum ScriptingObject_Type
        {
            RaceData_0 = 400,
            RaceData_1,
            RaceData_Player,
            RaceData_Pirate,
            RaceData_Gonor,
            RaceData_Khaak,
            RaceData_5,

            Sector = 2001,
            Planet,

            Station_Factory = 2006,

            Sun = 2008,

            Ship_LaserTower = 2011,
            Asteroid,

            Gate = 2014,

            Ship_M1 = 2021,
            Ship_M2,
            Ship_M3,
            Ship_M4,
            Ship_M5,
            Ship_M6,
            Ship_M7,

            Ship_TS = 2031,
            Ship_TL,

            Ship_Goner_Ranger = 2039,

            Headquarters = 2046,

            Ship_Spacefly = 2070,

            Ship_Satellite = 2080,

            Xenon_Hub = 2075,
        }

        public IScriptMemoryObject_Ship GetMemoryInterfaceShip()
        {
            switch(GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Ship>();
                case GameHook.GameVersions.X3AP:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>();
                default:
                    return null;
            }
        }

        public IScriptMemoryObject_RaceData GetMemoryInterfaceRaceData()
        {
            switch(GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_RaceData>();
                case GameHook.GameVersions.X3AP:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>();
                default: 
                    return null;
            }
        }

        public IScriptMemoryObject_RaceData_Player GetMemoryInterfaceRaceData_Player()
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_RaceData_Player>();
                case GameHook.GameVersions.X3AP:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData_Player>();
                default:
                    return null;
            }
        }

        public IScriptMemoryObject_Sector GetMemoryInterfaceSector()
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>();
                case GameHook.GameVersions.X3AP:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>();
                default:
                    return null;
            }
        }

        public IScriptMemoryObject_Gate GetMemoryInterfaceGate()
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Gate>();
                case GameHook.GameVersions.X3AP:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Gate>();
                default:
                    return null;
            }
        }

        public IScriptMemoryObject_Station GetMemoryInterfaceStation()
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Station>();
                case GameHook.GameVersions.X3AP:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Station>();
                default:
                    return null;
            }
        }

        public IScriptMemoryObject_Headquarters GetMemoryInterfaceHeadquarters()
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    return GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Headquarters>();
                case GameHook.GameVersions.X3AP:
                    //return GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Headquarters>();
                default:
                    return null;
            }
        }
    }
}