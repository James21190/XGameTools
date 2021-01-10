using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_RaceData : ScriptMemoryObject, IScriptMemoryObject_RaceData
    {
        public const int VariableCount = 9;

        public int ASectorScriptingObjectID => GetVariableValue((int)AP_RaceData_Variables.ASectorScriptingObjectID);
        public ScriptInstance ASectorScriptingObject => GameHook.storyBase.GetScriptingObject(ASectorScriptingObjectID);

        public int pOwnedShipScriptingObjectIDHashTableObject => GetVariableValue((int)AP_RaceData_Variables.OwnedShipScriptingObjectIDHashTable);
        public ScriptTableObject OwnedShipScriptingObjectIDHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }

        public int pOwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptTableObject OwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedShipyardScriptingObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptTableObject OwnedShipyardScriptingObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedStationScriptingObjectIDHashTableObject => GetVariableValue((int)AP_RaceData_Variables.OwnedStationScriptingObjectIDHashTable);

        public ScriptTableObject OwnedStationScriptingObjectIDHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedStationScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }

        public GameHook.RaceID RaceID => (GameHook.RaceID)GetVariableValue((int)AP_RaceData_Variables.RaceID);


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

        public override string GetVariableName(int index)
        {
            return ((AP_RaceData_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_RaceData() : base(VariableCount)
        {

        }
    }
}
