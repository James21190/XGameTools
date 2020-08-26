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
using X3TCTools.Bases.Scripting;

namespace X3TC_Tool.UI.Displays
{
    public partial class EventObjectSubDisplay : Form
    {
        public EventObjectSubDisplay()
        {
            InitializeComponent();
        }

        private EventObjectSub m_EventObjectSub;
        public void LoadObject(EventObjectSub eventObjectSub)
        {
            m_EventObjectSub = eventObjectSub;
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_EventObjectSub.pThis.ToString("X");

            IDBox.Text = m_EventObjectSub.ID.ToString();
            SelfBox.Text = m_EventObjectSub.pSelf.ToString("X");
            NextIDTextBox.Text = m_EventObjectSub.NextID.ToString();
            ScriptVariableCountBox.Text = m_EventObjectSub.ScriptVariableCount.ToString();

            Unknown1Box.Text = m_EventObjectSub.Unknown_1.ToString();
            Unknown2Box.Text = m_EventObjectSub.Unknown_2.ToString("X");
            Unknown3Box.Text = m_EventObjectSub.Unknown_3.ToString("X");
            Unknown4Box.Text = m_EventObjectSub.Unknown_4.ToString();
            Unknown5Box.Text = m_EventObjectSub.Unknown_5.ToString("X");
            Unknown6Box.Text = m_EventObjectSub.Unknown_6.ToString();
            Unknown7Box.Text = m_EventObjectSub.Unknown_7.ToString("X");
            Unknown8Box.Text = m_EventObjectSub.Unknown_8.ToString();

            button1.Enabled = m_EventObjectSub.pNext.IsValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadObject(m_EventObjectSub.pNext.obj);
        }
    }
}
