using System;
using System.Collections.Generic;
using System.IO;

namespace CommonToolLib.ProcessHooking
{
    public static class ScriptAssembler
    {
        public enum x86Register
        {
            EAX,
            EBX,
            ECX,
            EDX,
            pEAX,
            pEBX,
            pECX,
            pEDX,
        }

        public struct ScriptCode
        {
            // The number of free bytes that should be allocated
            public int DataSize;
            // The name of the script
            public string Name;

            // The name of the event this script is intended to be attached to
            public string Event;
            // The address this code is intended to go to
            public IntPtr IntendedAddress;

            // The machine code of the script
            public byte[] Code;
        }

        public static ScriptCode ParseScript(string path)
        {
            return ParseScript(File.ReadAllLines(path));
        }

        /// <summary>
        /// Converts a text script into assembly.
        /// </summary>
        /// <param name="Script"></param>
        /// <returns></returns>
        public static ScriptCode ParseScript(string[] Script)
        {
            // Key
            // '#' Meta data
            // '/' Comments
            // '-' Is macro
            // Number is direct assembly

            List<byte> Instructions = new List<byte>();

            ScriptCode filecode = new ScriptCode()
            {
                DataSize = 0,
                Name = "Unnamed",
                Event = null,
                IntendedAddress = IntPtr.Zero,
                Code = null
            };
            // Itterate through every line
            foreach (string line in Script)
            {
                // If line is not blank and line is not a comment
                if (!string.IsNullOrWhiteSpace(line) && line[0] != '/')
                {
                    // If line is meta data
                    if (line[0] == '#')
                    {
                        string[] parsed = line.Trim('#', ' ').Split(':');
                        if (parsed.Length != 2)
                        {
                            throw new InvalidModCodeMetaException();
                        }

                        switch (parsed[0].ToUpper())
                        {
                            case "DATA":
                                int result;
                                if (int.TryParse(parsed[1], out result))
                                {
                                    filecode.DataSize = result;
                                }

                                break;
                            case "EVENT":
                                filecode.Event = parsed[1];
                                break;
                            case "ADDRESS":
                                filecode.IntendedAddress = (IntPtr)int.Parse(parsed[1], System.Globalization.NumberStyles.HexNumber);
                                break;
                            case "NAME":
                                filecode.Name = parsed[1];
                                break;
                            default:
                                throw new InvalidModCodeMetaException();

                        }
                    }
                    // If line is a macro
                    else if (line[0] == '-')
                    {
                        string[] code = line.Trim('-', ' ').Split(' ');
                        if (code.Length < 1)
                        {
                            throw new ArgumentException();
                        }

                        switch (code[0].ToUpper())
                        {
                            // FarCall <Address> <Register>
                            case "FARCALL":
                                Instructions.AddRange(FarCall((IntPtr)int.Parse(code[1], System.Globalization.NumberStyles.HexNumber), RegisterParse(code[2])));
                                break;
                            // Mov <Register> <Value>
                            // Mov <Register> <Register>
                            case "MOV":
                                uint res;
                                if (uint.TryParse(code[2], System.Globalization.NumberStyles.HexNumber, null, out res))
                                {
                                    Instructions.AddRange(SetRegister(RegisterParse(code[1]), res));
                                }
                                else
                                {
                                    Instructions.AddRange(SetRegister(RegisterParse(code[1]), RegisterParse(code[2])));
                                }
                                break;
                            // Nop <count>
                            case "NOP":
                                int count = int.Parse(code[1], System.Globalization.NumberStyles.HexNumber);
                                byte[] temp = new byte[count];
                                for (int i = 0; i < count; i++)
                                {
                                    temp[i] = 0x90;
                                }

                                Instructions.AddRange(temp);
                                break;
                            // Pop <Register>
                            case "POP":
                                Instructions.AddRange(Pop(RegisterParse(code[1])));
                                break;
                            // Push <Register>
                            case "PUSH":
                                Instructions.AddRange(Push(RegisterParse(code[1])));
                                break;
                            default:
                                throw new ArgumentException("Macro " + code[0] + " not found.");
                        }
                    }
                    // If line is numeric
                    else
                    {
                        string[] code = line.Split(' ');
                        foreach (string instruction in code)
                        {
                            if (!string.IsNullOrWhiteSpace(instruction))
                            {
                                Instructions.Add(byte.Parse(instruction, System.Globalization.NumberStyles.HexNumber));
                            }
                        }
                    }
                }
            }

            filecode.Code = Instructions.ToArray();
            return filecode;
        }

