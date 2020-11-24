using System;
using System.Windows.Forms;

using X3Tools.Bases.StoryBase_Objects.Scripting;

namespace X3_Tool.UI.Displays
{
    public partial class ScriptingObjectSubDisplay : Form
    {
        public ScriptingObjectSubDisplay()
        {
            InitializeComponent();
        }

        private ScriptingObjectSub m_ScriptingObjectSub;
        public void LoadObject(ScriptingObjectSub ScriptingObjectSub)
        {
            m_ScriptingObjectSub = ScriptingObjectSub;
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_ScriptingObjectSub.pThis.ToString("X");

            IDBox.Text = m_ScriptingObjectSub.Class.ToString();
            SelfBox.Text = m_ScriptingObjectSub.pSelf.ToString("X");
            NextIDTextBox.Text = m_ScriptingObjectSub.NextID.ToString();
            ScriptVariableCountBox.Text = m_ScriptingObjectSub.ScriptVariableCount.ToString();

            Unknown1Box.Text = m_ScriptingObjectSub.Unknown_1.ToString();
            Unknown2Box.Text = m_ScriptingObjectSub.Unknown_2.ToString("X");
            Unknown3Box.Text = m_ScriptingObjectSub.Unknown_3.ToString("X");
            Unknown4Box.Text = m_ScriptingObjectSub.Unknown_4.ToString();
            Unknown5Box.Text = m_ScriptingObjectSub.Unknown_5.ToString("X");
            Unknown6Box.Text = m_ScriptingObjectSub.Unknown_6.ToString();
            Unknown7Box.Text = m_ScriptingObjectSub.Unknown_7.ToString("X");
            Unknown8Box.Text = m_ScriptingObjectSub.Unknown_8.ToString();

            button1.Enabled = m_ScriptingObjectSub.pNext.IsValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadObject(m_ScriptingObjectSub.pNext.obj);
        }
    }
}
