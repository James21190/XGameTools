using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.KCode.AP
{
    public partial class APKCodeDissassembler
    {
        public enum APKCodeFunctionOffsets
        {

        }

        public override string GetFunctionName(int functionStartInstructionAddress)
        {
            if (((APKCodeFunctionOffsets)functionStartInstructionAddress).ToString() == functionStartInstructionAddress.ToString())
                return "Unknown function " + functionStartInstructionAddress.ToString();
            return ((APKCodeFunctionOffsets)functionStartInstructionAddress).ToString();
        }
    }
}
