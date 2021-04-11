using System;
using System.Windows.Forms;
using X3TC_RAM_Tool.UI.Bases.CameraBase_Displays;
using X3Tools.RAM;
using X3Tools.RAM.Generics;

namespace X3TC_RAM_Tool.UI.Displays
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
            X3Tools.RAM.Bases.B3D.B3DBase b3dBase = GameHook.b3DBase;

            AddressBox.Text = b3dBase.pThis.ToString("X");
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

        private void btnRenderObjectFirst_Click(object sender, EventArgs e)
        {
            var display = new RenderObjectDisplay();
            display.LoadObject(GameHook.b3DBase.pFirstRenderObject.obj);
            display.Show();
        }

        private void btnRenderObjectLast_Click(object sender, EventArgs e)
        {
            var display = new RenderObjectDisplay();
            display.LoadObject(GameHook.b3DBase.pLastRenderObject.obj);
            display.Show();
        }

        private void btnRenderObjectTable_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay();
            display.LoadTable(GameHook.b3DBase.pRenderObjectHashTable.address);
            display.Show();
        }

        private void btnRenderObjectLoadID_Click(object sender, EventArgs e)
        {

        }

        private void btnBodyDataFirst_Click(object sender, EventArgs e)
        {
            var display = new BodyDataDisplay();
            display.LoadBodyData(GameHook.b3DBase.pFirstBodyData.obj);
            display.Show();
        }

        private void btnBodyDataLast_Click(object sender, EventArgs e)
        {
            var display = new BodyDataDisplay();
            display.LoadBodyData(GameHook.b3DBase.pLastBodyData.obj);
            display.Show();
        }

        private void btnBodyDataTable_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay();
            display.LoadTable(GameHook.b3DBase.pBodyHashTable.address);
            display.Show();
        }

        private void btnBodyDataLoadID_Click(object sender, EventArgs e)
        {

        }
    }
}
