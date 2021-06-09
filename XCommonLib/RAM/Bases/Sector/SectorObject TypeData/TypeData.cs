using CommonToolLib.Memory;
using CommonToolLib.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Sector.SectorObject_TypeData
{
    public abstract class TypeData : MemoryObject
    {
        public int BodyID;
        public Vector3 RotationSpeed;
        public int ObjectClass;
        public int DefaultNameId;
        public int WareVolume;
        /// <summary>
        /// The relative value of the type. Used to calculate storage in docks and factories, and price in credits.
        /// </summary>
        public int RelVal;
        public int PriceRangePercentage;
        public int WareSizeClass;
        public MemoryObjectPointer<MemoryString> pTypeName;
    }
}
