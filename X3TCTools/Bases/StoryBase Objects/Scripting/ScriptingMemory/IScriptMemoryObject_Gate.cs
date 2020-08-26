using Common.Memory;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Gate : IMemoryObject
    {
        int DestSectorX { get; }
        int DestSectorY { get; }
    }
}
