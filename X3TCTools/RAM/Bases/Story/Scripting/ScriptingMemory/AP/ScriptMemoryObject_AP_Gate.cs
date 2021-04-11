namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Gate : ScriptMemoryObject, IScriptMemoryObject_Gate
    {
        public int DestSectorX => GetVariableValue((int)AP_Gate_Variables.Dest_Sector_X);

        public int DestSectorY => GetVariableValue((int)AP_Gate_Variables.Dest_Sector_Y);

        public int DestSectorDataScriptingObjectID => GetVariableValue((int)AP_Gate_Variables.DestSectorDataScriptingObjectID);
        public ScriptInstance DestSectorDataScriptingObject => GameHook.storyBase.GetScriptingObject(DestSectorDataScriptingObjectID);

        public override string GetVariableName(int index)
        {
            return ((AP_Gate_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Gate() : base(20)
        {

        }
    }
}
