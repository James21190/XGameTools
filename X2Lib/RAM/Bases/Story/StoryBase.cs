using CommonToolLib.ProcessHooking;
using System;
using X2Lib.RAM.Bases.Story.Scripting;
using XCommonLib.RAM.Generics;

namespace X2Lib.RAM.Bases.Story
{
    public class StoryBase : XCommonLib.RAM.Bases.Story.StoryBase
    {
        #region Memory Fields
        public MemoryObjectPointer<MemoryString> pStrings;
        public MemoryObjectPointer<HashTable<ScriptInstance>> pHashTable_ScriptInstance;
        public MemoryObjectPointer<HashTable<ScriptTaskObject>> pHashTable_ScriptTaskObject;
        public MemoryObjectPointer<HashTable<ScriptTableObject>> pHashTable_ScriptHashTable;
        #endregion

        #region Common
        #region Scripting
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptTaskObject GetScriptTaskObject(IntPtr pAddress)
        {
            throw new NotImplementedException();
        }
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptTaskObject GetScriptTaskObject(int id)
        {
            throw new NotImplementedException();
        }
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance GetScriptInstance(int id)
        {
            int value = id < 0 ? -id - 1 : id;
            return pHashTable_ScriptInstance.obj.GetObject(value);
        }
        public override int[] GetAllScriptTaskObjects()
        {
            return pHashTable_ScriptTaskObject.obj.ScanContents();
        }
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance GetScriptInstance(IntPtr pAddress)
        {
            var scriptInstance = new ScriptInstance();
            scriptInstance.pThis = pAddress;
            scriptInstance.ParentMemoryBlock = ParentMemoryBlock;
            scriptInstance.ReloadFromMemory();
            return scriptInstance;
        }
        public override int[] GetAllScriptInstances()
        {
            return pHashTable_ScriptInstance.obj.ScanContents();
        }
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptTableObject GetScriptHashTable(int id)
        {
            return pHashTable_ScriptHashTable.obj.GetObject(id);
        }
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptTableObject GetScriptHashTable(IntPtr address)
        {
            var result = new ScriptTableObject();
            result.ParentMemoryBlock = ParentMemoryBlock;
            result.pThis = address;
            result.ReloadFromMemory();
            return result;
        }
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptArrayObject GetScriptArrayObject(IntPtr address)
        {
            throw new NotImplementedException();
        }

        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptArrayObject GetScriptArrayObject(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        public override MemoryString GetStringFromArray(int index)
        {
            MemoryString memorystring = new MemoryString();
            memorystring.ParentMemoryBlock = ParentMemoryBlock;
            memorystring.pThis = pStrings.PointedAddress + index;
            memorystring.ReloadFromMemory();
            return memorystring;
        }
        public override XCommonLib.RAM.Bases.Story.TextPage GetTextPage(int languageId, int pageId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MemoryObject
        public override int ByteSize => 5648;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            pHashTable_ScriptTaskObject = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptTaskObject>>>(0x0);
            pHashTable_ScriptInstance = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptInstance>>>(0x12d8);
            pHashTable_ScriptHashTable = objectByteList.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptTableObject>>>(0x1604);

        }



        #endregion
    }
}
