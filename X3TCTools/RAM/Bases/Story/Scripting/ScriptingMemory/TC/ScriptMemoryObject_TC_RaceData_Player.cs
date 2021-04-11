using System;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_RaceData_Player : ScriptMemoryObject, IScriptMemoryObject_RaceData_Player
    {
        public const int VariableCount = 49;

        public GameHook.RaceID RaceID => GameHook.RaceID.Player;
        #region Memory
        public int ASectorScriptingObjectID => throw new NotImplementedException();
        public int pOwnedShipScriptingObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Player_Variables.OwnedShipScriptingObjectIDHashTable);
        public int pOwnedStationScriptingObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Player_Variables.OwnedStationScriptingObjectIDHashTable);
        public int pRaceDataWithSectorsScriptingObjectIDHashTable => throw new NotImplementedException();
        public int pRaceDataScriptingObjectIDHashTable => GetVariableValue((int)TC_RaceData_Player_Variables.RaceDataScriptingObjectIDHashTable);
        public int pOwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();
        public int pOwnedShipyardScriptingObjectIDHashTableObject => throw new NotImplementedException();
        public int Credits => GetVariableValue((int)TC_RaceData_Player_Variables.CreditBalance);
        public int SecondsElapsed => GetVariableValue((int)TC_RaceData_Player_Variables.SecondsElapsed);
        public int TradeRank => GetVariableValue((int)TC_RaceData_Player_Variables.TradeRank);
        public int FightRank => GetVariableValue((int)TC_RaceData_Player_Variables.FightRank);
        #endregion


        #region Script Objects
        public ScriptInstance ASectorScriptingObject => throw new NotImplementedException();
        public ScriptTableObject OwnedShipScriptingObjectIDHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr) pOwnedShipScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; }}
        public ScriptTableObject OwnedStationScriptingObjectIDHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr) pOwnedStationScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; }}
        public ScriptTableObject RaceDataWithSectorsScriptingObjectIDHashTable => throw new NotImplementedException();
        public ScriptTableObject RaceDataScriptingObjectIDHashTable { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataScriptingObjectIDHashTable); table.ReloadFromMemory(); return table; } }
        public ScriptTableObject OwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();
        public ScriptTableObject OwnedShipyardScriptingObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptInstance[] Ships
        {
            get
            {
                ScriptInstance[] ships = new ScriptInstance[OwnedShipScriptingObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue shipID in OwnedShipScriptingObjectIDHashTableObject.hashTable.ScanContents())
                {
                    ships[i++] = GameHook.storyBase.GetScriptingObject(shipID.Value);
                }
                return ships;
            }
        }

        public ScriptInstance[] Stations
        {
            get
            {
                ScriptInstance[] stations = new ScriptInstance[OwnedStationScriptingObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue stationID in OwnedStationScriptingObjectIDHashTableObject.hashTable.ScanContents())
                {
                    stations[i++] = GameHook.storyBase.GetScriptingObject(stationID.Value);
                }
                return stations;
            }
        }

        public ScriptInstance[] Races
        {
            get
            {
                ScriptInstance[] races = new ScriptInstance[RaceDataScriptingObjectIDHashTable.hashTable.Count];
                int i = 0;
                foreach (DynamicValue raceID in RaceDataScriptingObjectIDHashTable.hashTable.ScanContents())
                {
                    races[i++] = GameHook.storyBase.GetScriptingObject(raceID.Value);
                }
                return races;
            }
        }

        public int TimeOfLastInput => GetVariableValue((int)TC_RaceData_Player_Variables.TimeOfLastInput);

        #endregion
        public override string GetVariableName(int index)
        {
            return ((TC_RaceData_Player_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_RaceData_Player() : base(VariableCount)
        {

        }
    }
}
