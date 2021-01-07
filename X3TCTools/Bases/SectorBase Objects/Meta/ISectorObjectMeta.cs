using Common.Memory;
using System;

namespace X3Tools.Bases.SectorBase_Objects.Meta
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
        SectorObject[] GetChildren(SectorObject.Main_Type main_Type);


        [Obsolete("This method is no longer supported. Please use GetChildren instead.")]
        SectorObject GetFirstChild(SectorObject.Main_Type main_Type);
        [Obsolete("This method is no longer supported. Please use GetChildren instead.")]
        SectorObject GetLastChild(SectorObject.Main_Type main_Type);
    }
}
