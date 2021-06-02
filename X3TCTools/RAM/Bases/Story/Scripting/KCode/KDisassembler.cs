using CommonToolLib.Memory;
using System;
using System.Collections.Generic;

namespace X3Tools.RAM.Bases.Story.Scripting.KCode
{
    public class KDisassembler
    {
        private readonly KFunctionDefinition[] m_FunctionDefinitions;
        public KDisassembler(KFunctionDefinition[] functionDefinitions)
        {
            m_FunctionDefinitions = functionDefinitions;
        }

        private KFunctionDefinition _GetFunctionDefinition(int functionAddress)
        {
            if (m_FunctionDefinitions != null)
            {
                foreach (KFunctionDefinition item in m_FunctionDefinitions)
                {
                    if (item.FunctionAddress == functionAddress)
                    {
                        return item;
                    }
                }
            }

            throw new NotImplementedException();
        }

        public KInstruction[] Disassemble(int startingInstructionIndex, int instructionLimit = 200)
        {
            StoryBase storyBase = GameHook.storyBase;
            // Create a list of decompiled instructions.
            List<KInstruction> instructions = new List<KInstruction>();

            int currentInstructionIndex = startingInstructionIndex;

            for (int instructionCount = 0; instructionCount < instructionLimit || instructionLimit == -1; instructionCount++)
            {
                byte currentInstruction = storyBase.pInstructionArray[currentInstructionIndex].Value;
                int nextInstructionIndex = currentInstructionIndex + 1;

                if (currentInstruction > 0xb0)
                {
                    break;
                }

                int functionAddress = storyBase.GetScriptingFunctionAddressFromInstruction(currentInstruction);

                KInstruction kInstruction = new KInstruction()
                {
                    Address = currentInstructionIndex,
                    CalledFunction = functionAddress
                };

                try
                {
                    // throws an exception if not found.
                    KFunctionDefinition functionDef = _GetFunctionDefinition(functionAddress);

                    kInstruction.AssociatedDefinition = functionDef;

                    // Parameters
                    if (functionDef.Parameters != null)
                    {

                        int paramIndex = currentInstructionIndex + 1;

                        kInstruction.Parameters = new object[functionDef.Parameters.Length];

                        for (int param = 0; param < kInstruction.Parameters.Length; param++)
                        {
                            object paramValue;
                            switch (functionDef.Parameters[param])
                            {
                                case KFunctionDefinition.ParameterType.paramByte:
                                    paramValue = storyBase.pInstructionArray[paramIndex].Value;
                                    paramIndex += 1;
                                    break;
                                case KFunctionDefinition.ParameterType.paramShort:
                                    paramValue = BitConverter.ToInt16(MemoryControl.Read(GameHook.hProcess, storyBase.pInstructionArray[paramIndex].pThis, 2), 0);
                                    paramIndex += 2;
                                    break;
                                case KFunctionDefinition.ParameterType.paramInt:
                                    paramValue = BitConverter.ToInt32(MemoryControl.Read(GameHook.hProcess, storyBase.pInstructionArray[paramIndex].pThis, 4), 0);
                                    paramIndex += 4;
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                            kInstruction.Parameters[param] = paramValue;
                        }
                    }

                    nextInstructionIndex = functionDef.NextInstructionOffset == 0 ? currentInstructionIndex + 1 : currentInstructionIndex + functionDef.NextInstructionOffset;
                }
                catch (NotImplementedException)
                {

                }
                // Set index to next instruction
                currentInstructionIndex = nextInstructionIndex;

                instructions.Add(kInstruction);
                if (kInstruction.AssociatedDefinition == null || kInstruction.AssociatedDefinition.ShouldTerminateDecompilation)
                {
                    break;
                }
            }

            return instructions.ToArray();
        }
    }
}
