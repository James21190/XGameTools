namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.R
{
    public class ScriptMemoryObject_R_Gate : ScriptMemoryObject, IScriptMemoryObject_Gate
    {
        public int DestSectorX => GetVariableValue((int)R_Gate_Variables.Dest_Sector_X);

        public int DestSectorY => GetVariableValue((int)R_Gate_Variables.Dest_Sector_Y);

        public int DestSectorDataScriptingObjectID => GetVariableValue((int)R_Gate_Variables.DestSectorDataScriptingObjectID);
        public ScriptInstance DestSectorDataScriptingObject => GameHook.storyBase.GetScriptingObject(DestSectorDataScriptingObjectID);

        public override string GetVariableName(int index)
        {
            return ((R_Gate_Variables)index).ToString();
        }
        public ScriptMemoryObject_R_Gate() : base(20)
        {

        }
    }
}
