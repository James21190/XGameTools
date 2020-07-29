using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TC_Tool.UI.Displays.ScriptingMemoryObjects
{
    public partial class ScriptMemory_Sector_Display : Form
    {
        private IScriptMemoryObject_Sector m_Object;

        public ScriptMemory_Sector_Display()
        {
            InitializeComponent();
        }

        public void LoadObject(IScriptMemoryObject_Sector obj)
        {
            m_Object = obj;
            Reload();
        }

        public void Reload()
        {

        }

        private void ScriptMemory_Sector_Display_Load(object sender, EventArgs e)
        {

        }
    }
}
