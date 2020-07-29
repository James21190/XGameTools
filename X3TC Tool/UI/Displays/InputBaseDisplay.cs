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

namespace X3TC_Tool.UI.Displays
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
            var InputBase = GameHook.inputBase;

            EventObjectIDBox.Text = InputBase.EventObjectID.ToString();
        }

        private void EventObjectIDLoadButton_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay();
            display.LoadObject(GameHook.inputBase.EventObjectID);
            display.Show();
        }
    }
}
