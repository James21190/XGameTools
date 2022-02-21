using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRAMTool.Bases.SystemBase
{
    public partial class SystemBase_Display : Form
    {
        public SystemBase_Display()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            var systemBase = Program.GameHook.SystemBase;

            lstLaunchParams.Items.Clear();
            foreach(var item in systemBase.LaunchParams)
            {
                lstLaunchParams.Items.Add(item);
            }
        }

        private void SystemBase_Display_Load(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
