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
            m_StoryBase.ReloadFromMemory();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay(m_GameHook);
            display.LoadTable(m_StoryBase.pScriptObjectHashTable.address);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var display = new ScriptObjectDisplay(m_GameHook);
            display.LoadObject(m_StoryBase.pCurrentScriptObject.obj);
            display.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var display = new DynamicValueArrayDisplay(m_GameHook);
            display.LoadFrom(m_StoryBase.pInstructionArray.address, 0, 0);
            display.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay(m_GameHook);
            display.LoadTable(m_StoryBase.pScriptingArrayObject_HashTable.address);
            display.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay(m_GameHook);
            display.LoadTable(m_StoryBase.pScriptingHashTableObject_HashTable.address);
            display.Show();
        }
    }
}
