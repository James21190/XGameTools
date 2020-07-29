using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3TCTools;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TC_Tool.UI.Displays
{
    public static class DynamicValueContentLoader
    {
        public static Form LoadContent(DynamicValue dynamicValue)
        {
            switch (dynamicValue.Flag) {
                case DynamicValue.FlagType.pHashTable:
                    var hashtableobj = new ScriptingHashTableObject();
                    hashtableobj.SetLocation(GameHook.hProcess, (IntPtr)dynamicValue.Value);
                    hashtableobj.ReloadFromMemory();

                    var display_hash = new ScriptingHashTableDisplay();
                    display_hash.LoadTable(hashtableobj.hashTable.pThis);

                    return display_hash;
                //case DynamicValue.FlagType.pArray:
                //    var arrayobj = new ScriptingArrayObject();
                //    arrayobj.SetLocation(GameHook.hProcess, (IntPtr)dynamicValue.Value);
                //    arrayobj.ReloadFromMemory();

                //    var arrayobj_2 = new BlankScriptingMemoryObject(arrayobj.length);
                //    arrayobj_2.SetLocation(GameHook.hProcess, arrayobj.pArray.address);
                //    arrayobj_2.ReloadFromMemory();

                //    var display_array = new DynamicValueObjectDisplay(gameHook);
                //    display_array.LoadObject(arrayobj_2);
                //    return display_array;
                case DynamicValue.FlagType.pTextObject:
                    var display_text = new ScriptingTextObjectDisplay();
                    display_text.LoadObject((IntPtr)dynamicValue.Value);
                    return display_text;
            }
            return null;
        }
    }
}
