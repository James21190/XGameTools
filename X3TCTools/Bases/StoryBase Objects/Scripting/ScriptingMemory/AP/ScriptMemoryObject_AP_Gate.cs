namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Gate : ScriptMemoryObject, IScriptMemoryObject_Gate
    {
        public int DestSectorX => GetVariableValue((int)AP_Gate_Variables.Dest_Sector_X);

        public int DestSectorY => GetVariableValue((int)AP_Gate_Variables.Dest_Sector_Y);

        public int DestSectorDataEventObjectID => GetVariableValue((int)AP_Gate_Variables.DestSectorDataEventObjectID);
        public ScriptingObject DestSectorDataEventObject => GameHook.storyBase.GetEventObject(DestSectorDataEventObjectID);

        public override string GetVariableName(int index)
        {
            return ((AP_Gate_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Gate() : base(20)
        {

        }
    }
}
