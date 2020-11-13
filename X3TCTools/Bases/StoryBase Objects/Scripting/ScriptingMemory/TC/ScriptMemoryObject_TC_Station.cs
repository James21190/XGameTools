﻿using System;
using X3TCTools.Sector_Objects;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Station : ScriptMemoryObject, IScriptMemoryObject_Station
    {
        public new const int VariableCount = 53;

        public int MainType => GetVariableValue((int)TC_Station_Variables.MainType);

        public int SubType => GetVariableValue((int)TC_Station_Variables.SubType);

        public int CurrentSectorEventObjectID => GetVariableValue((int)TC_Station_Variables.CurrentSectorEventObjectID);

        public EventObject CurrentSectorEventObject => GameHook.storyBase.GetEventObject(CurrentSectorEventObjectID);

        public int pCargoHashTable => GetVariable((int)TC_Station_Variables.CargoHashTable).Value;

        public ScriptingHashTableObject CargoHashTable => GetVariable((int)TC_Station_Variables.CargoHashTable).GetAsHashTableObject();

        public CargoEntry[] CargoEntries
        {
            get
            {
                ScriptingHashTableObject cargoItems = CargoHashTable;
                CargoEntry[] entries = new CargoEntry[cargoItems.hashTable.Count];
                int i = 0;
                foreach (DynamicValue id in cargoItems.hashTable.ScanContents())
                {
                    SectorObject.Full_Type entryType = SectorObject.Full_Type.FromInt(id.Value);
                    int entryCapacity = TypeData.GetDockWareCapacity(entryType.MainType, entryType.SubType);
                    entries[i++] = new CargoEntry()
                    {
                        Type = entryType,
                        Count = cargoItems.hashTable.GetObject(id).Value
                    };
                }
                return entries;
            }
        }

        public int OwnerDataEventObjectID => GetVariableValue((int)TC_Station_Variables.OwningRaceDataEventObjectID);
        public EventObject OwnerDataEventObject => GameHook.storyBase.GetEventObject(OwnerDataEventObjectID);

        public override string GetVariableName(int index)
        {
            return ((TC_Station_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Station() : base(VariableCount)
        {

        }
    }
}
