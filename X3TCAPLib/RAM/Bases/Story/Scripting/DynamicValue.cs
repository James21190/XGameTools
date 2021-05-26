using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class DynamicValue : XCommonLib.RAM.Bases.Story.Scripting.DynamicValue
    {
        /*

        /// <summary>
        /// Returns the HashTable that this value points to
        /// </summary>
        /// <returns></returns>
        public ScriptTableObject GetAsHashTableObject()
        {
            if (Flag != FlagType.pHashTable)
            {
                throw new Exception("Object is not a hash table.");
            }

            ScriptTableObject table = new ScriptTableObject();
            table.SetLocation(this.hProcess, (IntPtr)Value);
            table.ReloadFromMemory();
            return table;
        }

        /// <summary>
        /// Returns the TextObject that this value points to
        /// </summary>
        /// <returns></returns>
        public ScriptStringObject GetAsTextObject()
        {
            if (Flag != FlagType.pTextObject)
            {
                throw new Exception("Object is not a text object.");
            }

            ScriptStringObject textObject = new ScriptStringObject();
            textObject.SetLocation(this.hProcess, (IntPtr)Value);
            textObject.ReloadFromMemory();
            return textObject;
        }

        */
    }
}
