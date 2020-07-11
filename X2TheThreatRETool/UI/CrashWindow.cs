using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X2TheThreatRETool
{
    public partial class CrashWindow : Form
    {
        public CrashWindow(Exception e)
        {
            InitializeComponent();
            richTextBox1.Text = string.Format(
                "I crashed, please send this to the developer.\n" +
                "Exception: {0}\n" +
                "InnerException: {3}\n" +
                "Message: {1}\n" +
                "Stack trace:\n{2}"
                ,e.GetType(), e.Message, e.StackTrace, e.InnerException
                );
        }

        private void CrashWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }
    }
}
