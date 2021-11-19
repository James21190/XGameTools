﻿using CommonToolLib.ProcessHooking;
using System;
using X3TCAPLib.RAM.Bases.Story.Scripting;
using XCommonLib.RAM.Generics;

namespace X3TCAPLib.RAM.Bases.Story
{
    public class StoryBase : XCommonLib.RAM.Bases.Story.StoryBase
    {
        #region Memory Fields
        public MemoryObjectPointer<MemoryString> pStrings = new MemoryObjectPointer<MemoryString>();

        public MemoryObjectPointer<HashTable<TextPage>>[] TextHashTableArray;

        public MemoryObjectPointer<HashTable<ScriptInstance>> pHashTable_ScriptInstance;

        public MemoryObjectPointer<HashTable<ScriptTaskObject>> pHashTable_ScriptTaskObject;
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptTaskObject GetScriptTaskObject(int id)
        {
            return pHashTable_ScriptTaskObject.obj.GetObject(id);
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
            HashTable<TextPage> table = TextHashTableArray[languageId].obj;
            return table.GetObject(pageId);
        }
        #endregion

        #region MemoryObject
        public override int ByteSize => 5648;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            pHashTable_ScriptTaskObject = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptTaskObject>>>();

            pStrings = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x14);

            TextHashTableArray = objectByteList.PopIMemoryObjects<MemoryObjectPointer<HashTable<TextPage>>>(45, 0x334);

            pHashTable_ScriptInstance = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptInstance>>>(0x12d0);
        }


        #endregion
    }
}