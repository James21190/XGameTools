using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;

namespace XCommonLib.RAM.Bases.Sector
{
    public abstract class SectorBase : MemoryObject
    {
        /// <summary>
        /// First SectorObject in the list.
        /// Is null if object is invalid or non-existant.
        /// </summary>
        public abstract SectorObject First { get; }
        /// <summary>
        /// Last SectorObject in the list.
        /// Is null if object is invalid or non-existant.
        /// </summary>
        public abstract SectorObject Last { get; }
        /// <summary>
        /// Player SectorObject.
        /// Is null if object is invalid or non-existant.
        /// </summary>
        public abstract SectorObject Player { get; }

        /// <summary>
        /// Returns the first top level SectorObject with a given MainType.
        /// </summary>
        /// <param name="mainType"></param>
        /// <returns></returns>
        public SectorObject GetFirstObjectOfMainType(short mainType)
        {
            var next = First;
            while (next != null)
            {
                if (next.ObjectType.MainType == mainType)
                {
                    return next;
                }

                next = next.Next;
            }
            return null;
        }

        public abstract SectorObject GetSectorObject(int id);
        public abstract SectorObject GetSectorObject(IntPtr pAddress);

        /// <summary>
        /// Get the SectorObjects registered to the SectorBase.
        /// </summary>
        /// <param name="topLevelOnly">If true, only the top SectorObjects are returned, if false all are returned.</param>
        /// <returns></returns>
        public SectorObject[] GetSectorObjects(bool topLevelOnly)
        {
            List<SectorObject> sectorObjects = new List<SectorObject>();

            if(topLevelOnly)
            {
                SectorObject so = First;
                while (so != null)
                {
                    sectorObjects.Add(so);
                    so = so.Next;
                }
            }
            else
            {
                foreach(var id in GetSectorObjectIDs())
                {
                    sectorObjects.Add(GetSectorObject(id));
                }
            }

            return sectorObjects.ToArray();
        }

        /// <summary>
        /// Returns all SectorObject IDs.
        /// </summary>
        /// <returns></returns>
        public abstract int[] GetSectorObjectIDs();
    }
}
