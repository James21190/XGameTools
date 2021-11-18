using CommonToolLib.ProcessHooking;
using System;
using X2Lib.RAM.Bases.Story.Scripting;
using XCommonLib.RAM.Bases.Story;
using XCommonLib.RAM.Generics;

namespace X2Lib.RAM.Bases.Story
{
    public class StoryBase : XCommonLib.RAM.Bases.Story.StoryBase
    {
        #region Memory Fields
        public MemoryObjectPointer<MemoryString> pStrings = new MemoryObjectPointer<MemoryString>();
        public MemoryObjectPointer<HashTable<ScriptInstance>> pHashTable_ScriptInstance = new MemoryObjectPointer<HashTable<ScriptInstance>>();
        #endregion

        #region Common

        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptTaskObject GetScriptTaskObject(int id)
        {
            throw new NotImplementedException();
        }
        public override MemoryString GetStringFromArray(int index)
        {
            MemoryString memorystring = new MemoryString();
            memorystring.hProcess = hProcess;
            memorystring.pThis = pStrings.address + index;
            memorystring.ReloadFromMemory();
            return memorystring;
        }
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance GetScriptInstance(int id)
        {
            int value = id < 0 ? -id - 1 : id;
            return pHashTable_ScriptInstance.obj.GetObject(value);
        }
        public override XCommonLib.RAM.Bases.Story.TextPage GetTextPage(int languageId, int pageId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MemoryObject
        public override int ByteSize => throw new NotImplementedException();


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            base.SetDataFromObjectByteList(objectByteList);
        }


        #endregion
    }
}
