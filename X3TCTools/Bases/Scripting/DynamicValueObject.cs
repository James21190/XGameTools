using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases.Scripting
{
    public sealed partial class DynamicValueObject : MemoryObject
    {

        public readonly string name;

        public int variableCount
        {
            get
            {
                return m_variables.Length;
            }
        }

        private readonly string[] m_variables;
        private DynamicValue[] m_values;

        public DynamicValueObject(string name, string[] variableNames)
        {
            this.name = name;
            this.m_variables = variableNames;
            m_values = new DynamicValue[variableCount];
            for(int i = 0; i < variableCount; i++)
            {
                m_values[i] = new DynamicValue();
            }
        }

        public string GetVariableName(int index)
        {
            return m_variables[index];
        }

        public DynamicValue GetVariable(int index)
        {
            return m_values[index];
        }

        /// <summary>
        /// Returns the variable with a given name.
        /// Returns null if not found.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DynamicValue GetVariable(string name)
        {
            for (int i = 0; i < variableCount; i++)
                if (m_variables[i] == name)
                    return m_values[i];
            return null;
        }

        public void SetVariable(int index, DynamicValue value)
        {
            m_values[index] = value;
        }

        #region IMemoryObject
        public sealed override byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(m_values);

            return collection.GetBytes();
        }

        public sealed override int GetByteSize()
        {
            return variableCount * DynamicValue.ByteSize;
        }

        public sealed override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);
            m_values = collection.PopIMemoryObjects<DynamicValue>(variableCount);
        }

        public sealed override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
