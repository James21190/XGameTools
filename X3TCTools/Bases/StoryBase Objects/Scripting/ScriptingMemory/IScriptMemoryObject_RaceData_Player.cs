namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData_Player : IScriptMemoryObject_RaceData
    {
        int Credits { get; }
        int SecondsElapsed { get; }
        int TimeOfLastInput { get; }
        int TradeRank { get; }
        int FightRank { get; }
        int pRaceDataWithSectorsScriptingObjectIDHashTable { get; }
        ScriptTableObject RaceDataWithSectorsScriptingObjectIDHashTable { get; }
        int pRaceDataScriptingObjectIDHashTable { get; }
        ScriptTableObject RaceDataScriptingObjectIDHashTable { get; }
        ScriptInstance[] Races { get; }
    }
}
