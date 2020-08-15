using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Memory
{
    public interface IValidateable
    {
        bool IsValid { get; }
    }
}
