using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools;

namespace X3TCTools.Bases.Scripting
{
    public class KCodeDissassembler
    {
        public KCodeDissassembler()
        {
        }

        public enum KCodeFunction
        {
            Push0 = 0x004a2d9e,
            Push1 = 0x004a2db0,
            Push2 = 0x004a2dc2,
            Push3 = 0x004a2dd4,
            PushShort = 0x004a2de6,
            PushShortAndSkip = 0x004a2de6,
            PushIntAndSkip = 0x004A2E0E,
            PushNewDynamicValue0xe = 0x004a2e21,
            JumpIfTrue6 = 0x004A4932,
            JumpIfFalse6 = 0x004a4949,
            Undocumented_Jump_4A3E4C = 0x004A3E4C,
            JumpSkip8 = 0x004A2E57,
            Undocumented_Jump_4A4922 = 0x004A4922,
            Undocumented_Jump_4A3E80 = 0x004A3E80,
            Undocumented_Jump_4A4564 = 0x004A4564,
            JumpToVariable = 0x004A4910,
            U_4A3BC4 = 0x004A3BC4,
            U_4a464d = 0x004a464d,
            U_4A3C3D = 0x004A3C3D,
            U_4A3150 = 0x004A3150,
            U_4A2E88 = 0x004A2E88,
            U_4A3B4A = 0x004A3B4A,
            U_4A3BE2 = 0x004A3BE2,
            U_4A4775 = 0x004A4775,
            U_4A4882 = 0x004A4882,
            U_4A45AB = 0x004A45AB,
            U_4A2ECC = 0x004A2ECC,
            U_4A3B6D = 0x004A3B6D,
            U_4A486A = 0x004A486A,
            U_4A2F65 = 0x004A2F65,
            U_4A3A48 = 0x004A3A48,
            U_4A3818 = 0x004A3818,
            U_4A47AD = 0x004A47AD,
            U_4A2DFA = 0x004A2DFA,
            U_4A3B2C = 0x004A3B2C,
            U_4A39A2 = 0x004A39A2,
            U_4A2EEF = 0x004A2EEF,
            U_4A45C4 = 0x004A45C4,
            U_4A3797 = 0x004A3797,
            U_4A4354 = 0x004A4354,
            Exit = 0x004a4991,
            Pop_1 = 0x004A4963,
            Pop_2 = 0x004A3958,
            ExecuteScriptInstruction = 0x004a3f10,
            CreateNewEventObject = 0x004a33e0,
            Jump = 0x004a380a,
            JumpIfFalse = 0x004A3839,
            JumpIfTrue = 0x004a3818,
        }

        public struct KCodeParameter
        {
            public enum ParamType
            {
                Int,
                Short,
                Byte,
                DynamicValue,
            }

            public KCodeParameter(string name, ParamType type)
            {
                this.name = name;
                this.type = type;
            }

            public readonly string name;
            public readonly ParamType type;

            public int size { get
                {
                    switch (type)
                    {
                        case ParamType.Int:
                            return 4;
                        case ParamType.DynamicValue:
                            return 5;
                        case ParamType.Byte:
                            return 1;
                        case ParamType.Short:
                            return 2;
                    }
                    throw new NotImplementedException("Param type not implemented!");
                } 
            }
        }

        public struct KCodeFunctionData
        {
            public KCodeFunction functionName;
            public KCodeParameter[] parameters;
            public int parametersLength { get
                {
                    if (parameters == null) return 0;
                    var count = 0;
                    foreach(var i in parameters)
                    {
                        count += i.size;
                    }
                    return count;
                } }
            public string comments;
        }

        public struct KCodeFunctionLine
        {
            public KCodeFunctionData function;
            public int address;
            public KCodeFunctionLine[] sub;

            private byte[] parameterBytes;

            public override string ToString()
            {
                return ToString(0);
            }

            public string ToString(int indent = 0, bool ReplaceNamesWithHex = false)
            {
                string[] values = new string[] { "UNDEFINED" };
                if (function.parameters != null)
                {
                    values = new string[function.parameters.Length];

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = GetParameter(i).ToString();
                    }
                }

                string name;
                if (!ReplaceNamesWithHex)
                {
                    name = function.functionName.ToString();
                    int parseResult;
                    if (int.TryParse(name, out parseResult))
                    {
                        name = "0x" + parseResult.ToString("X");
                    }
                }
                else
                {
                    name = "0x" + ((int)function.functionName).ToString("X");
                }
                string str = "";
                for (int i = 0; i < indent; i++)
                    str += "    ";
                str += string.Format("{0}({1}); // {2}\n",name, string.Join(", ",values), function.comments);
                if (sub != null && sub.Length > 0)
                {
                    for (int i = 0; i < indent; i++)
                        str += "    ";
                    str += "    @" + sub[0].address + ":\n";
                    foreach (var subLine in sub)
                    {
                        str += subLine.ToString(indent + 1, ReplaceNamesWithHex);
                    }
                }

                return str;
            }

            public object GetParameter(int index)
            {
                int offset = 0;

                for(int i = 0; i < index; i++)
                {
                    offset += function.parameters[i].size;
                }

