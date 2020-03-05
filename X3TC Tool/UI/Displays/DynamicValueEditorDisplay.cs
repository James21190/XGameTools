using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3TCTools.Bases.Scripting;

namespace X3TC_Tool.UI.Displays
{
    public partial class DynamicValueEditorDisplay : Form
    {
        public DynamicValueEditorDisplay(DynamicValue defaultValue = null)
        {
            InitializeComponent();
            if (defaultValue != null)
                dynamicValueDisplay1.Value = defaultValue;
        }

        public DynamicValue result = null;

        private void DynamicValueEditorDisplay_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = dynamicValueDisplay1.Value;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
