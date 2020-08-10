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
using X3TCTools.Bases.Scripting.ScriptingMemory;
using X3TCTools.Bases.Scripting.ScriptingMemory.TC;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;

namespace X3TC_Tool.UI.Displays
{
    public partial class DynamicValueObjectDisplay : Form
    {
        private ScriptMemoryObject m_object;
        public DynamicValueObjectDisplay()
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

                var display = DynamicValueContentLoader.LoadContent(dv);
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

        private enum Presets
        {
            Blank,
            PositionData_12,
            SectorData
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ScriptMemoryObject obj;
            switch(GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP:
                    switch ((Presets)comboBox1.SelectedIndex)
                    {
                        case Presets.Blank: // Blank
                            obj = new ScriptMemoryObject((int)numericUpDown1.Value);
                            break;
                        case Presets.PositionData_12:
                            obj = new ScriptMemoryObject_AP_PositionData_12();
                            break;
                        case Presets.SectorData:
                            obj = new ScriptMemoryObject_AP_SectorData();
                            break;
                        default: return;
                    }
                    break;
                case GameHook.GameVersions.X3TC:
                    switch ((Presets)comboBox1.SelectedIndex)
                    {
                        case Presets.Blank: // Blank
                            obj = new ScriptMemoryObject((int)numericUpDown1.Value);
                            break;
                        case Presets.PositionData_12:
                            obj = new ScriptMemoryObject_TC_PositionData_12();
                            break;
                        case Presets.SectorData:
                            obj = new ScriptMemoryObject_TC_SectorData();
                            break;
                        default: return;
                    }
                    break;
                default: return;
            }
            obj.SetLocation(GameHook.hProcess, (IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
            LoadObject(obj);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = comboBox1.SelectedIndex > -1;
        }

        private void DynamicValueObjectDisplay_Load(object sender, EventArgs e)
        {
            int i = 0;
            while (((Presets)(i)).ToString() != i.ToString())
            {
                comboBox1.Items.Add((Presets)i++);
            }
        }
    }
}