                var paramdata = function.parameters[index];
                switch (paramdata.type)
                {
                    case KCodeParameter.ParamType.Int:
                        return BitConverter.ToInt32(parameterBytes, offset);
                    case KCodeParameter.ParamType.Short:
                        return BitConverter.ToInt16(parameterBytes, offset);
                    case KCodeParameter.ParamType.DynamicValue:
                        var dv = new DynamicValue();
                        dv.Flag = (DynamicValue.FlagType)parameterBytes[offset];
                        dv.Value = BitConverter.ToInt32(parameterBytes, offset+1);
                        return dv;
                    default:
                        return parameterBytes[offset];
                }
            }

            public void SetParameterBytes(byte[] bytes)
            {
                parameterBytes = bytes;
            }
        }

        public static readonly KCodeFunctionData[] FunctionData = new KCodeFunctionData[]
        {
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.Push0,
                parameters = new KCodeParameter[]
                {
                    
                },
                comments = "Pushes a 4 byte int with value 0 to the top of the stack of the EventObject."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.Push1,
                parameters = new KCodeParameter[]
                {

                },
                comments = "Pushes a 4 byte int with value 1 to the top of the stack of the EventObject."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.Push2,
                parameters = new KCodeParameter[]
                {

                },
                comments = "Pushes a 4 byte int with value 2 to the top of the stack of the EventObject."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.Push3,
                parameters = new KCodeParameter[]
                {

                },
                comments = "Pushes a 4 byte int with value 3 to the top of the stack of the EventObject."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.PushShort,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Value", KCodeParameter.ParamType.Short)
                },
                comments = "Pushes a 2 byte int with with a given value to the top of the stack of the EventObject."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.PushIntAndSkip,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Value", KCodeParameter.ParamType.Int),
                    new KCodeParameter("Unknown", KCodeParameter.ParamType.Byte)
                },
                comments = "Pushes a 4 byte int and skips a byte to the top of the stack of the EventObject."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.Jump,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Address", KCodeParameter.ParamType.Int)
                },
                comments = "Sets the address to a given value."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.JumpIfTrue,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Address", KCodeParameter.ParamType.Int),
                    new KCodeParameter("Unknown", KCodeParameter.ParamType.Byte)
                },
                comments = "Sets the address to a given value if the value at the top of the EventObject's stack is true."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.JumpIfFalse,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Address", KCodeParameter.ParamType.Int),
                    new KCodeParameter("Unknown", KCodeParameter.ParamType.Byte)
                },
                comments = "Sets the address to a given value if the value at the top of the EventObject's stack is false."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4a464d,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("UnknownInt", KCodeParameter.ParamType.Int)
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3150,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown3", KCodeParameter.ParamType.Byte)
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A2E88,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown3", KCodeParameter.ParamType.Byte)
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3B4A,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3BE2,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A4775,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("UnknownInt", KCodeParameter.ParamType.Int),
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.Pop_1,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A4882,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.DynamicValue),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.DynamicValue),
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A45AB,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown", KCodeParameter.ParamType.Int)
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A2ECC,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown3", KCodeParameter.ParamType.Byte)
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3B6D,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.Pop_2,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A486A,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Int),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Int),
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A2F65,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3A48,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3818,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A47AD,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown", KCodeParameter.ParamType.Int),
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A2DFA,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown3", KCodeParameter.ParamType.Byte)
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.Exit,
                parameters = new KCodeParameter[]
                {
                },
                comments = "Exit the script."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.PushNewDynamicValue0xe,
                parameters = new KCodeParameter[]
                {
                },
                comments = "Pushes a new" + DynamicValue.FlagType.pObject0xe + " object."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.JumpIfTrue6,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Address", KCodeParameter.ParamType.Int),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.JumpIfFalse6,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Address", KCodeParameter.ParamType.Int),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3B2C,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A39A2,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.DynamicValue),
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A2EEF,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.JumpToVariable,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("pAddress", KCodeParameter.ParamType.Int)
                },
                comments = "Jumps to the address specified by a 4 byte int at the given address."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A45C4,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown", KCodeParameter.ParamType.Int),
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3C3D,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown3", KCodeParameter.ParamType.Byte)
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A4354,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown3", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown4", KCodeParameter.ParamType.Byte),
                    new KCodeParameter("Unknown5", KCodeParameter.ParamType.Byte)
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3BC4,
                parameters = new KCodeParameter[]
                {
                }
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.JumpSkip8,
                parameters = new KCodeParameter[]
                {
                }
                ,comments = "Skips over 8 bytes."
            },
            new KCodeFunctionData()
            {
                functionName = KCodeFunction.U_4A3797,
                parameters = new KCodeParameter[]
                {
                    new KCodeParameter("Unknown1", KCodeParameter.ParamType.Short),
                    new KCodeParameter("Unknown2", KCodeParameter.ParamType.Byte),
                }
            },
            //new KCodeFunctionData()
            //{
            //    functionName = KCodeFunction.U_4A3818,
            //    parameters = new KCodeParameter[]
            //    {
            //    }
            //},
            //new KCodeFunctionData()
            //{
            //    functionName = KCodeFunction.U_4A3818,
            //    parameters = new KCodeParameter[]
            //    {
            //    }
            //},
            //new KCodeFunctionData()
            //{
            //    functionName = KCodeFunction.U_4A3818,
            //    parameters = new KCodeParameter[]
            //    {
            //    }
            //},
        };

        private StoryBase m_StoryBase;

        private byte GetByte(int instructionOffset) { return m_StoryBase.pInstructionArray.GetObjectInArray(instructionOffset).Value; }

        private int GetInt(int instructionOffset) { return BitConverter.ToInt32(new byte[] { GetByte(instructionOffset), GetByte(instructionOffset + 1), GetByte(instructionOffset + 2), GetByte(instructionOffset + 3) }, 0); }

        public KCodeFunctionData GetFunctionData(KCodeFunction function)
        {
            foreach(var item in FunctionData)
            {
                if (item.functionName == function)
                    return item;
            }
            return new KCodeFunctionData()
            {
                functionName = function
            };
        }

        public bool FunctionDataExists(KCodeFunction function)
        {
            foreach (var item in FunctionData)
            {
                if (item.functionName == function)
                    return true;
            }
            return false;
        }

        public byte[] GetVariables(int instructionOffset, int length)
        {
            byte[] a = new byte[length];
            for (int i = 1; i <= length; i++)
                a[i-1] = GameHook.storyBase.pInstructionArray.GetObjectInArray(instructionOffset + i).Value;
            return a;
        }

        public KCodeFunction GetCode(int instructionOffset)
        {
            return (KCodeFunction)GameHook.pProcessEventSwitch.GetObjectInArray((int)GameHook.pProcessEventSwitchArray.GetObjectInArray((int)GetByte(instructionOffset)-1).Value).Value;
        }

        private List<int> m_DecompiledOffsets = new List<int>();

        public KCodeFunctionLine[] Dissassemble(int startingOffset, bool isStart = true)
        {
            if (isStart)
            {
                m_StoryBase = GameHook.storyBase;
                m_DecompiledOffsets.Clear();
            }
            List<KCodeFunctionLine> lines = new List<KCodeFunctionLine>();

            int currentOffset = startingOffset;
            bool shouldExit = false;
            int count = 0;
            const int maxCount = 1000;
            while (!shouldExit && count++ < maxCount)
            {
                var currentInstruction = GetByte(currentOffset);
                if (0xb0 < currentInstruction - 1) break;
                var currentCode = GetCode(currentOffset);
                var currentData = GetFunctionData(currentCode);


                var nextLine = new KCodeFunctionLine()
                {
                    address = currentOffset,
                    function = currentData,
                    sub = null,
                };

                nextLine.SetParameterBytes(GetVariables(currentOffset, currentData.parametersLength));

                int jumpOffset;
                m_DecompiledOffsets.Add(currentOffset);
                switch (currentCode)
                {
                    case KCodeFunction.Jump:
                        // Set the next address to be the variable of this instruction.
                        currentOffset = (int)nextLine.GetParameter(0);
                        if (m_DecompiledOffsets.Contains(currentOffset))
                            shouldExit = true;
                        break;
                    case KCodeFunction.JumpIfTrue:
                    case KCodeFunction.JumpIfFalse:
                        jumpOffset = (int)nextLine.GetParameter(0);
                        if(!m_DecompiledOffsets.Contains(jumpOffset))
                            nextLine.sub = Dissassemble(jumpOffset,false);
                        currentOffset += currentData.parametersLength > 0 ? currentData.parametersLength : 1;
                        break;
                    case KCodeFunction.JumpIfTrue6:
                    case KCodeFunction.JumpIfFalse6:
                        jumpOffset = (int)nextLine.GetParameter(1);
                        if (!m_DecompiledOffsets.Contains(jumpOffset))
                            nextLine.sub = Dissassemble(jumpOffset,false);
                        currentOffset += currentData.parametersLength > 0 ? currentData.parametersLength : 1;
                        break;
                    case KCodeFunction.JumpSkip8:
                        currentOffset += 8;
                        break;
                    case KCodeFunction.JumpToVariable:
                        jumpOffset = (int)nextLine.GetParameter(1) + 1;
                        currentOffset = GetInt(jumpOffset);
                        nextLine.function.comments += " Jumped to " + currentOffset + ".";
                        if (m_DecompiledOffsets.Contains(currentOffset))
                            shouldExit = true;
                        break;
                    case KCodeFunction.Exit:
                        shouldExit = true;
                        break;
                    default:
                        // Set the next address to be the instruction after the variables of the previous instruction.
                        currentOffset += currentData.parametersLength > 0 ? currentData.parametersLength : 1;
                        break;
                }

                if (!FunctionDataExists(currentCode))
                {
                    nextLine.function.comments = "Function data not found! Unable to continue.";
                    shouldExit = true; ;
                }

                if (count >= maxCount)
                    nextLine.function.comments += "\n" + count + " lines decompiled, terminating.";

                lines.Add(nextLine);

            }

            return lines.ToArray();
        }

    }
}
