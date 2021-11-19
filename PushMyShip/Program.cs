using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PushMyShip
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.ThreadException += OnException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();
            Application.Run(form);
        }

        private static void OnException(object sender, ThreadExceptionEventArgs e)
        {
            File.WriteAllText("./crash.txt", e.ToString());
        }
    }
}
