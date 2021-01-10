using System;
using System.Windows.Forms;
using X3_Tool.UI.Bases.StoryBase_Displays.Scripting;
using X3Tools;

namespace X3_Tool.UI.Displays
{
    public partial class InputBaseDisplay : Form
    {
        private GameHook GameHook;
        public InputBaseDisplay(GameHook gameHook)
        {
            InitializeComponent();
            GameHook = gameHook;
            Reload();
        }

        public void Reload()
        {
            X3Tools.Bases.InputBase InputBase = GameHook.inputBase;

            ScriptingObjectIDBox.Text = InputBase.ScriptingObjectID.ToString();
        }

        private void ScriptingObjectIDLoadButton_Click(object sender, EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(GameHook.inputBase.ScriptingObjectID);
            display.Show();
        }
    }
}
