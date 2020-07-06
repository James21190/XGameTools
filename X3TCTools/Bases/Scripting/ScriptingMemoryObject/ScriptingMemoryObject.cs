using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using Common.Memory;

namespace X3TCTools.Bases.Scripting.ScriptingMemoryObject
{
    public abstract class ScriptingMemoryObject : MemoryObject
    {
        public int VariableCount { get; protected set; }
        protected DynamicValue[] Variables;

        public virtual string GetVariableName(int index)
        {
            return index.ToString();
        }

        public DynamicValue GetVariable(int index)
        {
            return Variables[index];
        }

        public void SetVariable(int index, DynamicValue value)
        {
            Variables[index] = value;
        }

        public int GetVariableValue(int index)
        {
            return Variables[index].Value;
        }

        public void SetVariableValue(int index, int value)
        {
            Variables[index].Value = value;
        }

        public sealed override byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(Variables);
            return collection.GetBytes();
        }

        public sealed override int GetByteSize()
        {
            return VariableCount * DynamicValue.ByteSize;
        }

        public sealed override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);
            Variables = collection.PopIMemoryObjects<DynamicValue>(VariableCount);
        }
    }
}
