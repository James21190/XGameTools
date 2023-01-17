using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.SimpleScript
{
    public enum SimpleScriptVariableType
    {
        ssNone,
        ssByte,
        ssShort,
        ssInt,
        ssLong
    }

    public enum SimpleScriptVariableLocation
    {
        Local,
        Static,
        Constant
    }

    public struct SimpleScriptVariable
    {
        public string Name;
        public SimpleScriptVariableType Type;
        public object Value;
        public bool Configureable;
        public SimpleScriptVariableLocation Location;
        public int Offset;

        public override string ToString()
        {
            var result = "";
            if (Configureable)
                result += "config ";
            result += Location.ToString() + " ";
            result += Type.ToString() + " ";
            result += Name + " ";
            result += "{" + Value + "}";
            return result;
        }
    }
}
