using System;
using System.Collections.Generic;
using System.IO;

namespace CommonToolLib.ProcessHooking
{
    public static class ScriptAssembler
    {
        #region Types
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
            public enum InsertionType
            {
                Undefined,
                Event,
                Inline
            }

            // The number of free bytes that should be allocated
            public int DataSize { get; internal set; }
            // The name of the script
            public string Name { get; internal set; }

            public InsertionType Type { get; internal set; }

            // The name of the event this script is intended to be attached to
            public string Event { get; internal set; }
            // The address this code is intended to go to
            public IntPtr InlineAddress { get; internal set; }
            public int InlineNOP { get; internal set; }
            public bool InlineOverwrite { get; internal set; }

            // The machine code of the script
            public byte[] Code { get; internal set; }
        }
        #endregion

        #region Parsing
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
                Type = ScriptCode.InsertionType.Undefined,
                Event = null,
                InlineAddress = IntPtr.Zero,
                InlineNOP = 0,
                InlineOverwrite = false,
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
                        string metaName = parsed[0];
                        string[] metaParams = parsed[1].Split(' ');

                        switch (metaName.ToUpper())
                        {
                            case "DATA":
                                int result;
                                if (int.TryParse(metaParams[0], out result))
                                {
                                    filecode.DataSize = result;
                                }

                                break;
                            case "TYPE":
                                if (filecode.Type != ScriptCode.InsertionType.Undefined)
                                    throw new InvalidModCodeMetaException();
                                switch (metaParams[0].ToUpper())
                                {
                                    case "EVENT":
                                        filecode.Type = ScriptCode.InsertionType.Event;
                                        filecode.Event = metaParams[1];
                                        break;
                                    case "INLINE":
                                        filecode.Type = ScriptCode.InsertionType.Inline;
                                        filecode.InlineAddress = (IntPtr)int.Parse(metaParams[1], System.Globalization.NumberStyles.HexNumber);
                                        filecode.InlineNOP = int.Parse(metaParams[2]);
                                        filecode.InlineOverwrite = bool.Parse(metaParams[3]);
                                        break;
                                    default:
                                        throw new InvalidModCodeMetaException();
                                }
                                break;
                            case "NAME":
                                filecode.Name = metaParams[0];
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

                                Instructions.AddRange(NOPs(count));
                                break;
                            // Ret
                            case "RET":
                                Instructions.Add(0xc3);
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

        public static x86Register RegisterParse(string register)
        {
            switch (register.ToUpper())
            {
                case "EAX": return x86Register.EAX;
                case "EBX": return x86Register.EBX;
                case "ECX": return x86Register.ECX;
                case "EDX": return x86Register.EDX;
                case "[EAX]": return x86Register.pEAX;
                case "[EBX]": return x86Register.pEBX;
                case "[ECX]": return x86Register.pECX;
                case "[EDX]": return x86Register.pEDX;
                default: throw new Exception("Register " + register + " invalid.");
            }
        }
        #endregion

        #region Primative Assembly Generation
        /// <summary>
        /// Length: 1
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// Length: 1
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// Length (address in register): 5
        /// Length (address pointed to in register): 6
        /// </summary>
        /// <param name="register"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static byte[] SetRegister(x86Register register, uint value)
        {
            List<byte> Instructions = new List<byte>();
            switch (register)
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

            Instructions.AddRange(BitConverter.GetBytes(value));
            return Instructions.ToArray();
        }
        /// <summary>
        /// Length: 2
        /// </summary>
        /// <param name="destRegister"></param>
        /// <param name="register"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static byte[] SetRegister(x86Register destRegister, x86Register register)
        {
            List<byte> Instructions = new List<byte>(); // { 0x8b, 0x00 };

            switch (destRegister)
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
            if (destRegister == x86Register.EAX && register == x86Register.EAX)
            {
                Instructions.Add(0xc0);
            }
            else if (destRegister == x86Register.EAX && register == x86Register.EBX)
            {
                Instructions.Add(0xc3);
            }
            else if (destRegister == x86Register.EAX && register == x86Register.ECX)
            {
                Instructions.Add(0xc1);
            }
            else if (destRegister == x86Register.EAX && register == x86Register.EDX)
            {
                Instructions.Add(0xc2);
            }
            else if (destRegister == x86Register.EAX && register == x86Register.pEAX)
            {
                Instructions.Add(0x00);
            }
            else if (destRegister == x86Register.EAX && register == x86Register.pEBX)
            {
                Instructions.Add(0x03);
            }
            else if (destRegister == x86Register.EAX && register == x86Register.pECX)
            {
                Instructions.Add(0x01);
            }
            else if (destRegister == x86Register.EAX && register == x86Register.pEDX)
            {
                Instructions.Add(0x02);
            }

            // EBX                                                                              
            else if (destRegister == x86Register.EBX && register == x86Register.EAX)
            {
                Instructions.Add(0xd8);
            }
            else if (destRegister == x86Register.EBX && register == x86Register.EBX)
            {
                Instructions.Add(0xdb);
            }
            else if (destRegister == x86Register.EBX && register == x86Register.ECX)
            {
                Instructions.Add(0xd9);
            }
            else if (destRegister == x86Register.EBX && register == x86Register.EDX)
            {
                Instructions.Add(0xDA);
            }
            else if (destRegister == x86Register.EBX && register == x86Register.pEAX)
            {
                Instructions.Add(0x18);
            }
            else if (destRegister == x86Register.EBX && register == x86Register.pEBX)
            {
                Instructions.Add(0x1b);
            }
            else if (destRegister == x86Register.EBX && register == x86Register.pECX)
            {
                Instructions.Add(0x19);
            }
            else if (destRegister == x86Register.EBX && register == x86Register.pEDX)
            {
                Instructions.Add(0x1a);
            }

            // ECX                                                                                
            else if (destRegister == x86Register.ECX && register == x86Register.EAX)
            {
                Instructions.Add(0xc8);
            }
            else if (destRegister == x86Register.ECX && register == x86Register.EBX)
            {
                Instructions.Add(0xcb);
            }
            else if (destRegister == x86Register.ECX && register == x86Register.ECX)
            {
                Instructions.Add(0xc9);
            }
            else if (destRegister == x86Register.ECX && register == x86Register.EDX)
            {
                Instructions.Add(0xca);
            }
            else if (destRegister == x86Register.ECX && register == x86Register.pEAX)
            {
                Instructions.Add(0x08);
            }
            else if (destRegister == x86Register.ECX && register == x86Register.pEBX)
            {
                Instructions.Add(0x0b);
            }
            else if (destRegister == x86Register.ECX && register == x86Register.pECX)
            {
                Instructions.Add(0x09);
            }
            else if (destRegister == x86Register.ECX && register == x86Register.pEDX)
            {
                Instructions.Add(0x0a);
            }

            // EDX                                                                            
            else if (destRegister == x86Register.EDX && register == x86Register.EAX)
            {
                Instructions.Add(0xd0);
            }
            else if (destRegister == x86Register.EDX && register == x86Register.EBX)
            {
                Instructions.Add(0xd3);
            }
            else if (destRegister == x86Register.EDX && register == x86Register.ECX)
            {
                Instructions.Add(0xd1);
            }
            else if (destRegister == x86Register.EDX && register == x86Register.EDX)
            {
                Instructions.Add(0xd2);
            }
            else if (destRegister == x86Register.EDX && register == x86Register.pEAX)
            {
                Instructions.Add(0x10);
            }
            else if (destRegister == x86Register.EDX && register == x86Register.pEBX)
            {
                Instructions.Add(0x13);
            }
            else if (destRegister == x86Register.EDX && register == x86Register.pECX)
            {
                Instructions.Add(0x11);
            }
            else if (destRegister == x86Register.EDX && register == x86Register.pEDX)
            {
                Instructions.Add(0x12);
            }



            // pEAX
            else if (destRegister == x86Register.pEAX && register == x86Register.EAX)
            {
                Instructions.Add(0x00);
            }
            else if (destRegister == x86Register.pEAX && register == x86Register.EBX)
            {
                Instructions.Add(0x18);
            }
            else if (destRegister == x86Register.pEAX && register == x86Register.ECX)
            {
                Instructions.Add(0x08);
            }
            else if (destRegister == x86Register.pEAX && register == x86Register.EDX)
            {
                Instructions.Add(0x10);
            }

            // pEBX                                                                              
            else if (destRegister == x86Register.pEBX && register == x86Register.EAX)
            {
                Instructions.Add(0x03);
            }
            else if (destRegister == x86Register.pEBX && register == x86Register.EBX)
            {
                Instructions.Add(0x1b);
            }
            else if (destRegister == x86Register.pEBX && register == x86Register.ECX)
            {
                Instructions.Add(0x0b);
            }
            else if (destRegister == x86Register.pEBX && register == x86Register.EDX)
            {
                Instructions.Add(0x13);
            }

            // pECX                                                                                
            else if (destRegister == x86Register.pECX && register == x86Register.EAX)
            {
                Instructions.Add(0x01);
            }
            else if (destRegister == x86Register.pECX && register == x86Register.EBX)
            {
                Instructions.Add(0x19);
            }
            else if (destRegister == x86Register.pECX && register == x86Register.ECX)
            {
                Instructions.Add(0x09);
            }
            else if (destRegister == x86Register.pECX && register == x86Register.EDX)
            {
                Instructions.Add(0x11);
            }
            // pEDX                                                                            
            else if (destRegister == x86Register.pEDX && register == x86Register.EAX)
            {
                Instructions.Add(0x02);
            }
            else if (destRegister == x86Register.pEDX && register == x86Register.EBX)
            {
                Instructions.Add(0x1a);
            }
            else if (destRegister == x86Register.pEDX && register == x86Register.ECX)
            {
                Instructions.Add(0x0a);
            }
            else if (destRegister == x86Register.pEDX && register == x86Register.EDX)
            {
                Instructions.Add(0x12);
            }
            else
            {
                throw new NotImplementedException(string.Format("SetRegister: Combination of {0} and {1} not implemented or invalid.", destRegister.ToString(), register.ToString()));
            }

            return Instructions.ToArray();
        }

        /// <summary>
        /// Call address from register.
        /// Length: 2
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static byte[] CallRegister(x86Register register)
        {
            byte[] temp = new byte[2];
            temp[0] = 0xff;
            switch (register)
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

        /// <summary>
        /// Jump Instruction.
        /// Length: 2
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static byte[] JumpRegister(x86Register register)
        {
            byte[] temp = new byte[2];
            temp[0] = 0xff;
            switch (register)
            {
                case x86Register.EAX: temp[1] = 0xE0; break;
                case x86Register.EBX: temp[1] = 0xE3; break;
                case x86Register.ECX: temp[1] = 0xE1; break;
                case x86Register.EDX: temp[1] = 0xE2; break;
                case x86Register.pEAX: temp[1] = 0x20; break;
                case x86Register.pEBX: temp[1] = 0x23; break;
                case x86Register.pECX: temp[1] = 0x21; break;
                case x86Register.pEDX: temp[1] = 0x22; break;
                default:
                    throw new NotImplementedException();
            }
            return temp;
        }

        /// <summary>
        /// Returns an array of NOP instructions.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static byte[] NOPs(int count = 1)
        {
            byte[] temp = new byte[count];
            for(int i = 0; i < count; i++)
            {
                temp[i] = 0x90;
            }
            return temp;
        }
        #endregion
        /// <summary>
        /// Uses a register to call an absolute address.
        /// Length: 7
        /// </summary>
        /// <param name="address"></param>
        /// <param name="register"></param>
        /// <returns></returns>
        public static byte[] FarCall(IntPtr address, x86Register register)
        {
            List<byte> code = new List<byte>();
            code.AddRange(SetRegister(register, (uint)address));
            code.AddRange(CallRegister(register));
            return code.ToArray();
        }
        /// <summary>
        /// Uses a register to jump to an absolute address.
        /// Length: 7
        /// </summary>
        /// <param name="address"></param>
        /// <param name="register"></param>
        /// <returns></returns>
        public static byte[] FarJump(IntPtr address, x86Register register)
        {
            List<byte> code = new List<byte>();
            code.AddRange(SetRegister(register, (uint)address));
            code.AddRange(JumpRegister(register));
            return code.ToArray();
        }
    }
}
