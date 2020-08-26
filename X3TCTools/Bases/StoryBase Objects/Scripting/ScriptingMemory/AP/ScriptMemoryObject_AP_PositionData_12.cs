namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_PositionData_12 : ScriptMemoryObject
    {
        public override string GetVariableName(int index)
        {
            return ((AP_PositionData_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_PositionData_12() : base(12)
        {

        }
    }
}
