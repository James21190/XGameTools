using System;
using System.Windows.Forms;
using X3_Tool.UI.Bases.CameraBase_Displays;
using X3Tools;
using X3Tools.Bases.SectorBase_Objects;
using X3Tools.Bases.B3DBase_Objects;

namespace X3_Tool.UI.Displays
{
    public partial class RenderObjectDisplay : Form
    {
        private RenderObject m_RenderObject;
        public RenderObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadObject(RenderObject renderObject)
        {
            m_RenderObject = renderObject;
            Reload();
        }

        public void Reload()
        {
            numericIDObjectControl1.LoadObject(m_RenderObject);

            ScaleBox.Vector = m_RenderObject.ModelScale;

            nudSize.Value = m_RenderObject.Size;
            nudTotalSize.Value = m_RenderObject.TotalSize;

            nudModelID.Value = m_RenderObject.ModelID;

            nudHue.Value = m_RenderObject.Hue;

            vec3Saturation.Vector = m_RenderObject.Saturation;

            // Relations
            NextButton.Enabled = m_RenderObject.pNext.obj.IsValid;
            PreviousButton.Enabled = m_RenderObject.pPrevious.obj.IsValid;
            FirstChildButton.Enabled = m_RenderObject.pFirstChild.obj.IsValid;
            LastChildButton.Enabled = m_RenderObject.pLastChild.obj.IsValid;
            btnParent.Enabled = m_RenderObject.pParent.obj.IsValid;
        }


        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_RenderObject.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_RenderObject.pPrevious.obj);
        }

        private void FirstChildButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_RenderObject.pFirstChild.obj);
        }

        private void LastChildButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_RenderObject.pLastChild.obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_RenderObject.ModelScale = ScaleBox.Vector;
            m_RenderObject.ModelID = (int)nudModelID.Value;
            m_RenderObject.Save();
        }

        private void btnParent_Click(object sender, EventArgs e)
        {
            LoadObject(m_RenderObject.pParent.obj);
        }

        private void btnViewModelData_Click(object sender, EventArgs e)
        {
            var display = new BodyDataDisplay();
            display.LoadBodyData(m_RenderObject.ModelID);
            display.Show();
        }

        private void numericIDObjectControl1_IDLoad(object sender, int value)
        {

        }

        private void numericIDObjectControl1_AddressLoad(object sender, int value)
        {

        }
    }
}
