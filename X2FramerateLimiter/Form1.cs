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
using static CommonToolLib.ProcessHooking.ScriptAssembler;

namespace X2FramerateLimiter
{
    public partial class Form1 : Form
    {
        private GameHook _GameHook;
        private IntPtr _pInjection;
        public Form1()
        {
            InitializeComponent();
            ScriptCode injection;
            while (true)
            {
                var x2GameProcess = Process.GetProcessesByName("X2").FirstOrDefault();
                var x3tcGameProcess = Process.GetProcessesByName("X3TC").FirstOrDefault();
                if (x2GameProcess != null)
                {
                    _GameHook = new X2Lib.RAM.X2GameHook(x2GameProcess);
                    injection = _GameHook.DataFileManager.GetMod("LimitFPS.x2code");
                    break;
                }
                if(x3tcGameProcess != null)
                {
                    _GameHook = new X3TCAPLib.RAM.X3TCGameHook(x3tcGameProcess);
                    injection = _GameHook.DataFileManager.GetMod("LimitFPS.x3tccode");
                    break;
                }

                DialogResult result = MessageBox.Show("X2/X3TC is not currently running!\nPlease launch X2/X3TC and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    return;
                }
            }

            timer1.Start();

            _GameHook.AttachInjectionManager();

            _pInjection = _GameHook.InjectionManager.Subscribe(injection);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetFPSLimit((int)nudFPSLimit.Value);
        }

        public void SetFPSLimit(int fps)
        {
            int delay = (int)Math.Ceiling(10000000.0f / fps);
            _GameHook.WriteBytes(_pInjection + 0x4, BitConverter.GetBytes(delay));
        }

        private void nudFPSLimit_ValueChanged(object sender, EventArgs e)
        {
            SetFPSLimit((int)nudFPSLimit.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            nudFPSLimit.Maximum = checkBox1.Checked ? int.MaxValue : 144;
            nudFPSLimit.Minimum = checkBox1.Checked ? 1 : 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!_GameHook.ProcessRunning)
                Close();
        }
    }
}
