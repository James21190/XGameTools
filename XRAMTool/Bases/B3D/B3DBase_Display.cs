using CommonToolLib.Generics;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.B3D;

namespace XRAMTool.Bases.B3D
{
    public partial class B3DBase_Display : Form
    {
        public B3DBase_Display()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            XCommonLib.RAM.Bases.B3D.B3DBase b3dB = Program.GameHook.B3DBase;
            ntxtAddress.Text = b3dB.pThis.ToString("X");

            dataGridView1.Rows.Clear();
            var renderObjects = b3dB.GetRenderObjects();
            foreach ( var renderObject in renderObjects )
            {
                dataGridView1.Rows.Add(renderObject.ID, Program.GameHook.DataFileManager.GetModelBodyName(renderObject.BodyID), Program.GameHook.DataFileManager.GetModelCollectionName(renderObject.CollectionID));
            }
        }

        private void B3DBase_Display_Load(object sender, System.EventArgs e)
        {
            Reload();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var display = new RenderObject_Display();
            var row = dataGridView1.SelectedCells[0].RowIndex;
            display.LoadObject(Program.GameHook.B3DBase.GetRenderObject((int)dataGridView1.Rows[row].Cells[0].Value));
            display.Show();
        }
    }
}
