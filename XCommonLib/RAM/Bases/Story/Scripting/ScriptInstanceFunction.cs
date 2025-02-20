using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptInstanceFunction : MemoryObject
    {
        #region Memory
        public int InstructionOffset { get; set; }
        public int StringOffset { get; set; }
        #endregion

    }
}
