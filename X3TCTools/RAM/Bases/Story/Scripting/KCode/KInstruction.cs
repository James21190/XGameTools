﻿using System;

namespace X3Tools.RAM.Bases.Story.Scripting.KCode
{
    public struct KInstruction
    {
        public int Address;
        public int CalledFunction;
        public KFunctionDefinition AssociatedDefinition;
        public object[] Parameters;

        public string ToString(bool ForceHex)
        {
            string FunctionName;
            if (AssociatedDefinition == null)
            {
                FunctionName = "UndefinedFunc0x" + CalledFunction.ToString("X");
            }
            else if (String.IsNullOrEmpty(AssociatedDefinition.FunctionName) || ForceHex)
            {
                FunctionName = "Func0x" + CalledFunction.ToString("X");
            }
            else
            {
                FunctionName = AssociatedDefinition.FunctionName;
            }

            string ParamString;
            if (Parameters != null)
            {
                ParamString = string.Join(",", Parameters);
            }
            else
            {
                ParamString = "";
            }

            return string.Format("{0} - {1} ({2})", Address, FunctionName, ParamString);
        }
    }
}
