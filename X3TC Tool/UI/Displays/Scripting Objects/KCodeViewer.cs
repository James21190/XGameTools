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
    public partial class KCodeViewer : Form
    {
        private GameHook m_GameHook;
        private StoryBase m_StoryBase;

        private int m_Offset;
        public KCodeViewer(GameHook gameHook)
        {
            m_GameHook = gameHook;
            InitializeComponent();
        }

        public void Reload()
        {
            m_StoryBase = m_GameHook.storyBase;

            richTextBox1.Clear();

            var dissassembler = new KCodeDissassembler(m_GameHook);
            var code = dissassembler.Dissassemble(m_Offset);
            foreach (var line in code)
            {
                richTextBox1.Text += line.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_Offset = (int)StartingIndexBox.Value;
            Reload();
        }

        private void KCodeViewer_Load(object sender, EventArgs e)
        {
            
        }
    }
}
