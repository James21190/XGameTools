using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XRAMTool.Bases.Story
{
    public partial class ScriptArray_Display : Form
    {
        public ScriptArray_Display()
        {
            InitializeComponent();
        }

        private IntPtr _pArray;
        public IntPtr pArray
        {
            get { return _pArray; }
            set
            {
                _pArray = value;
                Reload();
            }
        }
        private int _ArrayLength;
        public int ArrayLength
        {
            get { return _ArrayLength; }
            set
            {
                _ArrayLength = value;
                Reload();
            }
        }
        public void LoadFromScriptArrayObject(ScriptArrayObject obj)
        {
            pArray = obj.pArr.address;
            ArrayLength = obj.Length;
        }

        public void Reload()
        {
            var pointer = new MemoryObjectPointer<DynamicValue>(Program.GameHook.hProcess);
            pointer.address = _pArray;
            Values = pointer.ToArray(_ArrayLength);
        }

        public DynamicValue[] Values
        {
            get { return scriptVariableArrayView1.DynamicValues; }
            set { scriptVariableArrayView1.DynamicValues = value;}
        }

        public ScriptInstanceType.VariableData[] VariableData
        {
            get { return scriptVariableArrayView1.Variables; }
            set { scriptVariableArrayView1.Variables = value;}
        }

        private void scriptVariableArrayView1_RequestView(object sender, ScriptInstanceType.VariableType type, int variableValue, object additional)
        {
            switch (type)
            {
                case ScriptInstanceType.VariableType.ScriptInstanceID:
                    var newScriptInstanceDisplay = new ScriptInstance_Display();
                    newScriptInstanceDisplay.LoadObject(variableValue);
                    newScriptInstanceDisplay.Show();
                    return;
                case ScriptInstanceType.VariableType.Array:
                    var newArrayDisplay = new ScriptArray_Display();
                    newArrayDisplay.LoadFromScriptArrayObject(Program.GameHook.StoryBase.GetScriptArrayObject((IntPtr)variableValue));
                    newArrayDisplay.Show();
                    break;
                case ScriptInstanceType.VariableType.Table:
                    var newTableDisplay = new ScriptHashTable_Display();
                    newTableDisplay.LoadObject((IntPtr)variableValue);
                    newTableDisplay.Show();
                    break;
                case ScriptInstanceType.VariableType.Object:
                    var newObjectDisplay = new ScriptArray_Display();

                    // Get type data
                    var typeData = Program.GameHook.DataFileManager.GetScriptInstanceType((string)additional);
                    newObjectDisplay.VariableData = typeData.Variables;

                    // Populate
                    newObjectDisplay.LoadFromScriptArrayObject(Program.GameHook.StoryBase.GetScriptArrayObject((IntPtr)variableValue));

                    newObjectDisplay.Show();
                    break;

            }
        }
    }
}
