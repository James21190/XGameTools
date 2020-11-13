using System;
using System.Windows.Forms;
using X3TC_Tool.UI.Bases.CameraBase_Displays;
using X3TCTools;
using X3TCTools.Sector_Objects;

namespace X3TC_Tool.UI.Displays
{
    public partial class RenderObjectDisplay : Form
    {
        private RenderObject m_RenderObject;
        public RenderObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadData(RenderObject renderObject)
        {
            m_RenderObject = renderObject;
            Reload();
        }

        public void LoadData(IntPtr pRenderObject)
        {
            m_RenderObject = new RenderObject();
            m_RenderObject.SetLocation(GameHook.hProcess, pRenderObject);
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_RenderObject.pThis.ToString("X");

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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData((IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadData(m_RenderObject.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadData(m_RenderObject.pPrevious.obj);
        }

        private void FirstChildButton_Click(object sender, EventArgs e)
        {
            LoadData(m_RenderObject.pFirstChild.obj);
        }

        private void LastChildButton_Click(object sender, EventArgs e)
        {
            LoadData(m_RenderObject.pLastChild.obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_RenderObject.ModelScale = ScaleBox.Vector;
            m_RenderObject.ModelID = (int)nudModelID.Value;
            m_RenderObject.Save();
        }

        private void btnParent_Click(object sender, EventArgs e)
        {
            LoadData(m_RenderObject.pParent.obj);
        }

        private void btnViewModelData_Click(object sender, EventArgs e)
        {
            var display = new BodyDataDisplay();
            display.LoadBodyData(m_RenderObject.ModelID);
            display.Show();
        }
    }
}
