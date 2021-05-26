using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolLib.Memory;

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

        public SectorObject[] GetSectorObjects()
        {
            List<SectorObject> sectorObjects = new List<SectorObject>();

            var so = First;
            while (so != null)
            {
                sectorObjects.Add(so);
                so = so.Next;
            }

            return sectorObjects.ToArray();
        }
    }
}
