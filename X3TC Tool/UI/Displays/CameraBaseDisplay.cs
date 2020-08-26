using System;
using System.Windows.Forms;

using X3TCTools;

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
            X3TCTools.Bases.CameraBase cameraBase = GameHook.cameraBase;

            AddressBox.Text = cameraBase.pThis.ToString("X");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay(GameHook);
            display.LoadTable(GameHook.cameraBase.pCameraHashTable.address);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay(GameHook);
            display.LoadTable(GameHook.cameraBase.pModelCollectionHashTable.address);
            display.Show();
        }
    }
}
