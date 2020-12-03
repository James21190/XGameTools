using Common.Memory;
using System;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;

namespace X3Tools.Bases.StoryBase_Objects.Scripting
{
    /// <summary>
    /// The ScriptingObject is an object within the game that keeps track of variables used by the scripting engine.
    /// It keeps track of how many variables are stored and the amount of ScriptObjects that reference it.
    /// </summary>
    public partial class ScriptingObject : MemoryObject
    {
        #region Memory
        public int NegativeID;
        public int ReferenceCount;
        public MemoryObjectPointer<ScriptingObjectSub> pSub = new MemoryObjectPointer<ScriptingObjectSub>();
        public MemoryObjectPointer<ScriptMemoryObject> pScriptVariableArr = new MemoryObjectPointer<ScriptMemoryObject>();
        #endregion

        public ScriptingObject_Type ObjectType
        {
            get
            {
                return (ScriptingObject_Type)pSub.obj.Class;
            }
        }

        public T GetScriptVariableArrayAsObject<T>() where T : ScriptMemoryObject, new()
        {
            T obj = new T();
            obj.SetLocation(GameHook.hProcess, pScriptVariableArr.address);
            obj.Resize(pSub.obj.ScriptVariableCount);
            return obj;
        }
        #region IMemoryObject
        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(NegativeID);
            collection.Append(ReferenceCount);
            collection.Append(pSub);
            collection.Append(pScriptVariableArr);
            return collection.GetBytes();
        }

        public override int ByteSize => 16;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            NegativeID = objectByteList.PopInt();
            ReferenceCount = objectByteList.PopInt();
            pSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptingObjectSub>>();
            pScriptVariableArr = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptMemoryObject>>();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pScriptVariableArr.SetLocation(hProcess, address + 0x8);
            pSub.SetLocation(hProcess, address + 0xc);
        }
        #endregion
    }
}
