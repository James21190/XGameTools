using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3Tools.Bases.Story.Scripting.KCode
{
    public class KFunctionDefinition
    {
        public enum ParameterType
        {
            paramByte,
            paramShort,
            paramInt,
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="name"></param>
        /// <param name="manualNextInstructionOffset"></param>
        /// <param name="editStateFunction"></param>
        public KFunctionDefinition(int address, string name, int manualNextInstructionOffset, ParameterType[] parameters, bool shouldTerminateDecompilation = false)
        {
            this.FunctionAddress = address;
            this.FunctionName = name;
            this.Parameters = parameters;
            this.NextInstructionOffset = manualNextInstructionOffset;
            this.ShouldTerminateDecompilation = shouldTerminateDecompilation;
        }
        public int FunctionAddress;
        public string FunctionName;
        public ParameterType[] Parameters;
        public int NextInstructionOffset;
        public bool ShouldTerminateDecompilation;
    }
}
