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
                GameHook = XWrapperLib.GameHookFactory.GetGameHook();

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
