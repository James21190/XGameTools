using System;
using System.Windows.Forms;
using X3Tools.RAM;

namespace X3TC_RAM_Tool.UI.Bases.SystemBase_Displays
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
            X3Tools.RAM.Bases.SystemBase_Objects.SystemBase systemBase = GameHook.systemBase;
            txtAddress.Text = systemBase.pThis.ToString("X");
        }
    }
}
