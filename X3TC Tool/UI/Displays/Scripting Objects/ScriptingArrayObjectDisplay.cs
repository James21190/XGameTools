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
    public partial class ScriptingArrayObjectDisplay : Form
    {
        private GameHook m_GameHook;

        private ScriptingArrayObject m_obj;

        public ScriptingArrayObjectDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }

        public void LoadObject(ScriptingArrayObject obj)
        {
            m_obj = obj;
            Reload();
        }

        public void LoadObject(IntPtr address)
        {
            var obj = new ScriptingArrayObject();
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
            var obj = DynamicValueObject.GetBlank("Array", m_obj.length);
            obj.SetLocation(m_GameHook.hProcess, m_obj.pArray.address);
            var display = new DynamicValueObjectDisplay(m_GameHook);
            display.LoadObject(obj);
            display.Show();
        }
    }
}
