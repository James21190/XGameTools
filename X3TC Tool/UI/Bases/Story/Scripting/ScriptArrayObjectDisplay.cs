using System;
using System.Windows.Forms;

using X3Tools.RAM;

using X3Tools.RAM.Bases.Story.Scripting;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;

namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class ScriptArrayObjectDisplay : Form
    {
        private ScriptArrayObject m_obj;

        public ScriptArrayObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadArray(ScriptArrayObject obj)
        {
            m_obj = obj;
            Reload();
        }

        public void Reload()
        {
            txtAddress.Text = m_obj.pThis.ToString("X");
            nudID.Value = m_obj.ID;
            ScriptMemoryObject arr = new ScriptMemoryObject(m_obj.Length);
            arr.SetLocation(GameHook.hProcess, m_obj.pDynamicValueArr.address);
            arr.ReloadFromMemory();
            scriptMemoryObject_Raw_Panel1.LoadObject(arr);
        }

        private void ScriptArrayObjectDisplay_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadID_Click(object sender, EventArgs e)
        {
            LoadArray(GameHook.storyBase.pHashTable_ScriptArrayObject.obj.GetObject((int)nudID.Value));
        }
    }
}
