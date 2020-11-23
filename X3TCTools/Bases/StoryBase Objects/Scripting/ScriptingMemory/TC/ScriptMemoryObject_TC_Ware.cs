namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Ware : ScriptMemoryObject//, IScriptMemoryObject_Ware
    {
        public override string GetVariableName(int index)
        {
            return ((TC_Ware_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Ware() : base(12)
        {

        }
    }
}
