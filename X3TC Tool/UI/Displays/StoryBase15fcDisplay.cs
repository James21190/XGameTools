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


namespace X3TC_Tool.UI.Displays
{
    public partial class StoryBase15fcDisplay : Form
    {
        private GameHook m_GameHook;
        private StoryBase15fc m_StoryBase15fc;
        public StoryBase15fcDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }

        public void Reload()
        {
            AddressBox.Text = m_StoryBase15fc.pThis.ToString("X");
            IDBox.Text = m_StoryBase15fc.ID.ToString();
            Unknown_1Box.Text = m_StoryBase15fc.Unknown_1.ToString("X");
            Unknown_2Box.Text = m_StoryBase15fc.Unknown_2.ToString("X");
            Unknown_3Box.Text = m_StoryBase15fc.Unknown_3.ToString("X");

            dynamicValueDisplay1.Value = m_StoryBase15fc.GetValue(StoryBase15fc.Indeces.Position_X);
            dynamicValueDisplay2.Value = m_StoryBase15fc.GetValue(StoryBase15fc.Indeces.Position_Y);
            dynamicValueDisplay3.Value = m_StoryBase15fc.GetValue(StoryBase15fc.Indeces.Position_Z);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_StoryBase15fc = new StoryBase15fc();
            m_StoryBase15fc.SetLocation(m_GameHook.hProcess, (IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
            Reload();
        }
    }
}
