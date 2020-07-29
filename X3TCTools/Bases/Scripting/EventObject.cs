using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting
{
    public class EventObject : MemoryObject
    {
        public const int ByteSize = 16;

        public int NegativeID;
        public int ReferenceCount;
        public MemoryObjectPointer<EventObjectSub> pSub = new MemoryObjectPointer<EventObjectSub>();
        public MemoryObjectPointer<ScriptingMemoryObject> pScriptVariableArr = new MemoryObjectPointer<ScriptingMemoryObject>();

        public T GetScriptVariableArrayAsObject<T>() where T : ScriptingMemoryObject,new()
        {
            var obj = new T();
            obj.SetLocation(GameHook.hProcess, pScriptVariableArr.address);
            obj.ReloadFromMemory();
            return obj;
        }

        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(NegativeID);
            collection.Append(ReferenceCount);
            collection.Append(pSub);
            collection.Append(pScriptVariableArr);
            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);

            collection.PopFirst(ref NegativeID);
            collection.PopFirst(ref ReferenceCount);
            collection.PopFirst(ref pSub);
            collection.PopFirst(ref pScriptVariableArr.address);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pScriptVariableArr.SetLocation(hProcess, address+8);
            pSub.SetLocation(hProcess, address+12);
        }

    }
}
