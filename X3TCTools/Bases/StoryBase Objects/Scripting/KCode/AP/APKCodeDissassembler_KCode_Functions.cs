namespace X3TCTools.Bases.StoryBase_Objects.Scripting.KCode.AP
{
    public partial class APKCodeDissassembler
    {
        public enum APKCodeFunctionOffsets
        {

        }

        public override string GetFunctionName(int functionStartInstructionAddress)
        {
            if (((APKCodeFunctionOffsets)functionStartInstructionAddress).ToString() == functionStartInstructionAddress.ToString())
            {
                return "Unknown function " + functionStartInstructionAddress.ToString();
            }

            return ((APKCodeFunctionOffsets)functionStartInstructionAddress).ToString();
        }
    }
}
