using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.KCode.AP
{
    public partial class APKCodeDissassembler : KCodeDissassembler
    {

        protected override FunctionCallData[] _Decompile(ref List<int> visitedAddresses)
        {
            List<FunctionCallData> result = new List<FunctionCallData>();
            APKCodeDissassembler dissassembler = new APKCodeDissassembler();
            DynamicValue[] stackCopy = new DynamicValue[ScriptStack.Length];
            while (true)
            {
                // Get initial variables
                int baseInstructionOffset = InstructionOffset;
                int baseStackOffset = StackOffset;

                // Check if address has already been decompiled
                if (visitedAddresses.Contains(InstructionOffset))
                {
                    result.Add(new FunctionCallData() { Address = InstructionOffset, CalledFunction = new FunctionData("GOTO", 0, true, new FunctionParameter[] { FunctionParameter.Int }, 0, 0, ""), Parameters = new object[] { InstructionOffset } });
                    break;
                }
                else visitedAddresses.Add(InstructionOffset);


                var functionData = InterperateInstructionAddress(GetNextFunctionAddress());

                // Parameters
                object[] functionParams = null;
                if (functionData.Parameters.Length > 0)
                {
                    functionParams = new object[functionData.Parameters.Length];

                    for (int i = 0; i < functionParams.Length; i++)
                    {
                        switch ((APKCodeInstructionAddress)functionData.Address)
                        {
                            //case APKCodeFunctionAddress.CopyValueToTop:
                            //    if (i == 0) functionParams[i] = (short)((short)GetNextParameter(functionData.Parameters[i]) - 1);
                            //    break;
                            default: functionParams[i] = GetNextParameter(functionData.Parameters[i]); break;
                        }
                    }
                }

                if (functionData.MaunalAddressOffset > 0)
                {
                    InstructionOffset = baseInstructionOffset + functionData.MaunalAddressOffset;
                }
                StackOffset += functionData.StackIndexChange;


                // Sub Calls (Used for jumps and ifs)
                FunctionCallData[] subCalls = null;

                // Clone arrays
                Array.Copy(ScriptStack, stackCopy, stackCopy.Length);
                var functionCallDataStackClone = new DynamicValue[ScriptStack.Length];
                Array.Copy(ScriptStack, functionCallDataStackClone, functionCallDataStackClone.Length);

                // Check for branches or any other special behaviour.
                switch ((APKCodeInstructionAddress)functionData.Address)
                {
                    //case TCKCodeFunctionAddress.PopMultiple: StackOffset += (short)functionParams[0]; break;
                    //
                    //case TCKCodeFunctionAddress.Jump: InstructionOffset = (int)functionParams[0]; break;
                    //case TCKCodeFunctionAddress.JumpIfTrue6: subCalls = dissassembler.Decompile((int)functionParams[1], StackOffset, ScriptStack, ref visitedAddresses); break;
                    //case TCKCodeFunctionAddress.JumpIfFalse6: subCalls = dissassembler.Decompile((int)functionParams[1], StackOffset, ScriptStack, ref visitedAddresses); break;
                    //case TCKCodeFunctionAddress.JumpIfTrue: subCalls = dissassembler.Decompile((int)functionParams[0], StackOffset, ScriptStack, ref visitedAddresses); break;
                    //case TCKCodeFunctionAddress.JumpIfFalse: subCalls = dissassembler.Decompile((int)functionParams[0], StackOffset, ScriptStack, ref visitedAddresses); break;
                }

                result.Add(new FunctionCallData() { Address = baseInstructionOffset, StartingStackIndex = baseStackOffset, CalledFunction = functionData, Parameters = functionParams, Sub = subCalls, ScriptStack = functionCallDataStackClone });


                if (functionData.IsEnd) break;
            }
            return result.ToArray();
        }

        protected override FunctionData InterperateInstructionAddress(int functionAddress)
        {
            foreach (var item in functions)
            {
                if (item.Address == functionAddress)
                    return item;
            }
            return new FunctionData("UNDEFINED[0x" + functionAddress.ToString("X") + "]", functionAddress, true, new FunctionParameter[0], 0, 0, "Function not defined. Unable to continue");
        }
    }
}
