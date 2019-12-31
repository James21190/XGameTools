using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X2Tools.X2.SectorObjects;

namespace X2TheThreatRETool
{
    partial class X2RETool : Form
    {
        private void button36_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex != -1) 
                m_GameHook.GameCodeRunner.LoadAllObjects((SectorObject.Main_Type)comboBox6.SelectedIndex);
        }

    }
}
