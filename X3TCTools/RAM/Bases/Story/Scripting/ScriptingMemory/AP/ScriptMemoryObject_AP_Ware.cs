﻿namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Ware : ScriptMemoryObject//, IScriptMemoryObject_Ware
    {
        public override string GetVariableName(int index)
        {
            return ((AP_Ware_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Ware() : base(12)
        {

        }
    }
}