﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases
{
    public class StoryBase : MemoryObject
    {

        public const int ByteSize = 5648;

        public MemoryObjectPointer<HashTable<ScriptObject>> pScriptObjectHashTable;
        
        public MemoryObjectPointer<MemoryByte> pInstructionArray;

        public int FunctionArrayCount;
        public EventFunctionStruct[] FunctionArray = new EventFunctionStruct[32];

        public MemoryObjectPointer<HashTable<TextPage>>[] TextHashTableArray;

        public MemoryObjectPointer<HashTable<EventObject>> pEventObjectHashTable;

        public MemoryObjectPointer<ScriptObject> pCurrentScriptObject = new MemoryObjectPointer<ScriptObject>();


        public MemoryObjectPointer<HashTable<ScriptingTextObject>> pScriptingTextObject_HashTable = new MemoryObjectPointer<HashTable<ScriptingTextObject>>();
        public MemoryObjectPointer<HashTable<StoryBase15fc>> pScriptingArrayObject_HashTable = new MemoryObjectPointer<HashTable<StoryBase15fc>>();

        public MemoryObjectPointer<HashTable<ScriptingHashTableObject>> pScriptingHashTableObject_HashTable = new MemoryObjectPointer<HashTable<ScriptingHashTableObject>>();



        public StoryBase()
        {
            for(int i = 0; i < FunctionArray.Length; i++)
            {
                FunctionArray[i] = new EventFunctionStruct();
            }

            pScriptObjectHashTable = new MemoryObjectPointer<HashTable<ScriptObject>>();
            pInstructionArray = new MemoryObjectPointer<MemoryByte>();
            pEventObjectHashTable = new MemoryObjectPointer<HashTable<EventObject>>();
        }

        public TextPage GetTextPage(int language, int pageID)
        {
            var table = TextHashTableArray[language].obj;
            return table.GetObject(pageID);
        }

        public EventObject GetEventObject(int ID)
        {
            var value = ID < 0 ? -ID - 1 : ID;
            return pEventObjectHashTable.obj.GetObject(value);
        }

        public ScriptingMemoryObject GetEventObjectScriptingVariables(int ID)
        {
            var obj = new ScriptingMemoryObject();
            obj.SetLocation(m_hProcess, GetEventObject(ID).pScriptVariableArr.address);
            obj.ReloadFromMemory();
            return obj;
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);
            pScriptObjectHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptObject>>>();
            pInstructionArray = collection.PopIMemoryObject<MemoryObjectPointer<MemoryByte>>(0x8);
            
            FunctionArrayCount = collection.PopInt(0x2c);
            FunctionArray = collection.PopIMemoryObjects<EventFunctionStruct>(FunctionArray.Length);

            TextHashTableArray = collection.PopIMemoryObjects<MemoryObjectPointer<HashTable<TextPage>>>(45, 0x334);

            pEventObjectHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<EventObject>>>(0x12d0);
            pCurrentScriptObject = collection.PopIMemoryObject<MemoryObjectPointer<ScriptObject>>(0x1434);

            pScriptingTextObject_HashTable = collection.PopIMemoryObject <MemoryObjectPointer<HashTable<ScriptingTextObject>>>(0x15f8);
            pScriptingArrayObject_HashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<StoryBase15fc>>>();
            pScriptingHashTableObject_HashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptingHashTableObject>>>();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pScriptObjectHashTable.SetLocation(hProcess, address + 0);
            pInstructionArray.SetLocation(hProcess, address + 0x8);
            pEventObjectHashTable.SetLocation(hProcess, address + 0x12d0);
            pCurrentScriptObject.SetLocation(hProcess, address + 0x1434);

            pScriptingTextObject_HashTable.SetLocation(hProcess, address + 0x15f8);
            pScriptingArrayObject_HashTable.SetLocation(hProcess, address + 0x15fc);
            pScriptingHashTableObject_HashTable.SetLocation(hProcess, address + 0x1600);
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
