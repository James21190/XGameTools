using System;
using System.Windows.Forms;

using X3Tools.RAM;
using X3Tools.RAM.Bases;
using X3Tools.RAM.Bases.B3D;


namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class CameraDisplay : Form
    {
        private Camera m_Camera;
        public CameraDisplay()
        {
            InitializeComponent();
        }

        public void LoadCamera(Camera camera)
        {
            m_Camera = camera;
            Reload();
        }

        public void LoadCamera(IntPtr pCamera)
        {
            Camera camera = new Camera();
            camera.SetLocation(GameHook.hProcess, pCamera);
            LoadCamera(camera);
        }

        public void Reload()
        {
            m_Camera.ReloadFromMemory();

            numericIDObjectControl1.LoadObject(m_Camera);
            FunctionIndexBox.Text = m_Camera.FunctionIndex.ToString();
            FocusBox.Text = m_Camera.Focus.ToString();
            textBox1.Text = m_Camera.Pri.ToString();
            FogDisplay.Vector = m_Camera.Fog;
            BackgroundDisplay.Vector = m_Camera.Background;
        }
    }
}
