using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3Tools.RAM.Bases.Story.Scripting.KCode
{
    public static class FunctionDefinitionLibrary
    {
        public static KFunctionDefinition[] GetKFunctionDefinitions(GameHook.GameVersions version)
        {
            switch(version)
            {
                case GameHook.GameVersions.X3TC:
                    return TCFunctionDefinition;
                default:
                    throw new NotImplementedException();
            }
        }

        #region Custom Methods
        public static void JumpIfBehaviour(ref int nextInstructionIndex, KInstruction instruction, KDisassembler kDisassembler)
        {
            //instruction.ChildInstructions = kDisassembler.Disassemble((int)instruction.Parameters[0], -1, false);
        }

        public static void JumpBehaviour(ref int nextInstructionIndex, KInstruction instruction, KDisassembler kDisassembler)
        {
            nextInstructionIndex = (int)instruction.Parameters[0];
        }
        #endregion

        public static readonly KFunctionDefinition[] TCFunctionDefinition = new KFunctionDefinition[]
        {
            new KFunctionDefinition(0x4a2d9e, "Push0", 0, null),
            new KFunctionDefinition(0x4a2db0, "Push1", 0, null),
            new KFunctionDefinition(0x4a2dc2, "Push2", 0, null),
            new KFunctionDefinition(0x4a2dd4, "Push3", 0,  null),
            new KFunctionDefinition(0x4a2de6, "PushByte", 2, new KFunctionDefinition.ParameterType[] {KFunctionDefinition.ParameterType.paramByte }),
            new KFunctionDefinition(0x4a2dfa, "PushShort", 3, new KFunctionDefinition.ParameterType[] {KFunctionDefinition.ParameterType.paramShort }),
            new KFunctionDefinition(0x4a2e0e, "PushInt", 5, new KFunctionDefinition.ParameterType[] {KFunctionDefinition.ParameterType.paramInt }),
            new KFunctionDefinition(0x4a2e21, "PushNewDynamicValue0xe", 0, null),
            new KFunctionDefinition(0x4a2e3c, "", 0, null),
            new KFunctionDefinition(0x4a2e57, "Skip8", 0, null),
            new KFunctionDefinition(0x4a2e75, "", 5, null),
            new KFunctionDefinition(0x4a2e88, "", 3, null),
            new KFunctionDefinition(0x4a2ea6, "", 3, null),
            new KFunctionDefinition(0x4a2ecc, "", 3, null),
            new KFunctionDefinition(0x4a2eef, "", 0, null),
            new KFunctionDefinition(0x4a2f11, "", 3, null),
            new KFunctionDefinition(0x4a2f2a, "", 3, null),
            new KFunctionDefinition(0x4a2f49, "", 3, null),
            new KFunctionDefinition(0x4a2f65, "", 3, null),
            new KFunctionDefinition(0x4a2f7e, "", 3, null),
            new KFunctionDefinition(0x4a2f9d, "", 3, null),
            new KFunctionDefinition(0x4a2fb9, "", 0, null),
            new KFunctionDefinition(0x4a2fe2, "", 3, null),
            new KFunctionDefinition(0x4a2fb9, "", 3, null),
            new KFunctionDefinition(0x4a300f, "", 3, null),
            new KFunctionDefinition(0x4a3021, "", 3, null),
            new KFunctionDefinition(0x4a3030, "", 3, null),
            new KFunctionDefinition(0x4a3063, "", 3, null),
            new KFunctionDefinition(0x4a309a, "", 3, null),
            new KFunctionDefinition(0x4a30d9, "", 3, null),
            new KFunctionDefinition(0x4a3111, "", 3, null),
            new KFunctionDefinition(0x4a3127, "", 3, null),
            new KFunctionDefinition(0x4a313a, "", 0, null),
            new KFunctionDefinition(0x4a3150, "", 3, null),
            new KFunctionDefinition(0x4a3195, "", 0, null),
            new KFunctionDefinition(0x4a32e4, "", 3, null),
            new KFunctionDefinition(0x4a3396, "", 0, null),

            new KFunctionDefinition(0x4a380a, "Jump", 0, new KFunctionDefinition.ParameterType[] {KFunctionDefinition.ParameterType.paramInt }, true),
            new KFunctionDefinition(0x4a3818, "JumpIfTrue", 5, new KFunctionDefinition.ParameterType[] {KFunctionDefinition.ParameterType.paramInt }),
            new KFunctionDefinition(0x4a3839, "JumpIfFalse", 5, new KFunctionDefinition.ParameterType[] {KFunctionDefinition.ParameterType.paramInt }),
            new KFunctionDefinition(0x4a416b, "", 5,  null),
            new KFunctionDefinition(0x4a45e3, "", 4,  null),
            new KFunctionDefinition(0x4a464d, "", 4,  null),
            new KFunctionDefinition(0x4a4963, "", 4,  null),

        };
    }
}
