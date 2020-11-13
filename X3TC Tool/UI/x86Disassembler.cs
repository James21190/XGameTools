using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Memory;
using SharpDisasm;
using X3TCTools;

namespace X3TC_Tool.UI
{
    public partial class x86Disassembler : Form
    {
        public x86Disassembler()
        {
            InitializeComponent();
        }

        public void Disassemble(IntPtr address)
        {
            textBox1.Text = "0x" + address.ToString("X");
            Disassembler.Translator.IncludeAddress = true;

            var buffer = MemoryControl.Read(GameHook.hProcess, address, 0xffff);

            var disassembler = new Disassembler(buffer, ArchitectureMode.x86_32,(ulong)address);

            var instructions = disassembler.Disassemble();

            richTextBox1.Text = "";

            int i = 0;
            const int max = 1000;

            foreach (var instruction in instructions)
            {
                if(i++ > max)
                {
                    richTextBox1.Text += "= Maximum lines reached =";
                    return;
                }
                richTextBox1.Text += instruction.ToString() + '\n';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int adr;
            if (int.TryParse(textBox1.Text, System.Globalization.NumberStyles.HexNumber, null, out adr))
                Disassemble((IntPtr)adr);
        }
    }
}
