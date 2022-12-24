using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstance : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance
    {
        #region Memory Fields
        public override int NegativeID { get; set; }
        public override int Class
        {
            get => _SubCopy.Class;
            set => _SubCopy.Class = value;
        }

        public override int ScriptVariableCount
        {
            get => _SubCopy.ScriptVariableCount;
            set => _SubCopy.ScriptVariableCount = value;
        }
        public override int ReferenceCount { get; set; }
        public override MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue> pScriptVariableArr { get; set; }
        public MemoryObjectPointer<ScriptInstanceSub> pSub { get; set; }
        #endregion

        private ScriptInstanceSub _SubCopy;

        #region IMemoryObject
        public override int ByteSize => 16;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            NegativeID = objectByteList.PopInt();
            ReferenceCount = objectByteList.PopInt();
            pSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceSub>>();

            _SubCopy = pSub.obj;
            
            pScriptVariableArr = objectByteList.PopIMemoryObject<MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue>>();

        }
        #endregion
    }
}
