namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData_Player : IScriptMemoryObject_RaceData
    {
        int pRaceDataWithSectorsEventObjectIDHashTable { get; }
        ScriptingHashTableObject RaceDataWithSectorsEventObjectIDHashTable { get; }
        int pRaceDataEventObjectIDHashTable { get; }
        ScriptingHashTableObject RaceDataEventObjectIDHashTable { get; }

        ScriptingObject[] Races { get; }
    }
}
