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
using X3TCTools.Bases.Scripting;

namespace X3TC_Tool.UI.Displays
{
    public partial class ScriptingTextObjectDisplay : Form
    {
        private GameHook m_GameHook;

        private ScriptingTextObject m_obj;

        public ScriptingTextObjectDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }

        public void LoadObject(ScriptingTextObject obj)
        {
            m_obj = obj;
            Reload();
        }

        public void LoadObject(IntPtr address)
        {
            var obj = new ScriptingTextObject();
            obj.SetLocation(m_GameHook.hProcess, address);
            LoadObject(obj);
        }

        public void Reload()
        {
            m_obj.ReloadFromMemory();
            IDBox.Value = m_obj.id;
            textBox1.Text = m_obj.pText.obj.value;
        }
    }
}
