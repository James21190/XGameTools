using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public class TypeData_31 : TypeData
    {
        protected override void SetUniqueData(ObjectByteList obl)
        {
            
        }
        public override string GetObjectClassAsString()
        {
            return ((TypeData_Ship.ShipClassification)ObjectClass).ToString();
        }
    }
}