        public static x86Register RegisterParse(string Register)
        {
            switch (Register.ToUpper())
            {
                case "EAX": return x86Register.EAX;
                case "EBX": return x86Register.EBX;
                case "ECX": return x86Register.ECX;
                case "EDX": return x86Register.EDX;
                case "[EAX]": return x86Register.pEAX;
                case "[EBX]": return x86Register.pEBX;
                case "[ECX]": return x86Register.pECX;
                case "[EDX]": return x86Register.pEDX;
                default: throw new Exception("Register " + Register + " invalid.");
            }
        }

        public static byte[] Push(x86Register register)
        {
            switch (register)
            {
                case x86Register.EAX:
                    return new byte[] { 0x50 };
                case x86Register.EBX:
                    return new byte[] { 0x53 };
                case x86Register.ECX:
                    return new byte[] { 0x51 };
                case x86Register.EDX:
                    return new byte[] { 0x52 };
                case x86Register.pEAX:
                    return new byte[] { 0xff, 0x30 };
                case x86Register.pEBX:
                    return new byte[] { 0xff, 0x33 };
                case x86Register.pECX:
                    return new byte[] { 0xff, 0x31 };
                case x86Register.pEDX:
                    return new byte[] { 0xff, 0x32 };
                default: throw new ArgumentException(string.Format("Register {0} not supported.", register.ToString()));
            }
        }

        public static byte[] Pop(x86Register register)
        {
            switch (register)
            {
                case x86Register.EAX:
                    return new byte[] { 0x58 };
                case x86Register.EBX:
                    return new byte[] { 0x5b };
                case x86Register.ECX:
                    return new byte[] { 0x59 };
                case x86Register.EDX:
                    return new byte[] { 0x5a };
                case x86Register.pEAX:
                    return new byte[] { 0x8f, 0x00 };
                case x86Register.pEBX:
                    return new byte[] { 0x8f, 0x03 };
                case x86Register.pECX:
                    return new byte[] { 0x8f, 0x01 };
                case x86Register.pEDX:
                    return new byte[] { 0x8f, 0x02 };
                default: throw new ArgumentException(string.Format("Register {0} not supported.", register.ToString()));
            }
        }

        public static byte[] FarCall(IntPtr Address, x86Register Register)
        {
            List<byte> code = new List<byte>();
            code.AddRange(SetRegister(Register, (uint)Address));
            code.AddRange(CallRegister(Register));
            return code.ToArray();
        }

        public static byte[] SetRegister(x86Register Register, uint Value)
        {
            List<byte> Instructions = new List<byte>();
            switch (Register)
            {
                case x86Register.EAX:
                    Instructions.Add(0xb8);
                    break;
                case x86Register.EBX:
                    Instructions.Add(0xbb);
                    break;
                case x86Register.ECX:
                    Instructions.Add(0xb9);
                    break;
                case x86Register.EDX:
                    Instructions.Add(0xba);
                    break;
                case x86Register.pEAX:
                    Instructions.AddRange(new byte[] { 0xc7, 0x00 });
                    break;
                case x86Register.pEBX:
                    Instructions.AddRange(new byte[] { 0xc7, 0x03 });
                    break;
                case x86Register.pECX:
                    Instructions.AddRange(new byte[] { 0xc7, 0x01 });
                    break;
                case x86Register.pEDX:
                    Instructions.AddRange(new byte[] { 0xc7, 0x02 });
                    break;
                default:
                    throw new NotImplementedException();
            }

            Instructions.AddRange(BitConverter.GetBytes(Value));
            return Instructions.ToArray();
        }

