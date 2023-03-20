﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.SimpleScript
{
    public class SimpleScript
    {
        public class SimpleScriptCodeBlock
        {
            public class SimpleScriptInstruction
            {
                public enum InstructionType
                {
                    MOV,
                    CALL,
                    JL,
                    SUB
                }

                public class SimpleScriptInstructionParameter
                {
                    public enum ParameterType
                    {
                        Register,
                        Variable
                    }
                    public ParameterType Type;
                    public object Value;

                    public override string ToString()
                    {
                        return Value.ToString();
                    }
                }

                public InstructionType Type;
                public SimpleScriptInstructionParameter[] Parameters;
                public override string ToString()
                {
                    string param = "";
                    foreach(var parameter in Parameters)
                        param += " " + parameter.ToString();
                    return Type.ToString() + param + ";";
                }
            }
            public string Label;
            public SimpleScriptInstruction[] Instructions;
        }

        public SimpleScriptVariable[] Variables;
        public SimpleScriptCodeBlock[] CodeBlocks;
        public static SimpleScript LoadSource(string source)
        {
            // Clean the source and remove unneeded characters
            source = _CleanSource(source);
#if DEBUG
            File.WriteAllText("./SimpleScriptDebug_PostClean.txt", source);
#endif
            // Get tokens
            var tokens = _CleanToTokens(source);

#if DEBUG
            using(var sw = new StreamWriter("./SimpleScriptDebug_PostToken.txt"))
                foreach(var token in tokens)
                {
                    sw.WriteLine(token.ToString());
                }
#endif

            var variables = new List<SimpleScriptVariable>();
            var codeBlocks = new List<SimpleScriptCodeBlock>();

            var currentCodeBlockLabel = "entry";
            var currentCodeBlockInstuctions = new List<SimpleScriptCodeBlock.SimpleScriptInstruction>();

            bool variableIsStatic;
            bool variableIsConfigureable;
            bool variableIsConstant;

            bool isInInstruction;
            var currentCodeBlockInstructionType = SimpleScriptCodeBlock.SimpleScriptInstruction.InstructionType.MOV;
            var currentCodeBlockInstructionParameters = new List<SimpleScriptCodeBlock.SimpleScriptInstruction.SimpleScriptInstructionParameter>();

            void ResetState()
            {
                variableIsStatic = false;
                variableIsConfigureable = false;
                variableIsConstant = false;
                isInInstruction = false;
                currentCodeBlockInstructionParameters.Clear();
            }

            ResetState();

            for(int i = 0; i < tokens.Length; i++)
            {
                var currentToken = tokens[i];
                switch (currentToken.Type)
                {
                    case Token.TokenType.Keyword:
                        switch ((string)currentToken.Value)
                        {
                            // Is it stored in memory
                            case "static":
                                variableIsStatic = true;
                                break;
                            // Is it configureable at compile time 
                            case "config":
                                variableIsConfigureable = true;
                                break;
                            // Does it replace other parts of the code
                            case "const":
                                variableIsConstant = true;
                                break;
                        }
                        break;
                    case Token.TokenType.VariableName:
                        if (isInInstruction)
                        {
                            currentCodeBlockInstructionParameters.Add(new SimpleScriptCodeBlock.SimpleScriptInstruction.SimpleScriptInstructionParameter()
                            {
                                Type = SimpleScriptCodeBlock.SimpleScriptInstruction.SimpleScriptInstructionParameter.ParameterType.Variable,
                                Value = currentToken.Value
                            });
                        }
                        break;
                    case Token.TokenType.Register:
                        if (isInInstruction)
                        {
                            if (isInInstruction)
                            {
                                currentCodeBlockInstructionParameters.Add(new SimpleScriptCodeBlock.SimpleScriptInstruction.SimpleScriptInstructionParameter()
                                {
                                    Type = SimpleScriptCodeBlock.SimpleScriptInstruction.SimpleScriptInstructionParameter.ParameterType.Register,
                                    Value = currentToken.Value
                                });
                            }
                        }
                        break;
                    case Token.TokenType.VariableType:
                        #region VariableType
                        var newVariable = new SimpleScriptVariable();
                        // Get the type
                        newVariable.Type = (SimpleScriptVariableType)currentToken.Value;

                        // Get the name
                        currentToken = tokens[++i];
                        if (currentToken.Type != Token.TokenType.VariableName)
                            throw new Exception();

                        // Ensure no other variable of the same name exists already.
                        foreach (var variable in variables)
                            if (variable.Name == (string)currentToken.Value)
                                throw new Exception("Multiple variables have the name " + variable.Name);

                        newVariable.Name = (string)currentToken.Value;

                        // Get default value if there is one
                        currentToken = tokens[++i];
                        switch (currentToken.Type)
                        {
                            case Token.TokenType.LiteralByte:
                            case Token.TokenType.LiteralShort:
                            case Token.TokenType.LiteralInt:
                            case Token.TokenType.LiteralLong:
                                newVariable.Value = currentToken.Value;

                                if (tokens[++i].Type != Token.TokenType.EndOfStatement)
                                    throw new Exception();
                                
                                break;
                            case Token.TokenType.EndOfStatement:
                                newVariable.Value = 0;
                                i--;
                                break;
                            default:
                                throw new Exception();
                        }

                        // Set flags
                        if (variableIsConstant)
                            newVariable.Location = SimpleScriptVariableLocation.Constant;
                        else if (variableIsStatic)
                            newVariable.Location = SimpleScriptVariableLocation.Static;
                        else
                            newVariable.Location = SimpleScriptVariableLocation.Local;

                        newVariable.Configureable = variableIsConfigureable;

                        // Add to variable list
                        variables.Add(newVariable);
                        
                        break;
                    #endregion
                    case Token.TokenType.Label:
                        // If label is encountered, start new code block
                        codeBlocks.Add(new SimpleScriptCodeBlock()
                        {
                            Label = currentCodeBlockLabel,
                            Instructions = currentCodeBlockInstuctions.ToArray()
                        });
                        currentCodeBlockLabel = (string)currentToken.Value;
                        currentCodeBlockInstuctions.Clear();
                        break;
                    case Token.TokenType.Instruction:
                        switch ((string)currentToken.Value)
                        {
                            case "mov":
                                currentCodeBlockInstructionType = SimpleScriptCodeBlock.SimpleScriptInstruction.InstructionType.MOV;
                                break;
                            case "call":
                                currentCodeBlockInstructionType = SimpleScriptCodeBlock.SimpleScriptInstruction.InstructionType.CALL;
                                break;
                            case "sub":
                                currentCodeBlockInstructionType = SimpleScriptCodeBlock.SimpleScriptInstruction.InstructionType.SUB;
                                break;
                            case "jl":
                                currentCodeBlockInstructionType = SimpleScriptCodeBlock.SimpleScriptInstruction.InstructionType.JL;
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        isInInstruction = true;
                        break;
                    case Token.TokenType.EndOfStatement:
                        if (isInInstruction)
                        {
                            var newInstruction = new SimpleScriptCodeBlock.SimpleScriptInstruction();
                            newInstruction.Type = currentCodeBlockInstructionType;
                            newInstruction.Parameters = currentCodeBlockInstructionParameters.ToArray();
                            currentCodeBlockInstuctions.Add(newInstruction);
                        }
                        ResetState();
                        break;
                }
            }

            // Append final code block
            codeBlocks.Add(new SimpleScriptCodeBlock()
            {
                Label = currentCodeBlockLabel,
                Instructions = currentCodeBlockInstuctions.ToArray()
            });

            // Generate final object and return
            var result = new SimpleScript();

            result.Variables = variables.ToArray();
            result.CodeBlocks = codeBlocks.ToArray();

            return result;
        }

        private static string _CleanSource(string source)
        {
            // Remove comments
            StringBuilder cleanedSB = new StringBuilder();

            // 0: Not a comment
            // 1: Single slash
            // 2: Line comment
            // 3: Block comment
            // 4: Block comment star
            byte CommentStatus = 0;
            bool LastWasSpace = false;

            void AppendCharToCleanedSB(char character)
            {
                if (character == '\n' || character == '\r')
                    return;
                if (character == ' ')
                {
                    if (!LastWasSpace)
                    {
                        cleanedSB.Append(' ');
                        LastWasSpace = true;
                    }
                }
                else
                {
                    cleanedSB.Append(character);
                    LastWasSpace = false;
                }
            }

            foreach (var character in source)
            {
                switch (CommentStatus)
                {
                    case 0:
                        if (character == '/')
                        {
                            CommentStatus = 1;
                        }
                        else
                        {
                            AppendCharToCleanedSB(character);
                        }
                        break;
                    case 1:
                        if (character == '/')
                        {
                            CommentStatus = 2;
                        }
                        else if (character == '*')
                        {
                            CommentStatus = 3;
                        }
                        else
                        {
                            cleanedSB.Append('/');
                            AppendCharToCleanedSB(character);
                        }
                        break;
                    case 2:
                        if (character == '\n')
                            CommentStatus = 0;
                        break;
                    case 3:
                        if (character == '*')
                            CommentStatus = 4;
                        break;
                    case 4:
                        if (character == '/')
                            CommentStatus = 0;
                        break;
                }
            }
            return cleanedSB.ToString();
        }

        private static Token[] _StringTokenToToken(string stringToken)
        {
            List<Token> result = new List<Token>();
            var currentStringToken = stringToken;

            // Lables
            var labelCheck = stringToken.Split(':');
            if (labelCheck.Length > 1)
            {
                result.Add(new Token() { Type = Token.TokenType.Label, Value = labelCheck[0] });
                currentStringToken = labelCheck[1];
            }

            var newToken = new Token();
            // Int literals
            int numberConstant;
            if (int.TryParse(currentStringToken, out numberConstant) || int.TryParse(currentStringToken, System.Globalization.NumberStyles.HexNumber, null, out numberConstant))
            {
                newToken.Type = Token.TokenType.LiteralInt;
                newToken.Value = numberConstant;
            }
            else
            {
                switch (currentStringToken)
                {
                    case "config":
                    case "static":
                    case "const":
                    case "explicit":
                        newToken.Type = Token.TokenType.Keyword;
                        newToken.Value = currentStringToken;
                        break;

                    case "byte":
                        newToken.Type = Token.TokenType.VariableType;
                        newToken.Value = SimpleScriptVariableType.ssByte;
                        break;

                    case "short":
                        newToken.Type = Token.TokenType.VariableType;
                        newToken.Value = SimpleScriptVariableType.ssShort;
                        break;

                    case "int":
                        newToken.Type = Token.TokenType.VariableType;
                        newToken.Value = SimpleScriptVariableType.ssInt;
                        break;

                    case "long":
                        newToken.Type = Token.TokenType.VariableType;
                        newToken.Value = SimpleScriptVariableType.ssLong;
                        break;

                    case "mov":
                    case "sub":
                    case "add":
                    case "call":
                    case "ret":
                    case "jl":
                    case "jmp":
                    case "je":
                        newToken.Type = Token.TokenType.Instruction;
                        newToken.Value = currentStringToken;
                        break;

                    case "eax":
                    case "ebx":
                    case "ecx":
                    case "edx":
                        newToken.Type = Token.TokenType.Register;
                        newToken.Value = currentStringToken;
                        break;

                    default:
                        newToken.Type = Token.TokenType.VariableName;
                        newToken.Value = currentStringToken;
                        break;
                }

            }
            result.Add(newToken);
            return result.ToArray();
        }

        private static Token[] _CleanToTokens(string cleanSource)
        {
            List<Token> tokens = new List<Token>();

            var statements = cleanSource.Split(';');
            foreach(var statement in statements)
            {
                var stringTokens = statement.Split(' ');
                foreach(var stringToken in stringTokens)
                {
                    tokens.AddRange(_StringTokenToToken(stringToken));
                }
                tokens.Add(new Token() { Type = Token.TokenType.EndOfStatement});
            }

            return tokens.ToArray();
        }

        public void SetConfigureableValue(string name, object value)
        {
            throw new NotImplementedException();
        }

        public byte[] Compile()
        {
            throw new NotImplementedException();
        }
    }
}
