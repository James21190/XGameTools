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
        public ScriptHashTable ScriptHashTable;
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
    }
}
