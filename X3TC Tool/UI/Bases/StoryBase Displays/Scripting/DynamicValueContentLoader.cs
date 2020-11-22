using System;
using System.Windows.Forms;
using X3TCTools;

using X3TCTools.Bases.StoryBase_Objects.Scripting;

namespace X3TC_Tool.UI.Displays
{
    public static class DynamicValueContentLoader
    {
        public static Form LoadContent(DynamicValue dynamicValue)
        {
            switch (dynamicValue.Flag)
            {
                case DynamicValue.FlagType.pHashTable:
                    ScriptingHashTableObject hashtableobj = new ScriptingHashTableObject();
                    hashtableobj.SetLocation(GameHook.hProcess, (IntPtr)dynamicValue.Value);
                    hashtableobj.ReloadFromMemory();

                    ScriptingHashTableDisplay display_hash = new ScriptingHashTableDisplay();
                    display_hash.LoadTable(hashtableobj.hashTable.pThis);

                    return display_hash;
                case DynamicValue.FlagType.pArray:
                    var arrayObject = new ScriptingArrayObject();
                    arrayObject.SetLocation(GameHook.hProcess, (IntPtr)dynamicValue.Value);
                    arrayObject.ReloadFromMemory();

                    var arrayDisplay = new DynamicValueArrayDisplay();
                    arrayDisplay.LoadFrom((IntPtr)arrayObject.pArray.address,0, arrayObject.length);
                    return arrayDisplay;
                case DynamicValue.FlagType.pTextObject:
                    ScriptingTextObjectDisplay display_text = new ScriptingTextObjectDisplay();
                    display_text.LoadObject((IntPtr)dynamicValue.Value);
                    return display_text;
            }
            return null;
        }
    }
}
