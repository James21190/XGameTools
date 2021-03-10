using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3Tools;

namespace X3_Tool.UI.Bases.SystemBase_Displays
{
    public partial class SystemBaseDisplay : Form
    {
        public SystemBaseDisplay()
        {
            InitializeComponent();
        }

        private void SystemBaseDisplay_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            var systemBase = GameHook.systemBase;
            txtAddress.Text = systemBase.pThis.ToString("X");
        }
    }
}
