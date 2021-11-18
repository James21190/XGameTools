using CommonToolLib.ProcessHooking;

namespace XCommonLib.RAM.Bases.Story
{
    public abstract class TextPage : MemoryObject
    {
        public abstract MemoryString GetText(int textId);
    }
}
