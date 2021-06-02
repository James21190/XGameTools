using System;
using System.Windows.Forms;

using X3Tools.RAM;

using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class ScriptStringObjectDisplay : Form
    {
        private ScriptStringObject m_obj;

        public ScriptStringObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadObject(ScriptStringObject obj)
        {
            m_obj = obj;
            Reload();
        }

        public void LoadObject(IntPtr address)
        {
            ScriptStringObject obj = new ScriptStringObject();
            obj.SetLocation(GameHook.hProcess, address);
            LoadObject(obj);
        }

        public void Reload()
        {
            m_obj.ReloadFromMemory();
            IDBox.Value = m_obj.id;
            textBox1.Text = m_obj.pText.obj.Value;
        }

        private void ScriptingTextObjectDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}
