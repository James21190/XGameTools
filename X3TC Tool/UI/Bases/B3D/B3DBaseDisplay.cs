using System;
using System.Windows.Forms;
using X3_Tool.UI.Bases.CameraBase_Displays;
using X3Tools;
using X3Tools.Generics;

namespace X3_Tool.UI.Displays
{
    public partial class B3DBaseDisplay : Form
    {
        public B3DBaseDisplay()
        {
            InitializeComponent();
            Reload();
        }

        public void Reload()
        {
            X3Tools.Bases.B3D.B3DBase b3dBase = GameHook.b3DBase;

            AddressBox.Text = b3dBase.pThis.ToString("X");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("B3DBase - Cameras");
            display.LoadTable(GameHook.b3DBase.pCameraHashTable.address);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("B3DBase - Model Collections");
            display.LoadTable(GameHook.b3DBase.pModelCollectionHashTable.address);
            display.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("B3DBase - Scenes");
            display.LoadTable(GameHook.b3DBase.pSceneHashTable.address);
            display.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("B3DBase - Bodies");
            display.LoadTable(GameHook.b3DBase.pBodyHashTable.address);
            display.Show();
        }

        private void btnBodyLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var data = GameHook.b3DBase.GetBodyData((int)nudBodyID.Value);
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
