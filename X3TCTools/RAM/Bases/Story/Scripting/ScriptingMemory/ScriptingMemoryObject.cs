﻿using CommonToolLib.Memory;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory
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

        public void SetVariableInMemory(int index, DynamicValue value)
        {
            SetVariable(index, value); ;
            MemoryControl.Write(GameHook.hProcess, pThis + (DynamicValue.ByteSizeConst * index), value.GetBytes());
        }

        public void SetVariableValueInMemory(int index, int value)
        {
            SetVariableValue(index, value);
            MemoryControl.Write(GameHook.hProcess, pThis + (DynamicValue.ByteSizeConst * index) + 1, value);
        }
        #endregion

        #region IMemoryObject
        public sealed override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(Variables);
            return collection.GetBytes();
        }

        public sealed override int ByteSize => VariableCount * DynamicValue.ByteSizeConst;

        public sealed override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, hProcess, pThis);
            Variables = collection.PopIMemoryObjects<DynamicValue>(VariableCount);
        }
        #endregion
    }
}
