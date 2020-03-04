using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;
using X3TCTools.Bases.Scripting;

namespace X3TCTools.Bases
{
    public class StoryBase : MemoryObject
    {
        public const int ByteSize = 5648;

        public MemoryObjectPointer<HashTable<ScriptObject>> pScriptObjectHashTable;
        
        public MemoryObjectPointer<DynamicValue> pInstructionArray;

        public int FunctionArrayCount;
        public EventFunctionStruct[] FunctionArray = new EventFunctionStruct[32];
        
        public MemoryObjectPointer<HashTable<EventObject>> pEventObjectHashTable;

        public MemoryObjectPointer<ScriptObject> pCurrentScriptObject = new MemoryObjectPointer<ScriptObject>();

        public MemoryObjectPointer<HashTable<StoryBase15fc>> pStoryBase15fcHashTable = new MemoryObjectPointer<HashTable<StoryBase15fc>>();

        public MemoryObjectPointer<HashTable<ScriptingHashTable>> pScriptingHashTable_HashTable = new MemoryObjectPointer<HashTable<ScriptingHashTable>>();

        public StoryBase()
        {
            for(int i = 0; i < FunctionArray.Length; i++)
            {
                FunctionArray[i] = new EventFunctionStruct();
            }

            pScriptObjectHashTable = new MemoryObjectPointer<HashTable<ScriptObject>>();
            pInstructionArray = new MemoryObjectPointer<DynamicValue>();
            pEventObjectHashTable = new MemoryObjectPointer<HashTable<EventObject>>();
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
            pInstructionArray = collection.PopIMemoryObject<MemoryObjectPointer<DynamicValue>>(0x8);
            FunctionArrayCount = collection.PopInt(0x2c);
            FunctionArray = collection.PopIMemoryObjects<EventFunctionStruct>(FunctionArray.Length);
            pEventObjectHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<EventObject>>>(0x12d0);
            pCurrentScriptObject = collection.PopIMemoryObject<MemoryObjectPointer<ScriptObject>>(0x1434);
            pStoryBase15fcHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<StoryBase15fc>>>(0x15fc);
            pScriptingHashTable_HashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptingHashTable>>>(0x1600);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pScriptObjectHashTable.SetLocation(hProcess, address + 0);
            pInstructionArray.SetLocation(hProcess, address + 0x8);
            pEventObjectHashTable.SetLocation(hProcess, address + 0x12d0);
            pCurrentScriptObject.SetLocation(hProcess, address + 0x1434);
            pStoryBase15fcHashTable.SetLocation(hProcess, address + 0x15fc);
            pScriptingHashTable_HashTable.SetLocation(hProcess, address + 0x1600);
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
