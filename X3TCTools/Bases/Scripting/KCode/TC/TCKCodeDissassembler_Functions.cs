namespace X3TCTools.Bases.Scripting.KCode.TC
{
    public partial class TCKCodeDissassembler
    {
        public enum TCKCodeInstructionAddress
        {
            Push0 = 0x004a2d9e,
            Push1 = 0x004a2db0,
            Push2 = 0x004a2dc2,
            Push3 = 0x004a2dd4,
            PushByte = 0x004a2de6,
            PushShort = 0x004a2de6,
            PushInt = 0x004A2E0E,
            PushNewDynamicValue0xe = 0x004a2e21,
            JumpIfTrue6 = 0x004A4932,
            JumpIfFalse6 = 0x004a4949,
            Exit = 0x004a4991,


            Jump = 0x004A380A,
            JumpIfFalse = 0x004A3839,
            JumpIfTrue = 0x004a3818,

            U_4A3C3D = 0x004A3C3D,
            U_4A464D = 0x004A464D,
            PopMultiple = 0x004A3150,
            CopyValueToTop = 0x004A2E88,
            U_4A3B4A = 0x004A3B4A,
            U_4A4882 = 0x004A4882,
            U_4A45AB = 0x004A45AB,
            U_4A4963 = 0x004A4963,
            U_4A2ECC = 0x004A2ECC,
            U_4A2EEF = 0x004A2EEF,
            U_4A3B6D = 0x004A3B6D,
            U_4A45C4 = 0x004A45C4,

            U_Jump_4A3E4C = 0x004A3E4C,
        }

        private FunctionData[] functions = new FunctionData[]
        {
            new FunctionData("Push0", (int)TCKCodeInstructionAddress.Push0, false, new FunctionParameter[0],0,-1, "Pushes a 0 to the top of the stack."),
            new FunctionData("Push1", (int)TCKCodeInstructionAddress.Push1, false, new FunctionParameter[0],0,-1, "Pushes a 1 to the top of the stack."),
            new FunctionData("Push2", (int)TCKCodeInstructionAddress.Push2, false, new FunctionParameter[0],0,-1, "Pushes a 2 to the top of the stack."),
            new FunctionData("Push3", (int)TCKCodeInstructionAddress.Push3, false, new FunctionParameter[0],0,-1, "Pushes a 3 to the top of the stack."),
            new FunctionData("PushByte", (int)TCKCodeInstructionAddress.PushByte, false, new FunctionParameter[] {FunctionParameter.Byte },0,-1, "Pushes a short to the top of the stack."),
            new FunctionData("PushShort", (int)TCKCodeInstructionAddress.PushShort, false, new FunctionParameter[] {FunctionParameter.Short },0,-1, "Pushes a short to the top of the stack."),
            new FunctionData("PushInt", (int)TCKCodeInstructionAddress.PushInt, false, new FunctionParameter[] {FunctionParameter.Int },0,-1, "Pushes an int to the top of the stack."),
            new FunctionData("PushNewDynamicValue0xe", (int)TCKCodeInstructionAddress.PushNewDynamicValue0xe, false, new FunctionParameter[] {FunctionParameter.DynamicValue },0,-1, "Pushes a new DynamicValue with a flag of 0xe to the top of the stack."),
            new FunctionData("JumpIfTrue6", (int)TCKCodeInstructionAddress.JumpIfTrue6, false, new FunctionParameter[]{ FunctionParameter.Short, FunctionParameter.Int },6,1, ""),
            new FunctionData("JumpIfFalse6", (int)TCKCodeInstructionAddress.JumpIfFalse6, false, new FunctionParameter[]{ FunctionParameter.Short, FunctionParameter.Int },6,1, ""),
            new FunctionData("Jump", (int)TCKCodeInstructionAddress.Jump, false, new FunctionParameter[]{ FunctionParameter.Int },0,0,"Jumps to an address"),
            new FunctionData("JumpIfFalse", (int)TCKCodeInstructionAddress.JumpIfFalse, false, new FunctionParameter[]{ FunctionParameter.Int },5,1,"Jumps to an address if the byte on the top of the stack is false."),
            new FunctionData("JumpIfTrue", (int)TCKCodeInstructionAddress.JumpIfTrue, false, new FunctionParameter[]{ FunctionParameter.Int },5,1,"Jumps to an address if the byte on the top of the stack is false."),

            new FunctionData("Exit", (int)TCKCodeInstructionAddress.Exit, true, new FunctionParameter[0],0,0, ""),

            new FunctionData("U_4A3C3D", (int)TCKCodeInstructionAddress.U_4A3C3D, false,new FunctionParameter[0],3,0,""),
            new FunctionData("U_4A464D", (int)TCKCodeInstructionAddress.U_4A464D, false,new FunctionParameter[] { FunctionParameter.Short },4,1,""),
            new FunctionData("PopMultiple", (int)TCKCodeInstructionAddress.PopMultiple, false,new FunctionParameter[] { FunctionParameter.Short },3,0,"Pops a number of values from the top of the stack."),
            new FunctionData("CopyValueToTop", (int)TCKCodeInstructionAddress.CopyValueToTop, false,new FunctionParameter[] {FunctionParameter.InStackShortRelativeOffset },3,-1,"Copies a value in the stack at a given index from the top to a newly created value."),
            new FunctionData("U_4A3B4A", (int)TCKCodeInstructionAddress.U_4A3B4A, false,new FunctionParameter[0],0,1,""),
            new FunctionData("U_4A4882", (int)TCKCodeInstructionAddress.U_4A4882, false,new FunctionParameter[0],10,-1,""),
            new FunctionData("U_4A45AB", (int)TCKCodeInstructionAddress.U_4A45AB, false,new FunctionParameter[0],4,0,""),
            new FunctionData("U_4A4963", (int)TCKCodeInstructionAddress.U_4A4963, false,new FunctionParameter[0],1,0,""),
            new FunctionData("U_4A2ECC", (int)TCKCodeInstructionAddress.U_4A2ECC, false,new FunctionParameter[0],3,0,""),
            new FunctionData("U_4A2EEF", (int)TCKCodeInstructionAddress.U_4A2EEF, false,new FunctionParameter[0],0,0,""),
            new FunctionData("U_4A3B6D", (int)TCKCodeInstructionAddress.U_4A3B6D, false,new FunctionParameter[0],0,0,""),
            new FunctionData("U_4A45C4", (int)TCKCodeInstructionAddress.U_4A45C4, false,new FunctionParameter[0],4,0,""),

            new FunctionData("U_Jump_4A3E4C", (int)TCKCodeInstructionAddress.U_Jump_4A3E4C, true,new FunctionParameter[] { FunctionParameter.Byte, FunctionParameter.Byte, FunctionParameter.Int, FunctionParameter.Int },0,0,""),
        };
    }
}
