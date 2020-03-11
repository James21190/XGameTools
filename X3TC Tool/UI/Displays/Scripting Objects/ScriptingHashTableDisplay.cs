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
using Common.Memory;
using X3TCTools.Bases;
using X3TCTools.Bases.Scripting;

namespace X3TC_Tool.UI.Displays
{
    public partial class ScriptingHashTableDisplay : Form
    {
        private GameHook m_GameHook;

        private ScriptingHashTable m_HashTable = new ScriptingHashTable();

        public ScriptingHashTableDisplay(GameHook gameHook, string name = null)
        {
            InitializeComponent();
            m_GameHook = gameHook;
            if (name != null)
                Text = name;
        }

        public void LoadTable(IntPtr pHashTable)
        {
            if (AddressBox.Text != pHashTable.ToString("X")) AddressBox.Text = pHashTable.ToString("X");
            m_HashTable.SetLocation(m_GameHook.hProcess, pHashTable);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int NumOfInvalids;
            foreach(var item in m_HashTable.ScanContents(out NumOfInvalids))
            {
                var lb = new ListViewItem();
                lb.Text = item.ToString();
                lb.Tag = item;
                listBox1.Items.Add(lb);
            }
            ScannerLabel.Text = string.Format("{0} results found! {1} additional entries were found with null pointers. {2} in total.", listBox1.Items.Count, NumOfInvalids, NumOfInvalids + listBox1.Items.Count) ;
        }

        public void LoadEntry(DynamicValue id)
        {
            if (IDBox.Value != id) IDBox.Value = id;
            try
            {
                textBox2.Text = m_HashTable.GetAddress(id).ToString("X");
                dynamicValueDisplay1.Value = m_HashTable.GetObject(id);
            }
            catch (Exception e)
            {
                textBox2.Text = "Not Found!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadEntry(IDBox.Value);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= listBox1.Items.Count) return;
            LoadEntry((DynamicValue)((ListViewItem)listBox1.SelectedItem).Tag);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
