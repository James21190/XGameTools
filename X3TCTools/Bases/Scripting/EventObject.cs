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
    /// <summary>
    /// The EventObject is an object within the game that keeps track of variables used by the scripting engine.
    /// It keeps track of how many variables are stored and the amount of ScriptObjects that reference it.
    /// </summary>
    public class EventObject : MemoryObject
    {
        public const int ByteSize = 16;

        public int NegativeID;
        public int ReferenceCount;
        public MemoryObjectPointer<EventObjectSub> pSub = new MemoryObjectPointer<EventObjectSub>();
        public MemoryObjectPointer<ScriptMemoryObject> pScriptVariableArr = new MemoryObjectPointer<ScriptMemoryObject>();

        public T GetScriptVariableArrayAsObject<T>() where T : ScriptMemoryObject,new()
        {
            var obj = new T();
            obj.SetLocation(GameHook.hProcess, pScriptVariableArr.address);
            obj.Resize(pSub.obj.ScriptVariableCount);
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

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            NegativeID = objectByteList.PopInt();
            ReferenceCount = objectByteList.PopInt();
            pSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<EventObjectSub>>();
            pScriptVariableArr = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptMemoryObject>>();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pScriptVariableArr.SetLocation(hProcess, address+ 0x8);
            pSub.SetLocation(hProcess, address+ 0xc);
        }

    }
}
