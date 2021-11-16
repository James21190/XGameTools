using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using X2Lib.RAM;
using X3TCAPLib.RAM;
using XCommonLib.RAM;

namespace XRAMTool
{
    public static class Program
    {
        public static GameHook GameHook;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            while (true)
            {
                // Hook into the game memory
                Process processX2 = Process.GetProcessesByName("X2").FirstOrDefault();
                Process processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
                Process processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
                Process processX3FL = Process.GetProcessesByName("X3FL").FirstOrDefault();

                if (processX2 != null)
                {
                    GameHook = new X2GameHook(processX2);
                }
                else if (processX3TC != null)
                {
                    GameHook = new X3TCGameHook(processX3TC);
                }
                else if(processX3AP != null)
                {
                    GameHook = new X3APGameHook(processX3AP);
                }

                if (GameHook != null)
                {
                    break;
                }

                DialogResult result = MessageBox.Show("X is not currently running!\nPlease launch an X game and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    return;
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new XRAMTool());
        }
    }
}
