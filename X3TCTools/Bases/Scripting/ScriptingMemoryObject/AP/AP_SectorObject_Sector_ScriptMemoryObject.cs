using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.SectorObjects;

namespace X3TCTools.Bases.Scripting.ScriptingMemoryObject.AP
{
    public class AP_SectorObject_Sector_ScriptMemoryObject : ScriptingMemoryObject, ISector_ScriptMemoryObject
    {
        
        public AP_SectorObject_Sector_ScriptMemoryObject()
        {
            VariableCount = 56;
        }
        
        public enum VariableName
        {
            Sector_X,
            Sector_Y
        }

        public int Sector_X { get { return GetVariableValue((int)VariableName.Sector_X); } }
        public int Sector_Y { get { return GetVariableValue((int)VariableName.Sector_Y); } }

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

        public int GetSectorX()
        {
            return Sector_X;
        }

        public int GetSectorY()
        {
            return Sector_Y;
        }
    }
}
