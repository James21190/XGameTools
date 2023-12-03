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
using static CommonToolLib.ProcessHooking.ScriptAssembler;

namespace X2FramerateLimiter
{
    public partial class Form1 : Form
    {
        private GameHook _GameHook;
        private IntPtr _pInjection;

        private FileProfile _X2Profile = FileProfile.FromFile("./DATA/X2/X2FileProfile.txt");
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

        public void SetFPSLimitInFile(int fps, string path)
        {
            var delay = BitConverter.GetBytes((int)Math.Ceiling(10000000.0f / fps));
            FilePatch FPSPatch = new FilePatch()
            {
                Name = "FPS Patch",
                Method = FilePatch.PatchMethod.COPY,
                Description = "",
                Sections = new FilePatch.Section[]
                {
                    new FilePatch.Section()
                    {
                        Address = 0x0040218a,
                        Bytes = new byte[]
                        {
                            0x8b, 0x48 , 0x34 , 0x8d , 0x14 , 0x49 , 0xc7 , 0x44 , 0xd0, 0x38, 0xf0, 0x4f, 0x40, 0x00, 0xc7, 0x44, 0xd0, 0x3c, 0xc0, 0x2f, 0x40, 0x00, 0xc7, 0x44, 0xd0, 0x40, 0x40, 0x30, 0x40, 0x00, 0x89, 0x5c, 0xd0, 0x44, 0xc7, 0x44, 0xd0, 0x48, 0x30, 0x44, 0x51, 0x00, 0x89, 0x5c, 0xd0, 0x4c, 0x8b, 0x15, 0x40, 0xb3, 0x52, 0x00, 0x89, 0x8a, 0x18, 0x04, 0x00, 0x00, 0x41, 0x8d, 0x14, 0x49, 0xc7, 0x44, 0xd0, 0x38, 0x80, 0xa2, 0x41, 0x00, 0xc7, 0x44, 0xd0, 0x3c, 0x40, 0xa2, 0x41, 0x00, 0x89, 0x5c, 0xd0, 0x40, 0x89, 0x5c, 0xd0, 0x44, 0xc7, 0x44, 0xd0, 0x48, 0xb0, 0x45, 0x51, 0x00, 0x89, 0x5c, 0xd0, 0x4c, 0x89, 0x0d, 0x98, 0xf6, 0x52, 0x00, 0x41, 0x89, 0x48, 0x34, 0xe9, 0x49, 0x00, 0x00, 0x00, 0xe8, 0xe0, 0xf1, 0x05, 0x00, 0x67, 0x68, 0x90, 0x45, 0x5a, 0x01, 0xff, 0x15, 0xc0, 0xa0, 0x4f, 0x00, 0x8b, 0x05, 0x90, 0x45, 0x5a, 0x01, 0x2b, 0x05, 0x98, 0x45, 0x5a, 0x01, 0x25, 0xff, 0xff, 0xff, 0x7f, 0x3d, delay[0], delay[1], delay[2], delay[3], 0x7c, 0xdc, 0x8b, 0x05, 0x90, 0x45, 0x5a, 0x01, 0x89, 0x05, 0x98, 0x45, 0x5a, 0x01, 0xe9, 0x52, 0x07, 0x00, 0x00, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x6a, 0x08, 0xe8, 0x9a, 0x4a, 0x0e, 0x00
                        }
                    },
                    new FilePatch.Section()
                    {
                        Address = 0x00402982,
                        Bytes = new byte[]
                        {
                            0xe9, 0x74, 0xf8, 0xff, 0xff
                        }
                    }
                }
            };

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
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                SetFPSLimitInFile((int)nudFPSLimit.Value, ofd.FileName);
            }
        }
    }
}
