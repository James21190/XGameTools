using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstanceFunction : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceFunction
    {
        public override int ByteSize => 0x10;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            base.InstructionOffset = memoryObjectConverter.PopInt();
            base.StringOffset = memoryObjectConverter.PopInt();
        }
    }
}
