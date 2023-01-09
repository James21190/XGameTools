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

namespace X2FramerateLimiter
{
    public partial class Form1 : Form
    {
        private X2Lib.RAM.X2GameHook _GameHook;
        private IntPtr _pInjection;
        public Form1()
        {
            InitializeComponent();
            Process gameProcess;
            while (true)
            {
                gameProcess = Process.GetProcessesByName("X2").FirstOrDefault();
                if (gameProcess != null)
                    break;
                DialogResult result = MessageBox.Show("X2 is not currently running!\nPlease launch X2 and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    return;
                }
            }
            _GameHook = new X2Lib.RAM.X2GameHook(gameProcess);

            _GameHook.AttachInjectionManager();

            var injection = _GameHook.DataFileManager.GetMod("LimitFPS.x2code");
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
    }
}
