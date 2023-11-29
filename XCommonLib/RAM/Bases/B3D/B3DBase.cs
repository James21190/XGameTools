using CommonToolLib.ProcessHooking;

namespace XCommonLib.RAM.Bases.B3D
{
    public abstract class B3DBase : MemoryObject
    {
        public abstract RenderObject First { get; }
        public abstract RenderObject Last { get; }

        public abstract RenderObject GetRenderObject(int id);
        public abstract RenderObject[] GetRenderObjects();
    }
}
