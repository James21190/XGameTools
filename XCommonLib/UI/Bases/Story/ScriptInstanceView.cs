using System.ComponentModel;
using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XCommonLib.UI.Bases.Story
{
    public partial class ScriptInstanceView : UserControl
    {
        private ScriptInstance m_ScriptInstance;
        public GameHook ReferenceGameHook = null;
        public ScriptInstanceView()
        {
            InitializeComponent();
        }

        public void LoadObject(ScriptInstance obj)
        {
            m_ScriptInstance = obj;
            Reload();
        }
        public void Reload()
        {
            numericIDObjectControl1.LoadObject(m_ScriptInstance);
            nnudReferenceCount.Value = m_ScriptInstance.ReferenceCount;
            ntxtMemoryAddress.Text = m_ScriptInstance.pScriptVariableArr.address.ToString("X");

            // Display type name
            string typeName = m_ScriptInstance.Sub.Class.ToString();
            if (ReferenceGameHook != null)
            {
                var typeData = ReferenceGameHook.DataFileManager.GetScriptInstanceType(m_ScriptInstance.Sub.Class);
                if (typeData != null)
                {
                    if (typeData.Parent != null)
                    {
                        typeName = string.Format("{0} : {1}", typeData.Name, typeData.Parent.Name);
                    }
                    else
                    {
                        typeName = typeData.Name;
                    }
                }
            }

            namedTextBox1.Text = typeName;

            // Reload memory table
            ReloadMemoryTable();
        }

        public void ReloadMemoryTable()
        {
            dgvMemoryTable.Rows.Clear();

            string[] variableNames = new string[m_ScriptInstance.Sub.ScriptVariableCount];
            for (int i = 0; i < m_ScriptInstance.Sub.ScriptVariableCount; i++)
            {
                variableNames[i] = i.ToString();
            }

            // Get variable name if possible
            if (ReferenceGameHook != null)
            {
                var typeData = ReferenceGameHook.DataFileManager.GetScriptInstanceType(m_ScriptInstance.Sub.Class);
                if(typeData != null)
                    for (int i = 0; i < m_ScriptInstance.Sub.ScriptVariableCount && i < typeData.VariableNames.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(typeData.VariableNames[i]))
                        {
                            variableNames[i] = typeData.VariableNames[i];
                        }
                    }
            }

            for (int i = 0; i < m_ScriptInstance.Sub.ScriptVariableCount; i++)
            {
                var variable = m_ScriptInstance.pScriptVariableArr.GetObjectInArray(i);
                dgvMemoryTable.Rows.Add(variableNames[i], variable.Flag, variable.Value, variable.Value.ToString("X"));
            }
        }

        public delegate void CellActionHandler(object sender, DynamicValue dynamicValue);
        [Browsable(true)]
        public event CellActionHandler OnViewClicked;

        private void dgvMemoryTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvMemoryTable.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvMemoryTable.Columns["colView"].Index && e.RowIndex >= 0)
            {

                DynamicValue dv = new DynamicValue
                {
                    Flag = (DynamicValue.FlagType)row.Cells[1].Value,
                    Value = (int)row.Cells[2].Value
                };

                if(OnViewClicked != null)
                    OnViewClicked(this, dv);
            }
            //else if (e.ColumnIndex == dgvMemoryTable.Columns["colEdit"].Index && e.RowIndex >= 0)
            //{
                /*
                DynamicValueEditorDisplay editor = new DynamicValueEditorDisplay(m_object.GetVariable(e.RowIndex));
                editor.ShowDialog();
                if (editor.result != null)
                {
                    m_object.SetVariable(e.RowIndex, editor.result);
                    m_object.WriteToMemory();
                    Reload();
                }
                */
            //}
        }
    }
}
