using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3Tools.RAM
{
    public interface INumericIDObject : IMemoryObject
    {
        int ID { get; }
    }
}
