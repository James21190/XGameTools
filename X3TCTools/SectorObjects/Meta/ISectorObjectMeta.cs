using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects.Meta
{
    public interface ISectorObjectMeta : IMemoryObject
    {
        SectorObject GetFirstChild(SectorObject.Main_Type main_Type);
        SectorObject GetLastChild(SectorObject.Main_Type main_Type);
    }
}
