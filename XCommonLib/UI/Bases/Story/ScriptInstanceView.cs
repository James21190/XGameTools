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

            if (ReferenceGameHook != null)
            {
                var typeData = ReferenceGameHook.DataFileManager.GetScriptInstanceType(m_ScriptInstance.Sub.Class);
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
    }
}
