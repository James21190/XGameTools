using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;

namespace XCommonLib.RAM.Bases.B3D
{
    public abstract class RenderObject : MemoryObject, IValidateable
    {
        public abstract bool IsValid { get; }
    }
}
