using CommonToolLib.Memory;
using System;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Generics;

namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class HashTableDisplay : Form
    {
        private HashTable<MemoryInt32> m_HashTable = new HashTable<MemoryInt32>();

        public HashTableDisplay(string title = null)
        {
            InitializeComponent();
            if (title != null)
            {
                SetTitle(title);
            }
        }

        public void LoadTable(IntPtr pHashTable)
        {
            if (AddressBox.Text != pHashTable.ToString("X"))
            {
                AddressBox.Text = pHashTable.ToString("X");
            }

            m_HashTable.SetLocation(GameHook.hProcess, pHashTable);
            m_HashTable.ReloadFromMemory();
            Reload();
        }

        public void Reload()
        {
            ScannerLabel.Text = "Not Scanned";
            listBox1.Items.Clear();
            CountBox.Text = m_HashTable.Count.ToString();
            NextAvailableIDBox.Text = m_HashTable.NextAvailableID.ToString();
            SizeBox.Text = m_HashTable.Length.ToString();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadTable((IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
            SetTitle("0x" + AddressBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int NumOfInvalids;
            foreach (int item in m_HashTable.ScanContents(out NumOfInvalids))
            {
                listBox1.Items.Add(item);
            }
            ScannerLabel.Text = string.Format("{0} results found! {1} additional entries were found with null pointers. {2} in total.", listBox1.Items.Count, NumOfInvalids, NumOfInvalids + listBox1.Items.Count);
        }

        public void LoadEntry(int id)
        {
            if (EntryIDSelector.Value != id)
            {
                EntryIDSelector.Value = id;
            }

            try
            {
                textBox2.Text = m_HashTable.GetAddress(id).ToString("X");
            }
            catch (Exception)
            {
                textBox2.Text = "Not Found!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadEntry((int)EntryIDSelector.Value);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= listBox1.Items.Count)
            {
                return;
            }

            LoadEntry(Convert.ToInt32(listBox1.SelectedItem.ToString()));
        }

        public void SetTitle(string title)
        {
            Text = string.Format("HashTable View : {0}", title);
        }
    }
}
