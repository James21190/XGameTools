using System;
using System.Windows.Forms;
using X3Tools;
using X3Tools.Bases;
using X3Tools.Bases.StoryBase_Objects;
using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Generics;
using X3Tools.Bases.StoryBase_Objects.Scripting.KCode;
using X3_Tool.UI.Bases.StoryBase_Displays;

namespace X3_Tool.UI.Displays
{
    public partial class ScriptTaskObjectDisplay : Form
    {
        private ScriptTaskObject m_ScriptObject;
        public ScriptTaskObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadObject(IntPtr pObject)
        {
            ScriptTaskObject newobj = new ScriptTaskObject();
            newobj.SetLocation(GameHook.hProcess, pObject);
            LoadObject(newobj);
        }
        public void LoadObject(ScriptTaskObject scriptObject)
        {
            m_ScriptObject = scriptObject;
            Reload();
        }

        public void Reload()
        {
            StoryBase storybase = GameHook.storyBase;
            if (m_ScriptObject == null)
            {
                NextButton.Enabled = false;
                PreviousButton.Enabled = false;

                AddressBox.Text = "Not Found!";

                return;
            }
            if (m_ScriptObject.pThis.ToString("X") != AddressBox.Text)
            {
                AddressBox.Text = m_ScriptObject.pThis.ToString("X");
            }

            if (m_ScriptObject.ID != IDNumericUpDown.Value)
            {
                IDNumericUpDown.Value = m_ScriptObject.ID;
            }

            NextButton.Enabled = m_ScriptObject.pNext.IsValid;
            PreviousButton.Enabled = m_ScriptObject.pPrevious.IsValid;

            // Stack
            StackCurrentIndexBox.Text = m_ScriptObject.CurrentStackIndex.ToString();
            StackSizeBox.Text = m_ScriptObject.StackSize.ToString();


            textBox3.Text = m_ScriptObject.FunctionIndex.ToString();

            // Instruction
            InstructionOffsetBox.Text = m_ScriptObject.InstructionOffset.ToString();
            numericUpDown1.Value = m_ScriptObject.InstructionOffset;
            // Function Name
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadObject((IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_ScriptObject.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_ScriptObject.pPrevious.obj);
        }

        private void LoadIDButton_Click(object sender, EventArgs e)
        {
            StoryBase storybase = GameHook.storyBase;
            try
            {
                HashTable<ScriptTaskObject> table = storybase.pHashTable_ScriptTaskObject.obj;
                ScriptTaskObject obj = table.GetObject((int)IDNumericUpDown.Value);
                LoadObject(obj);
            }
            catch (Exception)
            {
                m_ScriptObject = null;
                Reload();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DynamicValueArrayDisplay display = new DynamicValueArrayDisplay();
            display.LoadFrom(m_ScriptObject.pStack.address, m_ScriptObject.StackSize, 0);
            display.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int offset = (int)numericUpDown1.Value;
            textBox1.Text = (((int)GameHook.storyBase.pInstructionArray.address) + offset).ToString("X");
        }

        private void ScriptObjectDisplay_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var display = new ScriptingDisassemblerDisplay();
            display.LoadAddress(m_ScriptObject.InstructionOffset);
            display.Show();
        }
    }
}
