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
    public partial class ScriptingHashTableObjectDisplay : Form
    {
        private GameHook m_GameHook;

        private ScriptingHashTableObject m_obj;

        public ScriptingHashTableObjectDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }

        public void LoadObject(ScriptingHashTableObject obj)
        {
            m_obj = obj;
            Reload();
        }

        public void LoadObject(IntPtr address)
        {
            var obj = new ScriptingHashTableObject();
            obj.SetLocation(m_GameHook.hProcess, address);
            LoadObject(obj);
        }

        public void Reload()
        {
            m_obj.ReloadFromMemory();
            IDBox.Value = m_obj.id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new ScriptingHashTableDisplay(m_GameHook);
            display.LoadTable(m_obj.hashTable.pThis);
            display.Show();
        }
    }
}
