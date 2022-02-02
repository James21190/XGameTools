using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Reload();
        }

        private void btnAttachEventManager_Click(object sender, EventArgs e)
        {
            Program.GameHook.AttachEventManager();
            btnAttachEventManager.Enabled = false;
        }

        private void Reload()
        {
            listBox1.Items.Clear();
            foreach (var file in Program.GameHook.DataFileManager.GetModFiles())
            {
                listBox1.Items.Add(file);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.GameHook.EventManager.Subscribe(Program.GameHook.DataFileManager.GetMod((string)listBox1.SelectedItem));
        }
    }
}
