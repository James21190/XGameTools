using System;
using System.Windows.Forms;
using X3_Tool.UI.Bases.CameraBase_Displays;
using X3Tools;
using X3Tools.Generics;

namespace X3_Tool.UI.Displays
{
    public partial class CameraBaseDisplay : Form
    {
        public CameraBaseDisplay()
        {
            InitializeComponent();
            Reload();
        }

        public void Reload()
        {
            X3Tools.Bases.CameraBase cameraBase = GameHook.cameraBase;

            AddressBox.Text = cameraBase.pThis.ToString("X");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("CameraBase - Cameras");
            display.LoadTable(GameHook.cameraBase.pCameraHashTable.address);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("CameraBase - Model Collections");
            display.LoadTable(GameHook.cameraBase.pModelCollectionHashTable.address);
            display.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("CameraBase - Scenes");
            display.LoadTable(GameHook.cameraBase.pSceneHashTable.address);
            display.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("CameraBase - Bodies");
            display.LoadTable(GameHook.cameraBase.pBodyHashTable.address);
            display.Show();
        }

        private void btnBodyLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var data = GameHook.cameraBase.GetBodyData((int)nudBodyID.Value);
                var display = new BodyDataDisplay();
                display.LoadBodyData(data);
                display.Show();
            }
            catch (HashTableElementNotFoundException)
            {

            }
        }
    }
}
