using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.SectorObjects;

namespace X3TCTools.Bases.Scripting.ScriptingMemoryObject.AP
{
    public class AP_SectorObject_Dock_ScriptMemoryObject : ScriptingMemoryObject
    {
        
        public AP_SectorObject_Dock_ScriptMemoryObject()
        {
            VariableCount = 95;
        }
        public struct CargoEntry : IComparable
        {
            public SectorObject.Full_Type Type;
            public int Count;

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                if (!(obj is CargoEntry)) throw new Exception("Type missmatch");
                return ((CargoEntry)obj).Type.CompareTo(this.Type);

            }

            public override string ToString()
            {
                return Type.ToString() + " X " + Count;
            }
        }
        
        public enum VariableName
        {
            Shielding = 19,
            Cargo = 44
        }

        public int GetVariableValue(VariableName variableName)
        {
            return GetVariableValue((int)variableName);
        }

        public void SetVariableValue(VariableName variableName, int value)
        {
            SetVariableValue((int)variableName, value);
        }

        public override string GetVariableName(int index)
        {
            return ((VariableName)index).ToString();
        }
    }
}
