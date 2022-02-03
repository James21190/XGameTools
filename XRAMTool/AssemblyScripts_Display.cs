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
            btnAttachEventManager.Enabled = Program.GameHook.InjectionManager == null;
            Reload();
        }

        private void btnAttachEventManager_Click(object sender, EventArgs e)
        {
            Program.GameHook.AttachInjectionManager();
            btnAttachEventManager.Enabled = false;
        }

        private void Reload()
        {
            lstEventScripts.Items.Clear();
            foreach (var file in Program.GameHook.DataFileManager.GetModFiles())
            {
                var code = Program.GameHook.DataFileManager.GetMod(file);
                switch (code.Type)
                {
                    case CommonToolLib.ProcessHooking.ScriptAssembler.ScriptCode.InsertionType.Event:
                        lstEventScripts.Items.Add(file);
                        break;
                    case CommonToolLib.ProcessHooking.ScriptAssembler.ScriptCode.InsertionType.Inline:
                        lstInlineScripts.Items.Add(file);
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var eventMod = Program.GameHook.DataFileManager.GetMod((string)lstEventScripts.SelectedItem);
            Program.GameHook.InjectionManager.Subscribe(eventMod);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var inlineMod = Program.GameHook.DataFileManager.GetMod((string)lstInlineScripts.SelectedItem);
            Program.GameHook.InjectionManager.SetInlineInjection(inlineMod);
        }
    }
}
