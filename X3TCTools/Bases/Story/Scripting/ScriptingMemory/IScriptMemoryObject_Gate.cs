using Common.Memory;

namespace X3Tools.Bases.Story.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Gate : IMemoryObject
    {
        int DestSectorX { get; }
        int DestSectorY { get; }
    }
}
