using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X3TCTools;
using Common.Memory;

namespace X3TC_Tool.UI.Displays
{
    public partial class CameraBaseDisplay : Form
    {
        private GameHook GameHook;
        public CameraBaseDisplay(GameHook gameHook)
        {
            InitializeComponent();
            GameHook = gameHook;
            Reload();
        }

        public void Reload()
        {
            var cameraBase = GameHook.cameraBase;

            AddressBox.Text = cameraBase.pThis.ToString("X");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay(GameHook);
            display.LoadTable(GameHook.cameraBase.pCameraHashTable.address);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay(GameHook);
            display.LoadTable(GameHook.cameraBase.pModelCollectionHashTable.address);
            display.Show();
        }
    }
}
