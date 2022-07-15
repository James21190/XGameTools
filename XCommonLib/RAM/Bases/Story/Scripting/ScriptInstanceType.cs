using System.Collections.Generic;
using System.IO;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstanceType
    {
        public enum VariableType
        {
            None,
            ScriptInstanceID,
            Array,
            Table,
            Object
        }

        public struct VariableData
        {
            public string Name;
            public VariableType Type;
            public object Additional;

            public override string ToString()
            {
                if (Additional == null)
                    return Type.ToString() + " " + Name;
                else
                    return Type.ToString() + " " + Additional.ToString() + " " + Name;
            }
        }
        public string Name;
        public int TypeID;
        public ScriptInstanceType Parent;

        public VariableData[] LocalVariables;

        public VariableData[] Variables
        {
            get
            {
                List<VariableData> result = new List<VariableData>();
                if (Parent != null)
                {
                    result.AddRange(Parent.Variables);
                }

                result.AddRange(LocalVariables);
                return result.ToArray();
            }
        }
    }
}
