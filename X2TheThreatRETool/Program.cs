using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X2TheThreatRETool
{
    static class Program
    {

        private static Form m_Form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if !DEBUG
            Application.ThreadException += OnException;
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m_Form = new X2RETool();
            Application.Run(m_Form);
        }

        private static void OnException(object sender, ThreadExceptionEventArgs e)
        {
            var cw = new CrashWindow(e.Exception);
            cw.ShowDialog();
            m_Form.Close();
            Application.Exit();
        }
    }
}
