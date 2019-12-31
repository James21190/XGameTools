using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Memory;

namespace X3TC_Tool
{
    public partial class X3TCToolForm
    {
        private bool m_InjectorAgreed = false;
        private void ReloadSubscriptionTable()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in m_GameHook.EventManager.GetSubscriptions())
            {
                dataGridView1.Rows.Add(item.Code.Name, item.Event, item.pCode.ToString("X"));
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Get the user to agree to the risk of using the injector
            if (!m_InjectorAgreed)
            {
                string Caption = "Warning";
                string Message =
                    "This tool is extreamly powerful as it injects assembly directly into the game loop and it can be used maliciously.\n" +
                    "Only download and run files from trustworthy sources.";
                var buttons = MessageBoxButtons.OKCancel;
                var result = MessageBox.Show(Message, Caption, buttons);

                if (result == DialogResult.OK)
                {
                    m_InjectorAgreed = true;
                }
                else
                {
                    return;
                }
            }

            if (!Directory.Exists(".\\Mods"))
                Directory.CreateDirectory(".\\Mods");
            var OFD = new OpenFileDialog();
            OFD.InitialDirectory = Path.GetFullPath(".\\Mods");
            OFD.ShowDialog();

            if (string.IsNullOrWhiteSpace(OFD.FileName))
                return;
            var code = new EventManager.GameCode(OFD.FileName);
            var address = m_GameHook.EventManager.Subscribe(code.IntendedEvent, code);

            ReloadSubscriptionTable();
        }
    }
}
