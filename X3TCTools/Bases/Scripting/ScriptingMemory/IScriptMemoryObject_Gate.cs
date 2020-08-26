using Common.Memory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Gate : IMemoryObject
    {
        int DestSectorX { get; }
        int DestSectorY { get; }
    }
}
