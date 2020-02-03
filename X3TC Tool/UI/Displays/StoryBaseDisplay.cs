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
using X3TCTools.Bases;

namespace X3TC_Tool.UI.Displays
{
    public partial class StoryBaseDisplay : Form
    {
        private GameHook m_GameHook;
        private StoryBase m_StoryBase;
        public StoryBaseDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
            Reload();
        }

        public void Reload()
        {
            // Update instance
            m_StoryBase = m_GameHook.storyBase;

        }
    }
}
