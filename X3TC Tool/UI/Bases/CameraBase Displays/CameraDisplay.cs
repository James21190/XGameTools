﻿using System;
using System.Windows.Forms;

using X3Tools;
using X3Tools.Bases;


namespace X3_Tool.UI.Displays
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
