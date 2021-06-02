using System;
using System.Windows.Forms;
using X3Tools.RAM;

using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Displays
{
    public static class DynamicValueContentLoader
    {
        public static Form LoadContent(DynamicValue dynamicValue)
        {
            switch (dynamicValue.Flag)
            {
                case DynamicValue.FlagType.pHashTable:
                    ScriptTableObject hashtableobj = new ScriptTableObject();
                    hashtableobj.SetLocation(GameHook.hProcess, (IntPtr)dynamicValue.Value);
                    hashtableobj.ReloadFromMemory();

                    ScriptTableObjectDisplay display_hash = new ScriptTableObjectDisplay();
                    display_hash.LoadTable(hashtableobj.hashTable.pThis);

                    return display_hash;
                case DynamicValue.FlagType.pArray:
                    ScriptArrayObject arrayObject = new ScriptArrayObject();
                    arrayObject.SetLocation(GameHook.hProcess, (IntPtr)dynamicValue.Value);
                    arrayObject.ReloadFromMemory();

                    ScriptArrayObjectDisplay arrayDisplay = new ScriptArrayObjectDisplay();
                    arrayDisplay.LoadArray(arrayObject);
                    return arrayDisplay;
                case DynamicValue.FlagType.pTextObject:
                    ScriptStringObjectDisplay display_text = new ScriptStringObjectDisplay();
                    display_text.LoadObject((IntPtr)dynamicValue.Value);
                    return display_text;
            }
            return null;
        }
    }
}
