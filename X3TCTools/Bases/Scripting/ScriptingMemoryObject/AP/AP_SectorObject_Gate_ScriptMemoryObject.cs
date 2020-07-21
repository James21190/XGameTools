using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.SectorObjects;

namespace X3TCTools.Bases.Scripting.ScriptingMemoryObject.AP
{
    public class AP_SectorObject_Gate_ScriptMemoryObject : ScriptingMemoryObject, IGate_ScriptMemoryObject
    {
        
        public AP_SectorObject_Gate_ScriptMemoryObject()
        {
            VariableCount = 56;
        }
        
        public enum VariableName
        {
            Dest_Sector_X = 8,
            Dest_Sector_Y
        }

        public int Dest_Sector_X { get { return GetVariableValue((int)VariableName.Dest_Sector_X); } }
        public int Dest_Sector_Y { get { return GetVariableValue((int)VariableName.Dest_Sector_Y); } }

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

        public int GetDestSectorX()
        {
            return Dest_Sector_X;
        }

        public int GetDestSectorY()
        {
            return Dest_Sector_Y;
        }
    }
}
