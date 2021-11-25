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
using XCommonLib.RAM.Generics;

namespace XCommonLib.UI
{
    public partial class HashTableView : UserControl
    {
        private HashTable<MemoryInt32> _HashTable = new HashTable<MemoryInt32>();

        public IntPtr hProcess
        {
            get
            {
                return _HashTable.hProcess;
            }
            set
            {
                _HashTable.hProcess = value;
            }
        }

        public IntPtr pHashTable
        {
            get
            {
                return _HashTable.pThis;
            }
            set
            {
                _HashTable.pThis = value;
            }
        }

        public HashTableView()
        {
            InitializeComponent();
        }

        public void ScanHashTable()
        {
            listBox1.Items.Clear();
            foreach(var item in _HashTable.ScanContents())
            {
                listBox1.Items.Add(item);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanHashTable();
        }
    }
}
