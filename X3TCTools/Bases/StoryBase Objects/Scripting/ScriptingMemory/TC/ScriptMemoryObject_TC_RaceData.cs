using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_RaceData : ScriptMemoryObject, IScriptMemoryObject_RaceData
    {
        public const int VariableCount = 9;

        public int ASectorEventObjectID => GetVariableValue((int)TC_RaceData_Variables.ASectorEventObjectID);
        public ScriptingObject ASectorEventObject => GameHook.storyBase.GetEventObject(ASectorEventObjectID);

        public int pOwnedShipEventObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Variables.OwnedShipEventObjectIDHashTable);
        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }


        public GameHook.RaceID RaceID => (GameHook.RaceID)GetVariableValue((int)TC_RaceData_Variables.RaceID);

        public int pOwnedStationEventObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Variables.OwnedStationEventObjectIDHashTable);

        public ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedStationEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }

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
                foreach (DynamicValue shipID in OwnedStationEventObjectIDHashTableObject.hashTable.ScanContents())
                {
                    stations[i++] = GameHook.storyBase.GetEventObject(shipID.Value);
                }
                return stations;
            }
        }

        public override string GetVariableName(int index)
        {
            return ((TC_RaceData_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_RaceData() : base(VariableCount)
        {

        }
    }
}
