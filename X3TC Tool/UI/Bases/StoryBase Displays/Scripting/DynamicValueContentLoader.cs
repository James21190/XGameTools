using System;
using System.Windows.Forms;
using X3TCTools;
using X3TCTools.Bases.Scripting;

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
                //case DynamicValue.FlagType.pArray:
                //    ScriptingArrayObject scriptingArrayObject = new ScriptingArrayObject();
                //    scriptingArrayObject.SetLocation(GameHook.hProcess, (IntPtr)dynamicValue.Value);
                //    scriptingArrayObject.ReloadFromMemory();

                //    ScriptMemoryObject arrayObj = new ScriptMemoryObject(scriptingArrayObject.length);
                //    arrayObj.SetLocation(GameHook.hProcess, scriptingArrayObject.pArray.address);
                //    arrayObj.ReloadFromMemory();

                //    var arrayDisplay = new DynamicValueObjectDisplay();
                //    arrayDisplay.LoadObject(arrayObj);
                //    return arrayDisplay;
                case DynamicValue.FlagType.pTextObject:
                    ScriptingTextObjectDisplay display_text = new ScriptingTextObjectDisplay();
                    display_text.LoadObject((IntPtr)dynamicValue.Value);
                    return display_text;
            }
            return null;
        }
    }
}
