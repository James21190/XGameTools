using System;
using System.Windows.Forms;

using X3Tools.Bases.StoryBase_Objects.Scripting;

namespace X3_Tool.UI.Displays
{
    public partial class EventObjectSubDisplay : Form
    {
        public EventObjectSubDisplay()
        {
            InitializeComponent();
        }

        private ScriptingObjectSub m_EventObjectSub;
        public void LoadObject(ScriptingObjectSub eventObjectSub)
        {
            m_EventObjectSub = eventObjectSub;
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_EventObjectSub.pThis.ToString("X");

            IDBox.Text = m_EventObjectSub.Class.ToString();
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
