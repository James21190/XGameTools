using CommonToolLib.Memory;

namespace XCommonLib.RAM.Bases.Sector.SectorObject_Meta
{
    public interface ISectorObjectMeta : IMemoryObject
    {
        /// <summary>
        /// Returns a list of the object's children
        /// </summary>
        /// <returns></returns>
        SectorObject[] GetChildren();
        /// <summary>
        /// Returns a list of the object's children with a given MainType.
        /// </summary>
        /// <param name="main_Type">Filtering type</param>
        /// <returns></returns>
        SectorObject[] GetChildren(int main_Type);
    }
}
