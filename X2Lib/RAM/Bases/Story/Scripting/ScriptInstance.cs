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
        public const int BYTE_SIZE = 0x38;
        public override int ByteSize => BYTE_SIZE;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            NegativeID = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x8);
            ScriptVariableCount = memoryObjectConverter.PopInt();
            pScriptVariableArr = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue>>();

            //ReferenceCount = objectByteList.PopInt(0x8);
            memoryObjectConverter.Seek(0x20);
            Class = memoryObjectConverter.PopInt();

            // Seek to end to consume the correct amount of bytes.
            memoryObjectConverter.Seek(BYTE_SIZE);
        }
        #endregion
    }
}
