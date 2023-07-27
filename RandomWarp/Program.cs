using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using X3TCAPLib.RAM;
using XCommonLib.RAM;

namespace Randomizer
{
    internal static class Program
    {
        public static GameHook GameHook;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Process processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
            if (processX3TC != null)
            {
                GameHook = new X3TCGameHook(processX3TC);
            }
            else
            {
                MessageBox.Show("X3TC not found. Please launch the game and try again.");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
