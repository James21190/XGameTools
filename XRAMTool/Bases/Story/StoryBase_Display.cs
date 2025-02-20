using CommonToolLib.Generics;
using System;
using System.Windows.Forms;

namespace XRAMTool.Bases.Story
{
    public partial class StoryBase_Display : Form
    {
        public StoryBase_Display()
        {
            InitializeComponent();
        }

        private void StoryBase_Display_Load(object sender, System.EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            var storyBase = Program.GameHook.StoryBase;

            ntxtAddress.Text = storyBase.pThis.ToString("X");

            lstScriptInstances.Items.Clear();
            var scriptInstances = storyBase.GetAllScriptInstances();
            lblScriptInstanceCount.Text = "Count: " + scriptInstances.Length;
            foreach(var scriptInstanceID in scriptInstances)
                lstScriptInstances.Items.Add(scriptInstanceID);

            lstScriptTaskObjects.Items.Clear();
            var scriptTaskObjects = storyBase.GetAllScriptTaskObjects();
            lblScriptTaskObjectCount.Text = "Count: " + scriptTaskObjects.Length;
            foreach(var scriptTaskObjectID in scriptTaskObjects)
                lstScriptTaskObjects.Items.Add(scriptTaskObjectID);

            lstScriptStringObjects.Items.Clear();
            var scriptStringObjects = storyBase.GetAllScriptStringObjects();
            lblScriptStringObjectCount.Text = "Count: " + scriptStringObjects.Length;
            NamedObjectContainer[] arr = new NamedObjectContainer[scriptStringObjects.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = new NamedObjectContainer(storyBase.GetScriptStringObject(scriptStringObjects[i]).Text.Value, scriptStringObjects[i]);
            }
            Array.Sort(arr);
            foreach(var item in arr)
                lstScriptStringObjects.Items.Add(item);
        }

        private void lstScriptInstances_DoubleClick(object sender, System.EventArgs e)
        {
            var display = new ScriptInstance_Display();
            display.LoadObject(Program.GameHook.StoryBase.GetScriptInstance((int)lstScriptInstances.SelectedItem));
            display.Show();
        }

        private void lstScriptTaskObjects_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        private void lstScriptTaskObjects_DoubleClick(object sender, EventArgs e)
        {
            var display = new ScriptTaskObject_Display();
            display.LoadObject(Program.GameHook.StoryBase.GetScriptTaskObject((int)lstScriptTaskObjects.SelectedItem));
            display.Show();
        }
    }
}
