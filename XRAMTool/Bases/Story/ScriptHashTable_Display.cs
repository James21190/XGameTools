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

namespace XRAMTool.Bases.Story
{
    public partial class ScriptHashTable_Display : Form
    {
        public ScriptHashTable ScriptHashTable
        {
            get
            {
                return scriptingHashTableView1.ScriptHashTable;
            }
            set
            {
                scriptingHashTableView1.ScriptHashTable = value;
            }
        }
        public ScriptHashTable_Display()
        {
            InitializeComponent();
        }
    }
}
