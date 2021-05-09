using System;
using System.Windows.Forms;
using X3TC_RAM_Tool.UI.Displays;
using X3Tools.RAM;

using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class ScriptMemoryObject_Raw_Panel : UserControl
    {
        private MessengerFunction m_MessengerFunction;
        public MessengerFunction MessengerFunction { get => m_MessengerFunction; set { m_MessengerFunction = value; } }
        private ScriptMemoryObject m_object;

        private ScriptInstanceTypeLibrary.ScriptInstanceType m_ReferenceType;

        public ScriptMemoryObject_Raw_Panel()
        {
            InitializeComponent();
            foreach (var item in ScriptInstanceTypeLibrary.GetAllNames())
            {
                comboBox1.Items.Add(item);
            }
        }

        public void LoadObject(ScriptInstance scriptInstance)
        {
            m_object = scriptInstance.ScriptVariableArr;
            m_ReferenceType = scriptInstance.ScriptInstanceType;
            if (m_ReferenceType != null)
                comboBox1.SelectedItem = m_ReferenceType.Name;
            Reload();
        }

        public void LoadObject(ScriptMemoryObject dynamicValueObject)
        {
            m_object = dynamicValueObject;
            if (m_ReferenceType != null)
                comboBox1.SelectedItem = m_ReferenceType.Name;
            Reload();
        }

        public void SetReferenceType(ScriptInstanceTypeLibrary.ScriptInstanceType referenceType)
        {
            m_ReferenceType = referenceType;
            Reload();
        }

        public void Reload()
        {
            if (m_object == null)
            {
                AddressBox.Text = "Not Found!";
                dataGridView1.Rows.Clear();
                return;
            }
            m_object.ReloadFromMemory();

            AddressBox.Text = m_object.pThis.ToString("X");
            numericUpDown1.Value = m_object.VariableCount;

            int count = dataGridView1.Rows.Count;
            int rowIndex;
            for (rowIndex = 0; rowIndex < m_object.VariableCount; rowIndex++)
            {
                string variableName;
                if (m_ReferenceType == null)
                    variableName = rowIndex.ToString();
                else
                    variableName = m_ReferenceType.GetVariableName(rowIndex);

                DynamicValue value = m_object.GetVariable(rowIndex);
                if (rowIndex < count)
                    dataGridView1.Rows[rowIndex].SetValues(variableName, value.Flag, value.Value, value.Value.ToString("X"));
                else
                    dataGridView1.Rows.Add(variableName, value.Flag, value.Value, value.Value.ToString("X"));
            }
            for (int i = 0; i < count - rowIndex; i++)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_ReferenceType = ScriptInstanceTypeLibrary.GetScriptInstanceType(comboBox1.SelectedItem.ToString());
            Reload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex == dataGridView1.Columns["ViewColumn"].Index && e.RowIndex >= 0)
            {

                DynamicValue dv = new DynamicValue
                {
                    Flag = (DynamicValue.FlagType)row.Cells[1].Value,
                    Value = (int)row.Cells[2].Value
                };

                Form display = DynamicValueContentLoader.LoadContent(dv);
                if (display != null)
                {
                    display.Show();
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index && e.RowIndex >= 0)
            {
                DynamicValueEditorDisplay editor = new DynamicValueEditorDisplay(m_object.GetVariable(e.RowIndex));
                editor.ShowDialog();
                if (editor.result != null)
                {
                    m_object.SetVariable(e.RowIndex, editor.result);
                    m_object.WriteToMemory();
                    Reload();
                }
            }
        }

        private void ScriptMemoryObject_Raw_Panel_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = comboBox1.SelectedIndex >= 0;
        }
    }
}
