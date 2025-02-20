using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XCommonLib.UI.Bases.Story
{
    public partial class ScriptingHashTableView : UserControl
    {
        private ScriptTableObject _scriptTaskObject;
        public ScriptTableObject ScriptHashTable
        {
            get { return _scriptTaskObject; }
            set
            {
                _scriptTaskObject = value;
                Reload();
            }
        }

        public void Reload()
        {
            nnudCount.Value = ScriptHashTable.Count;
        }
        public ScriptingHashTableView()
        {
            InitializeComponent();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach(var id in ScriptHashTable.ScanContents())
            {
                listBox1.Items.Add(id);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            var selectedID = (DynamicValue)listBox1.SelectedItem;
            var obj = ScriptHashTable.GetObject(selectedID);
            textBox1.Text = obj.ToString();
        }
    }
}
