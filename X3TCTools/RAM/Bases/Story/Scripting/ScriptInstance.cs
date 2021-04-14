using Common.Memory;
using System;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;

namespace X3Tools.RAM.Bases.Story.Scripting
{
    /// <summary>
    /// The ScriptingObject is an object within the game that keeps track of variables used by the scripting engine.
    /// It keeps track of how many variables are stored and the amount of ScriptObjects that reference it.
    /// </summary>
    public partial class ScriptInstance : MemoryObject
    {
        #region Memory
        public int NegativeID;
        public int ReferenceCount;
        public MemoryObjectPointer<ScriptInstanceSub> pSub = new MemoryObjectPointer<ScriptInstanceSub>();
        public MemoryObjectPointer<ScriptMemoryObject> pScriptVariableArr = new MemoryObjectPointer<ScriptMemoryObject>();
        #endregion

        public ScriptMemoryObject ScriptVariableArr
        {
            get
            {
                var obj = pScriptVariableArr.obj;
                obj.Resize(pSub.obj.ScriptVariableCount);
                return obj;
            }
        }

        public ScriptInstanceTypeLibrary.ScriptInstanceType ScriptInstanceType
        {
            get
            {
                return ScriptInstanceTypeLibrary.GetScriptInstanceType(pSub.obj.Class);
            }
        }

        public DynamicValue GetVariableByName(string name)
        {
            return ScriptVariableArr.GetVariable(ScriptInstanceType.GetIndexOfVariable(name));
        }

        public void SetVariableByName(string name, DynamicValue value)
        {
            ScriptVariableArr.SetVariable(ScriptInstanceType.GetIndexOfVariable(name), value);
        }

        public void SetVariableAndWriteMemoryByName(string name, DynamicValue value)
        {
            ScriptVariableArr.SetVariableInMemory(ScriptInstanceType.GetIndexOfVariable(name), value);
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
            pSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceSub>>();
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
