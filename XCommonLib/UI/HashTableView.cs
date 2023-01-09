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
        public HashTable<MemoryInt32> HashTable = new HashTable<MemoryInt32>();

        public IMemoryBlockManager ParentMemoryBlock
        {
            get
            {
                return HashTable.ParentMemoryBlock;
            }
            set
            {
                HashTable.ParentMemoryBlock = value;
            }
        }

        public IntPtr pHashTable
        {
            get
            {
                return HashTable.pThis;
            }
            set
            {
                HashTable.pThis = value;
            }
        }

        public HashTableView()
        {
            InitializeComponent();
        }

        private int[] _ScanResults;

        public void ScanHashTable()
        {
            HashTable.ReloadFromMemory();
            _ScanResults = HashTable.ScanContents();
            Reload();
        }

        public void Reload()
        {
            HashTable.ReloadFromMemory();
            ntxtLength.Text = HashTable.Length.ToString();
            int searchnum;
            if (int.TryParse(txtSearch.Text, out searchnum))
                ntxtSearchedIndex.Text = HashTable.GetIndex(searchnum).ToString();
            else
                ntxtSearchedIndex.Text = "";
            listBox1.Items.Clear();
            foreach(var item in _ScanResults)
            {
                if(item.ToString().Contains(txtSearch.Text))
                    listBox1.Items.Add(item);
            }

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanHashTable();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            var selectedID = (int)listBox1.SelectedItem;
            ntxtEntryID.Text = selectedID.ToString();
            ntxtEntryObject.Text = HashTable.GetAddress(selectedID).ToString("X");
        }
    }
}