        public static byte[] SetRegister(x86Register DestRegister, x86Register Register)
        {
            List<byte> Instructions = new List<byte>(); // { 0x8b, 0x00 };

            switch (DestRegister)
            {
                case x86Register.EAX:
                case x86Register.EBX:
                case x86Register.ECX:
                case x86Register.EDX:
                    Instructions.Add(0x8b);
                    break;
                case x86Register.pEAX:
                case x86Register.pEBX:
                case x86Register.pECX:
                case x86Register.pEDX:
                    Instructions.Add(0x89);
                    break;
            }

            // EAX
            if (DestRegister == x86Register.EAX && Register == x86Register.EAX)
            {
                Instructions.Add(0xc0);
            }
            else if (DestRegister == x86Register.EAX && Register == x86Register.EBX)
            {
                Instructions.Add(0xc3);
            }
            else if (DestRegister == x86Register.EAX && Register == x86Register.ECX)
            {
                Instructions.Add(0xc1);
            }
            else if (DestRegister == x86Register.EAX && Register == x86Register.EDX)
            {
                Instructions.Add(0xc2);
            }
            else if (DestRegister == x86Register.EAX && Register == x86Register.pEAX)
            {
                Instructions.Add(0x00);
            }
            else if (DestRegister == x86Register.EAX && Register == x86Register.pEBX)
            {
                Instructions.Add(0x03);
            }
            else if (DestRegister == x86Register.EAX && Register == x86Register.pECX)
            {
                Instructions.Add(0x01);
            }
            else if (DestRegister == x86Register.EAX && Register == x86Register.pEDX)
            {
                Instructions.Add(0x02);
            }

            // EBX                                                                              
            else if (DestRegister == x86Register.EBX && Register == x86Register.EAX)
            {
                Instructions.Add(0xd8);
            }
            else if (DestRegister == x86Register.EBX && Register == x86Register.EBX)
            {
                Instructions.Add(0xdb);
            }
            else if (DestRegister == x86Register.EBX && Register == x86Register.ECX)
            {
                Instructions.Add(0xd9);
            }
            else if (DestRegister == x86Register.EBX && Register == x86Register.EDX)
            {
                Instructions.Add(0xDA);
            }
            else if (DestRegister == x86Register.EBX && Register == x86Register.pEAX)
            {
                Instructions.Add(0x18);
            }
            else if (DestRegister == x86Register.EBX && Register == x86Register.pEBX)
            {
                Instructions.Add(0x1b);
            }
            else if (DestRegister == x86Register.EBX && Register == x86Register.pECX)
            {
                Instructions.Add(0x19);
            }
            else if (DestRegister == x86Register.EBX && Register == x86Register.pEDX)
            {
                Instructions.Add(0x1a);
            }

            // ECX                                                                                
            else if (DestRegister == x86Register.ECX && Register == x86Register.EAX)
            {
                Instructions.Add(0xc8);
            }
            else if (DestRegister == x86Register.ECX && Register == x86Register.EBX)
            {
                Instructions.Add(0xcb);
            }
            else if (DestRegister == x86Register.ECX && Register == x86Register.ECX)
            {
                Instructions.Add(0xc9);
            }
            else if (DestRegister == x86Register.ECX && Register == x86Register.EDX)
            {
                Instructions.Add(0xca);
            }
            else if (DestRegister == x86Register.ECX && Register == x86Register.pEAX)
            {
                Instructions.Add(0x08);
            }
            else if (DestRegister == x86Register.ECX && Register == x86Register.pEBX)
            {
                Instructions.Add(0x0b);
            }
            else if (DestRegister == x86Register.ECX && Register == x86Register.pECX)
            {
                Instructions.Add(0x09);
            }
            else if (DestRegister == x86Register.ECX && Register == x86Register.pEDX)
            {
                Instructions.Add(0x0a);
            }

            // EDX                                                                            
            else if (DestRegister == x86Register.EDX && Register == x86Register.EAX)
            {
                Instructions.Add(0xd0);
            }
            else if (DestRegister == x86Register.EDX && Register == x86Register.EBX)
            {
                Instructions.Add(0xd3);
            }
            else if (DestRegister == x86Register.EDX && Register == x86Register.ECX)
            {
                Instructions.Add(0xd1);
            }
            else if (DestRegister == x86Register.EDX && Register == x86Register.EDX)
            {
                Instructions.Add(0xd2);
            }
            else if (DestRegister == x86Register.EDX && Register == x86Register.pEAX)
            {
                Instructions.Add(0x10);
            }
            else if (DestRegister == x86Register.EDX && Register == x86Register.pEBX)
            {
                Instructions.Add(0x13);
            }
            else if (DestRegister == x86Register.EDX && Register == x86Register.pECX)
            {
                Instructions.Add(0x11);
            }
            else if (DestRegister == x86Register.EDX && Register == x86Register.pEDX)
            {
                Instructions.Add(0x12);
            }



            // pEAX
            else if (DestRegister == x86Register.pEAX && Register == x86Register.EAX)
            {
                Instructions.Add(0x00);
            }
            else if (DestRegister == x86Register.pEAX && Register == x86Register.EBX)
            {
                Instructions.Add(0x18);
            }
            else if (DestRegister == x86Register.pEAX && Register == x86Register.ECX)
            {
                Instructions.Add(0x08);
            }
            else if (DestRegister == x86Register.pEAX && Register == x86Register.EDX)
            {
                Instructions.Add(0x10);
            }

            // pEBX                                                                              
            else if (DestRegister == x86Register.pEBX && Register == x86Register.EAX)
            {
                Instructions.Add(0x03);
            }
            else if (DestRegister == x86Register.pEBX && Register == x86Register.EBX)
            {
                Instructions.Add(0x1b);
            }
            else if (DestRegister == x86Register.pEBX && Register == x86Register.ECX)
            {
                Instructions.Add(0x0b);
            }
            else if (DestRegister == x86Register.pEBX && Register == x86Register.EDX)
            {
                Instructions.Add(0x13);
            }

            // pECX                                                                                
            else if (DestRegister == x86Register.pECX && Register == x86Register.EAX)
            {
                Instructions.Add(0x01);
            }
            else if (DestRegister == x86Register.pECX && Register == x86Register.EBX)
            {
                Instructions.Add(0x19);
            }
            else if (DestRegister == x86Register.pECX && Register == x86Register.ECX)
            {
                Instructions.Add(0x09);
            }
            else if (DestRegister == x86Register.pECX && Register == x86Register.EDX)
            {
                Instructions.Add(0x11);
            }
            // pEDX                                                                            
            else if (DestRegister == x86Register.pEDX && Register == x86Register.EAX)
            {
                Instructions.Add(0x02);
            }
            else if (DestRegister == x86Register.pEDX && Register == x86Register.EBX)
            {
                Instructions.Add(0x1a);
            }
            else if (DestRegister == x86Register.pEDX && Register == x86Register.ECX)
            {
                Instructions.Add(0x0a);
            }
            else if (DestRegister == x86Register.pEDX && Register == x86Register.EDX)
            {
                Instructions.Add(0x12);
            }
            else
            {
                throw new NotImplementedException(string.Format("SetRegister: Combination of {0} and {1} not implemented or invalid.", DestRegister.ToString(), Register.ToString()));
            }

            return Instructions.ToArray();
        }

        public static byte[] CallRegister(x86Register Register)
        {
            byte[] temp = new byte[2];
            temp[0] = 0xff;
            switch (Register)
            {
                case x86Register.EAX: temp[1] = 0xd0; break;
                case x86Register.EBX: temp[1] = 0xd3; break;
                case x86Register.ECX: temp[1] = 0xd1; break;
                case x86Register.EDX: temp[1] = 0xd2; break;
                case x86Register.pEAX: temp[1] = 0x10; break;
                case x86Register.pEBX: temp[1] = 0x13; break;
                case x86Register.pECX: temp[1] = 0x11; break;
                case x86Register.pEDX: temp[1] = 0x12; break;
                default:
                    throw new NotImplementedException();
            }
            return temp;
        }

    }
}
