using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.SectorObjects.Meta
{
    public interface ISectorObjectMeta : IMemoryObject
    {
        ChildList[] GetChildrenList();
    }
}
