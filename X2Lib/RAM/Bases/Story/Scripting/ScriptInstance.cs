using CommonToolLib.ProcessHooking;
using System;

namespace X2Lib.RAM.Bases.Story.Scripting
{
    public class ScriptInstance : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance
    {
        #region Memory Fields
        public override int NegativeID { get; set; }
        public override int Class { get; set; }
        public override int ReferenceCount { get; set; }
        public override int ScriptVariableCount { get; set; }
        public override MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue> pScriptVariableArr { get; set; }
        #endregion

        #region IMemoryObject
        public override int ByteSize => 0x38;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            NegativeID = objectByteList.PopInt();

            ScriptVariableCount = objectByteList.PopInt(0x8);
            pScriptVariableArr = objectByteList.PopIMemoryObject<MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue>>();

            //ReferenceCount = objectByteList.PopInt(0x8);
            Class = objectByteList.PopInt(0x20);

            return SetDataResult.Success;
        }
        #endregion
    }
}
