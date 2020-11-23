namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Gate : ScriptMemoryObject, IScriptMemoryObject_Gate
    {
        public int DestSectorX => GetVariableValue((int)TC_Gate_Variables.Dest_Sector_X);

        public int DestSectorY => GetVariableValue((int)TC_Gate_Variables.Dest_Sector_Y);

        public override string GetVariableName(int index)
        {
            return ((TC_Gate_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Gate() : base()
        {

        }
    }
}
