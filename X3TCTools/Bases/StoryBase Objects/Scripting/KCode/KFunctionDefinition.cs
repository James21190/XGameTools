using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.KCode
{
    public delegate void KFunctionEditState(ref int nextInstructionIndex, KInstruction instruction, KDisassembler kDisassembler);

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
        public KFunctionDefinition(int address, string name, int manualNextInstructionOffset, KFunctionEditState editStateFunction, ParameterType[] parameters)
        {
            this.FunctionAddress = address;
            this.FunctionName = name;
            this.Parameters = parameters;
            this.NextInstructionOffset = manualNextInstructionOffset;
            this.EditState = editStateFunction;
        }
        public int FunctionAddress;
        public string FunctionName;
        public ParameterType[] Parameters;
        public int NextInstructionOffset;

        public KFunctionEditState EditState;
    }
}
