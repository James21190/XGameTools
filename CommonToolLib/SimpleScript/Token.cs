using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.SimpleScript
{
    internal struct Token
    {
        internal enum TokenType
        {
            Keyword,
            VariableType,
            VariableName,
            LiteralInt,
            LiteralShort,
            LiteralByte,
            LiteralLong,
            Instruction,
            Register,
            Label,
            EndOfStatement,
            Scope
        }

        internal TokenType Type;
        internal object Value;
        internal Token[] SubTokens;

        public override string ToString()
        {
            var result = string.Format("{0}({1})", Type.ToString(), Value);
            return result;
        }
    }
}
