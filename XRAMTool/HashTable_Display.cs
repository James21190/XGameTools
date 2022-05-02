using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Generics;

namespace XRAMTool
{
    public partial class HashTable_Display : Form
    {
        public HashTable_Display()
        {
            InitializeComponent();
        }

        HashTable<MemoryInt32> _LoadedTable;

        public void Reload()
        {
            _LoadedTable = new HashTable<MemoryInt32>();

            hashTableView1.pHashTable = (IntPtr)int.Parse(txtAddress.Text, System.Globalization.NumberStyles.HexNumber);
        }

        private void HashTable_Display_Load(object sender, EventArgs e)
        {
            hashTableView1.hProcess = Program.GameHook.hProcess;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
