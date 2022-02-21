using System;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XRAMTool.Bases.Story
{
    public partial class ScriptInstance_Display : Form
    {
        private ScriptInstance m_ScriptInstance;
        public ScriptInstance_Display()
        {
            InitializeComponent();
            scriptInstanceView1.ReferenceGameHook = Program.GameHook;
        }
        public void LoadObject(ScriptInstance obj)
        {
            m_ScriptInstance = obj;
            scriptInstanceView1.LoadObject(obj);
        }

        private void scriptInstanceView1_OnViewClicked(object sender, DynamicValue dynamicValue)
        {
            Form display;
            switch (dynamicValue.Flag)
            {
                case DynamicValue.FlagType.pHashTable:
                    var hashTableDisplay = new ScriptHashTable_Display();
                    hashTableDisplay.ScriptHashTable = Program.GameHook.StoryBase.GetScriptHashTable((IntPtr)dynamicValue.Value);
                    display = hashTableDisplay;
                    break;
                default: return;
            }
            display.Show();
        }

        private void scriptInstanceView1_AddressLoad(object sender, int value)
        {

        }

        private void scriptInstanceView1_IDLoad(object sender, int value)
        {

        }
    }
}
