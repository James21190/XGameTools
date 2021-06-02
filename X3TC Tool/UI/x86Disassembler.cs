using CommonToolLib.Memory;
using SharpDisasm;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3Tools.RAM;

namespace X3TC_RAM_Tool.UI
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

            byte[] buffer = MemoryControl.Read(GameHook.hProcess, address, 0xffff);

            Disassembler disassembler = new Disassembler(buffer, ArchitectureMode.x86_32, (ulong)address);

            IEnumerable<Instruction> instructions = disassembler.Disassemble();

            richTextBox1.Text = "";

            int i = 0;
            const int max = 1000;

            foreach (Instruction instruction in instructions)
            {
                if (i++ > max)
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
            {
                Disassemble((IntPtr)adr);
            }
        }
    }
}
