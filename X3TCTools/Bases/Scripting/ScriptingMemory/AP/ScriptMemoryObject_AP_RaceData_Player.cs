using System;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_RaceData_Player : ScriptMemoryObject, IScriptMemoryObject_RaceData_Player
    {
        public const int VariableCount = 49;

        public GameHook.RaceID RaceID => GameHook.RaceID.Player;

        public int ASectorEventObjectID => throw new NotImplementedException();

        public EventObject ASectorEventObject => throw new NotImplementedException();

        public int pOwnedShipEventObjectIDHashTableObject => GetVariableValue((int)AP_RaceData_Player_Variables.OwnedShipEventObjectIDHashTable);
        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }


        public int pOwnedStationEventObjectIDHashTableObject => GetVariableValue((int)AP_RaceData_Player_Variables.OwnedStationEventObjectIDHashTable);
        public ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedStationEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }

        public int pRaceDataWithSectorsEventObjectIDHashTable => GetVariableValue((int)AP_RaceData_Player_Variables.RaceDataWithSectorEventObjectIDHashTable);

        public ScriptingHashTableObject RaceDataWithSectorsEventObjectIDHashTable { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataWithSectorsEventObjectIDHashTable); table.ReloadFromMemory(); return table; } }

        public int pRaceDataEventObjectIDHashTable => GetVariableValue((int)AP_RaceData_Player_Variables.RaceDataEventObjectIDHashTable);

        public ScriptingHashTableObject RaceDataEventObjectIDHashTable { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataEventObjectIDHashTable); table.ReloadFromMemory(); return table; } }

        public int pOwnedSectorEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedSectorEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedShipyardEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedShipyardEventObjectIDHashTableObject => throw new NotImplementedException();

        public EventObject[] Ships
        {
            get
            {
                EventObject[] ships = new EventObject[OwnedShipEventObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue shipID in OwnedShipEventObjectIDHashTableObject.hashTable.ScanContents())
                {
                    ships[i++] = GameHook.storyBase.GetEventObject(shipID.Value);
                }
                return ships;
            }
        }

        public EventObject[] Stations
        {
            get
            {
                EventObject[] stations = new EventObject[OwnedStationEventObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue shipID in OwnedStationEventObjectIDHashTableObject.hashTable.ScanContents())
                {
                    stations[i++] = GameHook.storyBase.GetEventObject(shipID.Value);
                }
                return stations;
            }
        }

        public EventObject[] Races
        {
            get
            {
                EventObject[] races = new EventObject[RaceDataEventObjectIDHashTable.hashTable.Count];
                int i = 0;
                foreach (DynamicValue raceID in RaceDataEventObjectIDHashTable.hashTable.ScanContents())
                {
                    races[i++] = GameHook.storyBase.GetEventObject(raceID.Value);
                }
                return races;
            }
        }

        public override string GetVariableName(int index)
        {
            return ((AP_RaceData_Player_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_RaceData_Player() : base(VariableCount)
        {

        }
    }
}
