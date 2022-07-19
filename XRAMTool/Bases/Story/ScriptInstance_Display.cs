using CommonToolLib.ProcessHooking;
using System;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Story.Scripting;
using XRAMTool.Bases.Sector;

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
            scriptInstanceView1.LoadObject(m_ScriptInstance);
        }

        public void LoadObject(int objID)
        {
            m_ScriptInstance = scriptInstanceView1.ReferenceGameHook.StoryBase.GetScriptInstance(objID);
            scriptInstanceView1.LoadObject(m_ScriptInstance);
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

        private void scriptInstanceView1_RequestVariableView(object sender, ScriptInstanceType.VariableType type, int variableValue, object additional)
        {
            switch (type)
            {
                case ScriptInstanceType.VariableType.ScriptInstanceID:
                    var newScriptInstanceDisplay = new ScriptInstance_Display();
                    newScriptInstanceDisplay.LoadObject(variableValue);
                    newScriptInstanceDisplay.Show();
                    return;
                case ScriptInstanceType.VariableType.Array:
                    var newArrayDisplay = new ScriptArray_Display();
                    newArrayDisplay.LoadFromScriptArrayObject(Program.GameHook.StoryBase.GetScriptArrayObject((IntPtr)variableValue));
                    newArrayDisplay.Show();
                    break;
                case ScriptInstanceType.VariableType.Table:
                    var newTableDisplay = new ScriptHashTable_Display();
                    newTableDisplay.LoadObject((IntPtr)variableValue);
                    newTableDisplay.Show();
                    break;
                case ScriptInstanceType.VariableType.Object:
                    var newObjectDisplay = new ScriptArray_Display();

                    // Get type data
                    var typeData = Program.GameHook.DataFileManager.GetScriptInstanceType((string)additional);
                    newObjectDisplay.VariableData = typeData.Variables;

                    // Populate
                    newObjectDisplay.LoadFromScriptArrayObject(Program.GameHook.StoryBase.GetScriptArrayObject((IntPtr)variableValue));

                    newObjectDisplay.Show();
                    break;
                case ScriptInstanceType.VariableType.SectorObjectID:
                    var newSectorObjectDisplay = new SectorObject_Display();

                    newSectorObjectDisplay.LoadObject(Program.GameHook.SectorBase.GetSectorObject(variableValue));

                    newSectorObjectDisplay.Show();
                    break;
            }
        }
    }
}
