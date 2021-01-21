using System;
using System.Windows.Forms;
using X3_Tool.UI.Displays;
using X3Tools;

using X3Tools.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.Bases.Story.Scripting;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class ScriptMemoryObject_Raw_Panel : UserControl
    {

        private ScriptMemoryObject m_object;

        public ScriptMemoryObject_Raw_Panel()
        {
            InitializeComponent();
        }

        public void LoadObject(ScriptMemoryObject dynamicValueObject)
        {
            m_object = dynamicValueObject;
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
            //textBox1.Text = m_object.name;
            numericUpDown1.Value = m_object.VariableCount;

            int count = dataGridView1.Rows.Count;
            int rowIndex;
            for (rowIndex = 0; rowIndex < m_object.VariableCount; rowIndex++)
            {
                DynamicValue value = m_object.GetVariable(rowIndex);
                if (rowIndex < count)
                    dataGridView1.Rows[rowIndex].SetValues(m_object.GetVariableName(rowIndex), value.Flag, value.Value, value.Value.ToString("X"));
                else
                    dataGridView1.Rows.Add(m_object.GetVariableName(rowIndex), value.Flag, value.Value, value.Value.ToString("X"));
            }
            for (int i = 0; i < count - rowIndex; i++)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScriptMemoryObject obj = ScriptInstanceDisplay.GetScriptMemoryObjectType((ScriptInstanceDisplay.LoadAsItems)comboBox1.SelectedIndex);
            obj.SetLocation(GameHook.hProcess, (IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
            LoadObject(obj);
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
            int i = 0;
            while (((ScriptInstanceDisplay.LoadAsItems)(i)).ToString() != i.ToString())
            {
                comboBox1.Items.Add((ScriptInstanceDisplay.LoadAsItems)i++);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = comboBox1.SelectedIndex >= 0;
        }
    }
}
