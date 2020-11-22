using System;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_RaceData_Player : ScriptMemoryObject, IScriptMemoryObject_RaceData_Player
    {
        public const int VariableCount = 49;

        public GameHook.RaceID RaceID => GameHook.RaceID.Player;

        public int ASectorEventObjectID => throw new NotImplementedException();

        public ScriptingObject ASectorEventObject => throw new NotImplementedException();

        public int pOwnedShipEventObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Player_Variables.OwnedShipEventObjectIDHashTable);

        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr) pOwnedShipEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; }}

        public int pOwnedStationEventObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Player_Variables.OwnedStationEventObjectIDHashTable);

        public ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr) pOwnedStationEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; }}

        public int pRaceDataWithSectorsEventObjectIDHashTable => throw new NotImplementedException();

        public ScriptingHashTableObject RaceDataWithSectorsEventObjectIDHashTable => throw new NotImplementedException();

        public int pRaceDataEventObjectIDHashTable => GetVariableValue((int)TC_RaceData_Player_Variables.RaceDataEventObjectIDHashTable);

        public ScriptingHashTableObject RaceDataEventObjectIDHashTable { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataEventObjectIDHashTable); table.ReloadFromMemory(); return table; } }

        public int pOwnedSectorEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedSectorEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedShipyardEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedShipyardEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingObject[] Ships
        {
            get
            {
                ScriptingObject[] ships = new ScriptingObject[OwnedShipEventObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue shipID in OwnedShipEventObjectIDHashTableObject.hashTable.ScanContents())
                {
                    ships[i++] = GameHook.storyBase.GetEventObject(shipID.Value);
                }
                return ships;
            }
        }

        public ScriptingObject[] Stations
        {
            get
            {
                ScriptingObject[] stations = new ScriptingObject[OwnedStationEventObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue stationID in OwnedStationEventObjectIDHashTableObject.hashTable.ScanContents())
                {
                    stations[i++] = GameHook.storyBase.GetEventObject(stationID.Value);
                }
                return stations;
            }
        }

        public ScriptingObject[] Races
        {
            get
            {
                ScriptingObject[] races = new ScriptingObject[RaceDataEventObjectIDHashTable.hashTable.Count];
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
            return ((TC_RaceData_Player_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_RaceData_Player() : base(VariableCount)
        {

        }
    }
}
