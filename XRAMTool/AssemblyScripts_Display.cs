using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRAMTool
{
    public partial class AssemblyScripts_Display : Form
    {
        public AssemblyScripts_Display()
        {
            InitializeComponent();
        }

        private void AssemblyScripts_Display_Load(object sender, EventArgs e)
        {
            btnAttachEventManager.Enabled = Program.GameHook.EventManager == null;
        }

        private void btnAttachEventManager_Click(object sender, EventArgs e)
        {
            Program.GameHook.AttachEventManager();
            btnAttachEventManager.Enabled = false;
        }
    }
}
