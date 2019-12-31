using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace X3TC_Tool
{
    public partial class X3TCToolForm
    {
        public void ReloadGeneralTab()
        {
            m_GameHook.SystemBase.Reload();
            trackBar1.Value = Convert.ToInt32(m_GameHook.SystemBase.SETAValue.Value);
            label1.Text = string.Format("Speed: {0}x", m_GameHook.SystemBase.SETAValue.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            m_GameHook.SystemBase.SETAValue.Value = trackBar1.Value;
            label1.Text = string.Format("Speed: {0}x", m_GameHook.SystemBase.SETAValue.Value);
            m_GameHook.SystemBase.SaveSETA();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PatchGame();
        }

        public void PatchGame()
        {
            string Caption = "Warning";
            string Message =
                "The changes made by this tool are not supported by EGOSOFT.\n" +
                "Changes made may be unstable and can corrupt save files.\n" +
                "A copy of the exe will be patchen and the original will remain unchanged.\n" +
                "Changes made can be found in \"PatchChanges.txt\" where the changed exe is saved.";
            var result = MessageBox.Show(Message, Caption, MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            string original =ofd.FileName;

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            string dest = sfd.FileName;

            if(original == dest)
            {
                MessageBox.Show("Error", "Overwritting the original exe is not allowed.", MessageBoxButtons.OKCancel);
                return;
            }

            List<string> patchPaths = new List<string>();

            foreach (var file in Directory.GetFiles("./Patches"))
            {
                if(Path.GetExtension(file) == ".patch")
                {
                    patchPaths.Add(file);
                }
            }

            var output = Common.Patcher.PatchExe(original, dest, patchPaths.ToArray(), 0x00401000, 0x400);

            File.WriteAllText(Path.Combine(Path.GetDirectoryName(dest), "PatchChanges.txt"), output);
        }
    }
}
