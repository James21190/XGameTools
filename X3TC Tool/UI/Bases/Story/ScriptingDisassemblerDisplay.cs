using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Story.Scripting.KCode;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays
{
    public partial class ScriptingDisassemblerDisplay : Form
    {
        public ScriptingDisassemblerDisplay()
        {
            InitializeComponent();
        }

        int m_address;
        bool reloading = false;
        public void LoadAddress(int address)
        {
            if (reloading) return;
            reloading = true;
            numericUpDown1.Value = address;
            m_address = address;
            Reload();
            reloading = false;
        }

        public void Reload()
        {
            richTextBox1.Text = "";
            var disassembler = new KDisassembler(FunctionDefinitionLibrary.GetKFunctionDefinitions(GameHook.GameVersion));
            var instructions = disassembler.Disassemble(m_address);
            foreach (var item in instructions)
            {
                richTextBox1.Text += item.ToString(checkBox1.Checked) + "\n";
            }

            txtMemory.Text = "";
            StringBuilder sb = new StringBuilder();
            var storyBase = GameHook.storyBase;
            sb.Append(m_address.ToString("D7") + " || ");
            const int lineCount = 20;
            for(int i = 1; i <= 32 * lineCount; i++)
            {
                sb.Append(storyBase.pInstructionArray[m_address + i - 1].Value.ToString("X2"));
                if (i == 30 * lineCount) break;
                if( i % 30 == 0)
                {
                    sb.Append("\n" + (m_address + i).ToString("D7") + " || ");
                }
                else if(i % 10 == 0)
                {
                    sb.Append(" || ");
                }
                else
                {
                    sb.Append(" ");
                }
            }
            txtMemory.Text = sb.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadAddress((int)numericUpDown1.Value);
        }
    }
}
