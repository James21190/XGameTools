using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Station : ScriptMemoryObject, IScriptMemoryObject_Station
    {
        public new const int VariableCount = 53;

        public int MainType => throw new NotImplementedException();

        public int SubType => throw new NotImplementedException();

        public int CurrentSectorEventObjectID => throw new NotImplementedException();

        public EventObject CurrentSectorEventObject => throw new NotImplementedException();

        public int pCargoHashTable => throw new NotImplementedException();

        public ScriptingHashTableObject CargoHashTable => throw new NotImplementedException();

        public CargoEntry[] Cargo => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((TC_Station_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Station() : base(VariableCount)
        {

        }
    }
}
