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
using X3TCTools.Bases;
using Common.Memory;


namespace X3TC_Tool.UI.Displays
{
    public partial class CameraDisplay : Form
    {
        private GameHook m_GameHook;
        private Camera m_Camera;
        public CameraDisplay(GameHook gameHook)
        {
            m_GameHook = gameHook;
            InitializeComponent();
        }

        public void LoadCamera(Camera camera)
        {
            m_Camera = camera;
            Reload();
        }

        public void LoadCamera(IntPtr pCamera)
        {
            var camera = new Camera();
            camera.SetLocation(m_GameHook.hProcess, pCamera);
            LoadCamera(camera);
        }

        public void Reload()
        {
            m_Camera.ReloadFromMemory();
            AddressBox.Text = m_Camera.pThis.ToString("X");
            IDBox.Text = m_Camera.ID.ToString();
            FunctionIndexBox.Text = m_Camera.FunctionIndex.ToString();
            FocusBox.Text = m_Camera.Focus.ToString();
            textBox1.Text = m_Camera.Pri.ToString();
            FogDisplay.Vector = m_Camera.Fog;
            BackgroundDisplay.Vector = m_Camera.Background;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadCamera((IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
        }
    }
}
