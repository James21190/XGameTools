using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
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
        public ScriptingObject ASectorScriptingObject => throw new NotImplementedException();
        public ScriptingHashTableObject OwnedShipScriptingObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr) pOwnedShipScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; }}
        public ScriptingHashTableObject OwnedStationScriptingObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr) pOwnedStationScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; }}
        public ScriptingHashTableObject RaceDataWithSectorsScriptingObjectIDHashTable => throw new NotImplementedException();
        public ScriptingHashTableObject RaceDataScriptingObjectIDHashTable { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataScriptingObjectIDHashTable); table.ReloadFromMemory(); return table; } }
        public ScriptingHashTableObject OwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();
        public ScriptingHashTableObject OwnedShipyardScriptingObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingObject[] Ships
        {
            get
            {
                ScriptingObject[] ships = new ScriptingObject[OwnedShipScriptingObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue shipID in OwnedShipScriptingObjectIDHashTableObject.hashTable.ScanContents())
                {
                    ships[i++] = GameHook.storyBase.GetScriptingObject(shipID.Value);
                }
                return ships;
            }
        }

        public ScriptingObject[] Stations
        {
            get
            {
                ScriptingObject[] stations = new ScriptingObject[OwnedStationScriptingObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue stationID in OwnedStationScriptingObjectIDHashTableObject.hashTable.ScanContents())
                {
                    stations[i++] = GameHook.storyBase.GetScriptingObject(stationID.Value);
                }
                return stations;
            }
        }

        public ScriptingObject[] Races
        {
            get
            {
                ScriptingObject[] races = new ScriptingObject[RaceDataScriptingObjectIDHashTable.hashTable.Count];
                int i = 0;
                foreach (DynamicValue raceID in RaceDataScriptingObjectIDHashTable.hashTable.ScanContents())
                {
                    races[i++] = GameHook.storyBase.GetScriptingObject(raceID.Value);
                }
                return races;
            }
        }

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
