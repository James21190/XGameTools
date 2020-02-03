using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

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
            var collection = new ObjectByteList(Memory);
            collection.PopFirst(ref pScriptObjectHashTable);
            collection.Skip(4);
            collection.PopFirst(ref pInstructionArray);
            collection.Skip(8 * 4);
            collection.PopFirst(ref FunctionArrayCount);
            collection.PopFirst(ref FunctionArray);
            collection.Skip(4000);
            collection.PopFirst(ref pEventObjectHashTable);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pScriptObjectHashTable.SetLocation(hProcess, address + 0);
            pInstructionArray.SetLocation(hProcess, address + 0);
            pEventObjectHashTable.SetLocation(hProcess, address + 0);
        }
        #endregion
    }
}
