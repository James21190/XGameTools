using System;
using System.Collections.Generic;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.KCode
{
    public abstract class KCodeDissassembler
    {
        protected DynamicValue[] ScriptStack;
        protected int InstructionOffset;
        protected int StackOffset;

        /// <summary>
        /// Returns a pointer to the function that will be executed next.
        /// Increments the InstructionOffset.
        /// </summary>
        /// <returns></returns>
        protected int GetNextFunctionAddress()
        {
            byte CurrentInstruction = ReadByte();
            return GameHook.pProcessEventSwitch.GetObjectInArray(GameHook.pProcessEventSwitchArray.GetObjectInArray(CurrentInstruction - 1).Value).Value;
        }

        private byte ReadByte()
        {
            return GameHook.storyBase.pInstructionArray.GetObjectInArray(InstructionOffset++).Value; ;
        }

        protected object GetNextParameter(FunctionParameter type)
        {
            switch (type)
            {
                case FunctionParameter.Byte: return ReadBytes(1)[0];
                case FunctionParameter.InStackShortRelativeOffset:
                case FunctionParameter.Short: return BitConverter.ToInt16(ReadBytes(2), 0);
                case FunctionParameter.Int: return BitConverter.ToInt32(ReadBytes(4), 0);
                case FunctionParameter.DynamicValue:
                    DynamicValue dynamicValue = new DynamicValue
                    {
                        Flag = (DynamicValue.FlagType)ReadByte(),
                        Value = BitConverter.ToInt32(ReadBytes(4), 0)
                    };
                    return dynamicValue;
                default: throw new Exception();
            }
        }

        private byte[] ReadBytes(int count)
        {
            byte[] result = new byte[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = ReadByte();
            }

            return result;
        }

        private FunctionCallData[] Decompile()
        {
            List<int> VisitedAddresses = new List<int>();
            return _Decompile(ref VisitedAddresses);
        }
        /// <summary>
        /// Decompiles the KCode attached to the ScriptObject.
        /// </summary>
        /// <param name="scriptObject"></param>
        /// <returns></returns>
        public FunctionCallData[] Decompile(ScriptObject scriptObject)
        {
            DynamicValue[] scriptStack = new DynamicValue[scriptObject.StackSize];
            for (int i = 0; i < scriptObject.StackSize; i++)
            {
                scriptStack[i] = scriptObject.pStack.GetObjectInArray(-i);
            }

            SetData(scriptObject.InstructionOffset, scriptObject.CurrentStackIndex, scriptStack);
            return Decompile();
        }

        public void SetData(int instructionOffset, int stackOffset, DynamicValue[] scriptStack)
        {
            InstructionOffset = instructionOffset;
            StackOffset = stackOffset;
            ScriptStack = scriptStack;
        }

        public FunctionCallData[] Decompile(int instructionOffset, int stackOffset, DynamicValue[] scriptStack, ref List<int> visitedAddresses)
        {
            SetData(instructionOffset, stackOffset, scriptStack);

            return _Decompile(ref visitedAddresses);
        }


        /// <summary>
        /// Start decompiling from a given offset.
        /// </summary>
        /// <param name="instructionOffset"></param>
        /// <returns></returns>
        protected abstract FunctionCallData[] _Decompile(ref List<int> DecompiledAddresses);

        /// <summary>
        /// Returns data for an instruction at a given address.
        /// </summary>
        /// <param name="instructionAddress"></param>
        /// <returns></returns>
        protected abstract FunctionData InterperateInstructionAddress(int instructionAddress);

        /// <summary>
        /// Returns the name of a kcode function with a given starting address.
        /// </summary>
        /// <param name="functionStartInstructionAddress"></param>
        /// <returns></returns>
        public abstract string GetFunctionName(int functionStartInstructionAddress);
    }

    public struct FunctionCallData
    {
        public int Address;
        public int StartingStackIndex;
        public FunctionData CalledFunction;
        public object[] Parameters;
        public FunctionCallData[] Sub;
        public DynamicValue[] ScriptStack;

        public DynamicValue GetValueInStack(int index)
        {
            if (index > 0)
            {
                index = -index;
            }

            if (-index < 0 || -index >= ScriptStack.Length)
            {
                return new DynamicValue() { Flag = DynamicValue.FlagType.NULL, Value = 0 };
            }

            return ScriptStack[-index];
        }

        public override string ToString()
        {
            return ToString("");
        }

        public string ToString(string format, int indent = 0)
        {
            string[] paramString = Parameters == null ? new string[0] : new string[Parameters.Length];
            string indentString = new string(' ', indent * 4);
            for (int i = 0; i < paramString.Length; i++)
            {
                switch (CalledFunction.Parameters[i])
                {
                    case FunctionParameter.InStackShortRelativeOffset: paramString[i] = string.Format("Stack{0}({1})", (StartingStackIndex + (short)Parameters[i]), GetValueInStack((StartingStackIndex + (short)Parameters[i]))); break;
                    default: paramString[i] = Parameters[i].ToString(); break;
                }
            }
            string line;
            string comment;
            switch (format)
            {
                case "C":
                    comment = CalledFunction.Comments == "" ? "" : "//" + CalledFunction.Comments;
                    line = string.Format("{0} | {1} - {2}{3}({4}) {5}", Address.ToString("00000000"), StartingStackIndex == 0 ? "-000" : StartingStackIndex.ToString("000"), indentString, CalledFunction.ToString(), string.Join(", ", paramString), comment);
                    break;
                case "CX":
                    comment = CalledFunction.Comments == "" ? "" : "//" + CalledFunction.Comments;
                    line = string.Format("{0} | {1} - {2}{3}({4}) {5}", Address.ToString("00000000"), StartingStackIndex == 0 ? "-000" : StartingStackIndex.ToString("000"), indentString, CalledFunction.ToString("X"), string.Join(", ", paramString), comment);
                    break;
                case "X":
                    line = string.Format("{0} | {1} - {2}{3}({4})", Address.ToString("00000000"), StartingStackIndex == 0 ? "-000" : StartingStackIndex.ToString("000"), indentString, CalledFunction.ToString("X"), string.Join(", ", paramString));
                    break;
                default:
                    line = string.Format("{0} | {1} - {2}{3}({4})", Address.ToString("00000000"), StartingStackIndex == 0 ? "-000" : StartingStackIndex.ToString("000"), indentString, CalledFunction.ToString(), string.Join(", ", paramString));
                    break;
            }
            if (Sub != null)
            {
                foreach (FunctionCallData item in Sub)
                {
                    line += string.Format("\n{0}", item.ToString(format, indent + 1));
                }
            }

            return line;
        }
    }

    public enum FunctionParameter
    {
        Byte,
        Short,
        Int,
        DynamicValue,

        InStackShortRelativeOffset,
    }

    public struct FunctionData
    {
        public string Name;
        public int Address;
        public bool IsEnd;
        public FunctionParameter[] Parameters;
        public int MaunalAddressOffset;
        public int StackIndexChange;
        public string Comments;

        public FunctionData(string name, int address, bool isEnd, FunctionParameter[] parameters, int additionalSkips, int stackIndexChange, string comments)
        {
            Name = name;
            Address = address;
            IsEnd = isEnd;
            Parameters = parameters;
            MaunalAddressOffset = additionalSkips;
            StackIndexChange = stackIndexChange;
            Comments = comments;
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// "A": Returns address.
        /// "X": Returns address as hex.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            switch (format)
            {
                case "A": return Address.ToString();
                case "X": return Address.ToString("X");
                default: return ToString();
            }
        }
    }
}
