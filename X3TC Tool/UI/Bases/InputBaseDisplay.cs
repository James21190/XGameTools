using System;
using System.Windows.Forms;
using X3_Tool.UI.Bases.StoryBase_Displays.Scripting;
using X3Tools;

namespace X3_Tool.UI.Displays
{
    public partial class InputBaseDisplay : Form
    {
        public InputBaseDisplay()
        {
            InitializeComponent();
            Reload();
        }

        public void Reload()
        {
            X3Tools.Bases.InputBase InputBase = GameHook.inputBase;

            txtAddress.Text = InputBase.pThis.ToString("X");

            ScriptingObjectIDBox.Text = InputBase.ScriptingObjectID.ToString();
        }

        private void ScriptingObjectIDLoadButton_Click(object sender, EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(GameHook.inputBase.ScriptingObjectID);
            display.Show();
        }

        private void btnViewHashTable1_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay();
            display.LoadTable(GameHook.inputBase.pHashTable1.address);
            display.Show();
        }

        private void btnViewHashTable2_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay();
            display.LoadTable(GameHook.inputBase.pHashTable2.address);
            display.Show();
        }
    }
}
