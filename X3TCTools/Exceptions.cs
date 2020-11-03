using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools
{
    public class GameVersionInvalidException : Exception
    {
        public new string Message = "Game version is invalid.";
    }

    public class GameVersionNotSupportedException : Exception
    {
        public new string Message = "Game version is not supported";
    }

    public class GameVersionNotImplementedException : Exception
    {
        public new string Message = "Game version has not been implemented.";
    }
}
