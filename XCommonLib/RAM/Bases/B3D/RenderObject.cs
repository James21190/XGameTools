using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using XCommonLib.RAM.Generics;

namespace XCommonLib.RAM.Bases.B3D
{
    public abstract class RenderObject : MemoryObject, INumericIDObject
    {
        public int ID {get; set;}
        public int BodyID { get; set;}
        public int CollectionID { get; set;}

        public Vector3_32 Position;

        public abstract RenderObject Parent { get; }

        public abstract RenderObject[] GetChildren(bool getChildrenOfChildren);
    }
}
