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

            // Attempt to connect to process
            var x2GameProcess = Process.GetProcessesByName("X2").FirstOrDefault();
            if (x2GameProcess != null)
            {
                _GameHook = new X2Lib.RAM.X2GameHook(x2GameProcess);
                injection = _GameHook.DataFileManager.GetMod("LimitFPS.x2code");
                _GameHook.AttachInjectionManager();

                _pInjection = _GameHook.InjectionManager.Subscribe(injection);
            }
            // If not found, disable button.
            else
            {
                button1.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void SetFPSLimitInRunning(int fps)
        {
            int delay = (int)Math.Ceiling(10000000.0f / fps);
            _GameHook.WriteBytes(_pInjection + 0x4, BitConverter.GetBytes(delay));
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
    }
}
