using System;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class ScriptInstanceSubDisplay : Form
    {
        public ScriptInstanceSubDisplay()
        {
            InitializeComponent();
        }

        private ScriptInstanceSub m_ScriptingObjectSub;
        public void LoadObject(IntPtr address)
        {
            ScriptInstanceSub sos = new ScriptInstanceSub();
            sos.SetLocation(GameHook.hProcess, address);
            sos.ReloadFromMemory();
            LoadObject(sos);
        }
        public void LoadObject(ScriptInstanceSub ScriptingObjectSub)
        {
            m_ScriptingObjectSub = ScriptingObjectSub;
            Reload();
        }

        public void Reload()
        {
            textBox2.Text = m_ScriptingObjectSub.pThis.ToString("X");

            IDBox.Text = m_ScriptingObjectSub.Class.ToString();
            SelfBox.Text = m_ScriptingObjectSub.pSelf.ToString("X");
            NextIDTextBox.Text = m_ScriptingObjectSub.NextID.ToString();
            ScriptVariableCountBox.Text = m_ScriptingObjectSub.ScriptVariableCount.ToString();

            Unknown1Box.Text = m_ScriptingObjectSub.Unknown_1.ToString();
            Unknown2Box.Text = m_ScriptingObjectSub.Unknown_2.ToString("X");
            Unknown3Box.Text = m_ScriptingObjectSub.Unknown_3.ToString("X");
            Unknown4Box.Text = m_ScriptingObjectSub.Unknown_4.ToString();
            Unknown5Box.Text = m_ScriptingObjectSub.Unknown_5.ToString("X");
            Unknown6Box.Text = m_ScriptingObjectSub.FunctionCount_1.ToString();
            Unknown8Box.Text = m_ScriptingObjectSub.Unknown.ToString();

            textBox1.Text = m_ScriptingObjectSub.pFunctions[(int)numericUpDown1.Value].str;
            button1.Enabled = m_ScriptingObjectSub.pNext.IsValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadObject(m_ScriptingObjectSub.pNext.obj);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadObject((IntPtr)int.Parse(textBox2.Text, System.Globalization.NumberStyles.HexNumber));
        }
    }
}
