using System;
using System.Windows.Forms;
using X3TC_Tool.UI.Displays;
using X3TCTools;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
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
            m_object.ReloadFromMemory();

            AddressBox.Text = m_object.pThis.ToString("X");
            //textBox1.Text = m_object.name;
            numericUpDown1.Value = m_object.VariableCount;

            dataGridView1.Rows.Clear();

            for (int i = 0; i < m_object.VariableCount; i++)
            {
                DynamicValue value = m_object.GetVariable(i);
                dataGridView1.Rows.Add(m_object.GetVariableName(i), value.Flag, value.Value, value.Value.ToString("X"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScriptMemoryObject obj = EventObjectDisplay.GetScriptMemoryObjectType((EventObjectDisplay.LoadAsItems)comboBox1.SelectedIndex);
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
            while (((EventObjectDisplay.LoadAsItems)(i)).ToString() != i.ToString())
            {
                comboBox1.Items.Add((EventObjectDisplay.LoadAsItems)i++);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = comboBox1.SelectedIndex >= 0;
        }
    }
}
