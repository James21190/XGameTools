using CommonToolLib.ProcessHooking;
using XCommonLib.RAM.Generics;
using System;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptInstance : MemoryObject, INumericIDObject
    {
        #region Memory
        public abstract int NegativeID { get; set; }
        public abstract int Class { get; set; }
        public abstract int ReferenceCount { get; set; }
        public abstract int ScriptVariableCount { get; set; }
        public abstract MemoryObjectPointer<DynamicValue> pScriptVariableArr { get; set; }
        #endregion

        public ScriptInstanceType ReferenceType;
        private int _GetVariableIndex(string name)
        {
            for (int index = 0; index < ScriptVariableCount && index < ReferenceType.Variables.Length; index++)
            {
                if (ReferenceType.LocalVariables[index].Name == name)
                    return index;
            }
            throw new IndexOutOfRangeException();
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
