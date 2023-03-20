using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using XCommonLib.RAM.Generics;

namespace XCommonLib.RAM.Bases.B3D
{
    public abstract class RenderObject : MemoryObject, INumericIDObject
    {
        public abstract int ID {get; set;}
    }
}
