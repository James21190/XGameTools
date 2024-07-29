using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace X2Lib.RAM.Bases.Story.Scripting
{
    public class ScriptTaskObject : XCommonLib.RAM.Bases.Story.Scripting.ScriptTaskObject
    {
        public override int ID { get; set; }
        public override int StackSize { get; set; }
        public override DynamicValue[] Stack { get;}
        public override int InstructionIndex { get; set; }

        public override int ByteSize => throw new NotImplementedException();

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new NotImplementedException();
        }
    }
}
