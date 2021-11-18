using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Story
{
    public abstract class TextPage : MemoryObject
    {
        public abstract MemoryString GetText(int textId);
    }
}
