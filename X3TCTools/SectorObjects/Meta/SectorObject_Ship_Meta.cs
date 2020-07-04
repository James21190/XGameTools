using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects.Meta
{
    public class SectorObject_Ship_Meta : SectorObjectMetaWithChildren
    {
        public override int GetByteSize()
        {
            return 0x940;
        }

        protected override void SetUniqueData(ObjectByteList obl)
        {
            
        }
    }
}
