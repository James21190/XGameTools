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
            Reload();
        }

        private void btnAttachEventManager_Click(object sender, EventArgs e)
        {
            Program.GameHook.AttachInjectionManager();
            Reload();
        }

        private void Reload()
        {
            btnAttachEventManager.Enabled = Program.GameHook.InjectionManager == null;
            button1.Enabled =
                button2.Enabled =
                Program.GameHook.InjectionManager != null;

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

            if(Program.GameHook.InjectionManager != null)
            {
                lstLoadedEventScripts.Items.Clear();
                foreach(var eventScript in Program.GameHook.InjectionManager.GetSubscriptions())
                {
                    lstLoadedEventScripts.Items.Add(eventScript);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var eventMod = Program.GameHook.DataFileManager.GetMod((string)lstEventScripts.SelectedItem);
            Program.GameHook.InjectionManager.Subscribe(eventMod);
            Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var inlineMod = Program.GameHook.DataFileManager.GetMod((string)lstInlineScripts.SelectedItem);
            Program.GameHook.InjectionManager.SetInlineInjection(inlineMod);
            Reload();
        }

        private void lstLoadedEventScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ntxtEventScriptAddress.Text = Program.GameHook.InjectionManager.GetSubscriptions()[lstLoadedEventScripts.SelectedIndex].pCode.ToString("X");
        }

        private void lstLoadedInlineScripts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
