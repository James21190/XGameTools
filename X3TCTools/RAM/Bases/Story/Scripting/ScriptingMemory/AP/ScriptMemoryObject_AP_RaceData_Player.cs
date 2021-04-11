using System;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_RaceData_Player : ScriptMemoryObject, IScriptMemoryObject_RaceData_Player
    {
        public const int VariableCount = 49;

        public GameHook.RaceID RaceID => GameHook.RaceID.Player;

        public int ASectorScriptingObjectID => throw new NotImplementedException();

        public ScriptInstance ASectorScriptingObject => throw new NotImplementedException();

        public int pOwnedShipScriptingObjectIDHashTableObject => GetVariableValue((int)AP_RaceData_Player_Variables.OwnedShipScriptingObjectIDHashTable);
        public ScriptTableObject OwnedShipScriptingObjectIDHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }


        public int pOwnedStationScriptingObjectIDHashTableObject => GetVariableValue((int)AP_RaceData_Player_Variables.OwnedStationScriptingObjectIDHashTable);
        public ScriptTableObject OwnedStationScriptingObjectIDHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedStationScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }

        public int pRaceDataWithSectorsScriptingObjectIDHashTable => GetVariableValue((int)AP_RaceData_Player_Variables.RaceDataWithSectorScriptingObjectIDHashTable);

        public ScriptTableObject RaceDataWithSectorsScriptingObjectIDHashTable { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataWithSectorsScriptingObjectIDHashTable); table.ReloadFromMemory(); return table; } }

        public int pRaceDataScriptingObjectIDHashTable => GetVariableValue((int)AP_RaceData_Player_Variables.RaceDataScriptingObjectIDHashTable);

        public ScriptTableObject RaceDataScriptingObjectIDHashTable { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataScriptingObjectIDHashTable); table.ReloadFromMemory(); return table; } }

        public int pOwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptTableObject OwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedShipyardScriptingObjectIDHashTableObject => throw new NotImplementedException();

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
                foreach (DynamicValue shipID in OwnedStationScriptingObjectIDHashTableObject.hashTable.ScanContents())
                {
                    stations[i++] = GameHook.storyBase.GetScriptingObject(shipID.Value);
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

        public int Credits => throw new NotImplementedException();

        public int SecondsElapsed => throw new NotImplementedException();

        public int TradeRank => throw new NotImplementedException();

        public int FightRank => throw new NotImplementedException();

        public int TimeOfLastInput => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((AP_RaceData_Player_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_RaceData_Player() : base(VariableCount)
        {

        }
    }
}
