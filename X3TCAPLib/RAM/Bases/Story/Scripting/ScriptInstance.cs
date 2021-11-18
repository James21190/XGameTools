using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstance : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance
    {
        #region Memory Fields
        public override int NegativeID { get; set; }
        public override int ReferenceCount { get; set; }
        public MemoryObjectPointer<ScriptInstanceSub> pSub { get; set; }
        public override MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue> pScriptVariableArr { get; set; }
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceSub Sub => pSub.obj;
        #endregion

        #region IMemoryObject
        public override int ByteSize => 16;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            NegativeID = objectByteList.PopInt();
            ReferenceCount = objectByteList.PopInt();
            pSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceSub>>();
            pScriptVariableArr = objectByteList.PopIMemoryObject<MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue>>();
        }
        #endregion
    }
}
