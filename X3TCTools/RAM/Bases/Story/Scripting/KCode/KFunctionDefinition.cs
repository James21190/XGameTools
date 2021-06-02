namespace X3Tools.RAM.Bases.Story.Scripting.KCode
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
            FunctionAddress = address;
            FunctionName = name;
            Parameters = parameters;
            NextInstructionOffset = manualNextInstructionOffset;
            ShouldTerminateDecompilation = shouldTerminateDecompilation;
        }
        public int FunctionAddress;
        public string FunctionName;
        public ParameterType[] Parameters;
        public int NextInstructionOffset;
        public bool ShouldTerminateDecompilation;
    }
}
