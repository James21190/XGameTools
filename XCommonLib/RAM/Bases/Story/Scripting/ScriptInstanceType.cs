using System.Collections.Generic;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstanceType
    {
        public int TypeID;
        public ScriptInstanceType Parent;

        public string[] LocalVariableNames;

        public string[] VariableNames
        {
            get
            {
                List<string> result = new List<string>();
                if (Parent != null)
                {
                    result.AddRange(Parent.VariableNames);
                }

                result.AddRange(LocalVariableNames);
                return result.ToArray();
            }
        }

    }
}
