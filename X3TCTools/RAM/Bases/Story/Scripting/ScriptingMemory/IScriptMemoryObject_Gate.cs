using Common.Memory;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Gate : IMemoryObject
    {
        int DestSectorX { get; }
        int DestSectorY { get; }
    }
}
