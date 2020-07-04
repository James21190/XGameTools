using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects.Meta
{
    class SectorObject_Station_Meta : SectorObjectMetaWithChildren
    {
        public override int GetByteSize()
        {
            return 2000;
        }

        protected override void SetUniqueData(ObjectByteList obl)
        {
            
        }
    }
}
