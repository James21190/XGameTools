using System;

using X3Tools.Bases.SectorBase_Objects;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public struct CargoEntry : IComparable
    {
        public SectorObject.SectorObjectType Type;
        public int Count;

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is CargoEntry))
            {
                throw new Exception("Type missmatch");
            }

            return ((CargoEntry)obj).Type.CompareTo(Type);

        }

        public override string ToString()
        {
            return Type.ToString() + " X " + Count;
        }
    }
}
