namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData_Player : IScriptMemoryObject_RaceData
    {
        int Credits { get; }
        int SecondsElapsed { get; }
        int TradeRank { get; }
        int FightRank { get; }
        int pRaceDataWithSectorsScriptingObjectIDHashTable { get; }
        ScriptingHashTableObject RaceDataWithSectorsScriptingObjectIDHashTable { get; }
        int pRaceDataScriptingObjectIDHashTable { get; }
        ScriptingHashTableObject RaceDataScriptingObjectIDHashTable { get; }
        ScriptingObject[] Races { get; }
    }
}
