using CommonToolLib.Files.Patcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM;
using static CommonToolLib.Files.Patcher.FilePatch;
using static CommonToolLib.ProcessHooking.ScriptAssembler;

namespace X2FramerateLimiter
{
    public partial class Form1 : Form
    {
        private GameHook _GameHook;
        private IntPtr _pInjection;

        private FileProfile _X2Profile = FileProfile.FromFile("./DATA/X2/X2FileProfile.txt");
        FilePatch FPSPatch = FilePatch.LoadFromFile("./DATA/X2/Patches/FPSLimit.patch");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public void SetFPSLimitInRunning(int fps)
        {
            int delay = (int)Math.Ceiling(10000000.0f / fps);
            _GameHook.WriteBytes(_pInjection + 0x4, BitConverter.GetBytes(delay));
        }

        public void SetFPSLimitInFile(int fps, string path)
        {
            var delay = BitConverter.GetBytes((int)Math.Ceiling(10000000.0f / fps));
            FPSPatch.SetVariable("Delay", delay);

            using (FilePatcher patcher = new FilePatcher(path, _X2Profile))
            {
                patcher.ApplyPatch(FPSPatch);
            }
        }

        private void nudFPSLimit_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            nudFPSLimit.Maximum = checkBox1.Checked ? int.MaxValue : 144;
            nudFPSLimit.Minimum = checkBox1.Checked ? 1 : 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetFPSLimitInRunning((int)nudFPSLimit.Value);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "X2|X2.exe|All files|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                SetFPSLimitInFile((int)nudFPSLimit.Value, ofd.FileName);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_GameHook == null)
            {
                // Attempt to connect to process
                var x2GameProcess = Process.GetProcessesByName("X2").FirstOrDefault();
                if (x2GameProcess != null)
                {
                    _GameHook = new X2Lib.RAM.X2GameHook(x2GameProcess);
                    var injection = _GameHook.DataFileManager.GetMod("LimitFPS.x2code");
                    _GameHook.AttachInjectionManager();

                    _pInjection = _GameHook.InjectionManager.Subscribe(injection);
                    button1.Enabled = true;
                }
            }
            else if (!_GameHook.ProcessRunning)
            {
                _GameHook = null;
                button1.Enabled = false;
            }
        }
    }
}
