using CommonToolLib.ProcessHooking;
using XCommonLib.RAM.Generics;
using System;
using System.Collections.Generic;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptInstance : MemoryObject, INumericIDObject
    {
        public struct FunctionInfo
        {
            public int Class;
            public ScriptInstanceFunction Function;
        }

        #region Memory
        public abstract int NegativeID { get; set; }
        public abstract int ReferenceCount { get; set; }
        public abstract ScriptInstanceTypeDef TypeDef {get;}
        public abstract MemoryObjectPointer<DynamicValue> pScriptVariableArr { get; set; }
        #endregion

        public ScriptInstanceType ReferenceType;
        private int _GetVariableIndex(string name)
        {
            for (int index = 0; index < ReferenceType.Variables.Length; index++)
            {
                if (ReferenceType.Variables[index].Name == name)
                    return index;
            }
            throw new IndexOutOfRangeException();
        }

        public ScriptInstanceTypeDef[] GetAllTypeDefs()
        {
            List<ScriptInstanceTypeDef> result = new List<ScriptInstanceTypeDef>();
            for (var typedef = TypeDef; typedef != null; typedef = typedef.BaseType)
            {
                result.Add(typedef);
            }
            return result.ToArray();
        }

        public FunctionInfo[] GetAllFunctions()
        {
            List<FunctionInfo> result = new List<FunctionInfo>();
            for(var typedef = TypeDef; typedef != null; typedef = typedef.BaseType)
            {
                foreach (var func in typedef.Functions)
                {
                    result.Add(new FunctionInfo()
                    {
                        Function = func,
                        Class = typedef.Class
                    });
                }
            }
            return result.ToArray();
        }

        public int[] GetClassStructure()
        {
            List<int> result = new List<int>();
            for (var typedef = TypeDef; typedef != null; typedef = typedef.BaseType)
            {
                result.Add(typedef.Class);
            }
            return result.ToArray();
        }

        public DynamicValue GetVariable(string name)
        {
            return pScriptVariableArr.GetObjectInArray(_GetVariableIndex(name));
        }

        public void SetVariable(string name, DynamicValue value)
        {
            pScriptVariableArr.SetObjectInArray(_GetVariableIndex(name), value);
        }

        public int ID => -NegativeID - 1;
    }
}
