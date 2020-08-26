using System;
using System.Windows.Forms;

using X3TCTools;
using X3TCTools.Bases.Scripting;

namespace X3TC_Tool.UI.Displays
{
    public partial class ScriptingHashTableDisplay : Form
    {

        private ScriptingHashTable m_HashTable = new ScriptingHashTable();

        public ScriptingHashTableDisplay(string name = null)
        {
            InitializeComponent();
            if (name != null)
            {
                Text = name;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int NumOfInvalids;
            DynamicValue[] contents = m_HashTable.ScanContents(out NumOfInvalids);
            Array.Sort(contents);
            foreach (DynamicValue item in contents)
            {
                listBox1.Items.Add(item);
            }
            ScannerLabel.Text = string.Format("{0} results found! {1} additional entries were found with null pointers. {2} in total.", listBox1.Items.Count, NumOfInvalids, NumOfInvalids + listBox1.Items.Count);
        }

        public void LoadEntry(DynamicValue id)
        {
            if (IDBox.Value != id)
            {
                IDBox.Value = id;
            }

            try
            {
                textBox2.Text = m_HashTable.GetAddress(id).ToString("X");
                dynamicValueDisplay1.Value = m_HashTable.GetObject(id);
            }
            catch (Exception)
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
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= listBox1.Items.Count)
            {
                return;
            }

            LoadEntry((DynamicValue)(listBox1.SelectedItem));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
