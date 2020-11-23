using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3Tools;
using X3Tools.Bases.CameraBase_Objects;
using X3Tools.Generics;

namespace X3_Tool.UI.Bases.CameraBase_Displays
{
    public partial class BodyDataDisplay : Form
    {
        public BodyDataDisplay()
        {
            InitializeComponent();
        }
        BodyData m_BodyData;
        public void LoadBodyData(BodyData bodyData)
        {
            m_BodyData = bodyData;
            Reload();
        }
        public void LoadBodyData(int id)
        {
            try
            {
                LoadBodyData(GameHook.cameraBase.GetBodyData(id));
            }
            catch (HashTableElementNotFoundException)
            {
                txtAddress.Text = "Not Found!";
            }
        }
        public void Reload()
        {
            txtAddress.Text = m_BodyData.pThis.ToString("X");
            nudID.Value = m_BodyData.ID;
        }

        private void btnLoadID_Click(object sender, EventArgs e)
        {
            LoadBodyData((int)nudID.Value);                
        }
    }
}
