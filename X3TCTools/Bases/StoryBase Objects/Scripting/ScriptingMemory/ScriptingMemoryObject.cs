using Common.Memory;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public class ScriptMemoryObject : MemoryObject
    {
        /// <summary>
        /// Length of the object
        /// </summary>
        public int VariableCount { get; private set; }
        /// <summary>
        /// List of all variables, comparable to how an array of bytes represents an object.
        /// </summary>
        private DynamicValue[] Variables;

        #region Constructors
        public ScriptMemoryObject()
        {
            VariableCount = 0;
            Variables = new DynamicValue[0];
        }

        public ScriptMemoryObject(int size)
        {
            VariableCount = size;
            Variables = new DynamicValue[size];
        }

        #endregion

        /// <summary>
        /// Resizes the object.
        /// </summary>
        /// <param name="newSize"></param>
        public void Resize(int newSize)
        {
            VariableCount = newSize;
            ReloadFromMemory();
        }
        public virtual string GetVariableName(int index)
        {
            return index.ToString();
        }

        #region Gets
        public DynamicValue GetVariable(int index)
        {
            return Variables[index];
        }
        public int GetVariableValue(int index)
        {
            return Variables[index].Value;
        }
        #endregion

        #region Sets
        public void SetVariable(int index, DynamicValue value)
        {
            Variables[index] = value;
        }
        public void SetVariableValue(int index, int value)
        {
            Variables[index].Value = value;
        }
        #endregion

        #region IMemoryObject
        public sealed override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(Variables);
            return collection.GetBytes();
        }

        public sealed override int GetByteSize()
        {
            return VariableCount * DynamicValue.ByteSize;
        }

        public sealed override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);
            Variables = collection.PopIMemoryObjects<DynamicValue>(VariableCount);
        }
        #endregion
    }
}
