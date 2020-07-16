using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X3TCTools;
using X3TCTools.Bases;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemoryObject;

namespace X3TC_Tool.UI.Displays
{
    public partial class DynamicValueObjectDisplay : Form
    {
        private GameHook m_GameHook;
        private ScriptingMemoryObject m_object;
        public DynamicValueObjectDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }

        public void LoadObject(ScriptingMemoryObject dynamicValueObject)
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

            for(int i = 0; i < m_object.VariableCount; i++)
            {
                var value = m_object.GetVariable(i);
                dataGridView1.Rows.Add(m_object.GetVariableName(i), value.Flag, value.Value, value.Value.ToString("X"));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex == dataGridView1.Columns["ViewColumn"].Index && e.RowIndex >= 0)
            {

                var dv = new DynamicValue();
                dv.Flag = (DynamicValue.FlagType)row.Cells[1].Value;
                dv.Value = (int)row.Cells[2].Value;

                var display = DynamicValueContentLoader.LoadContent(m_GameHook, dv);
                if (display != null)
                    display.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index && e.RowIndex >= 0)
            {
                var editor = new DynamicValueEditorDisplay(m_object.GetVariable(e.RowIndex));
                editor.ShowDialog();
                if(editor.result != null)
                {
                    m_object.SetVariable(e.RowIndex, editor.result);
                    m_object.WriteToMemory();
                    Reload();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ScriptingMemoryObject obj;
            switch (comboBox1.SelectedIndex)
            {
                case 0: // Blank
                    obj = new BlankScriptingMemoryObject((int)numericUpDown1.Value);
                    obj.SetLocation(m_GameHook.hProcess, (IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
                    LoadObject(obj);
                    break;
                default: return;
            }
            LoadObject(obj);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = comboBox1.SelectedIndex > -1;
        }
    }
}
