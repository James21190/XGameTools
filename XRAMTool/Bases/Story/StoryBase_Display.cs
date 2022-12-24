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
        }

        private void lstScriptInstances_DoubleClick(object sender, System.EventArgs e)
        {
            var display = new ScriptInstance_Display();
            display.LoadObject(Program.GameHook.StoryBase.GetScriptInstance((int)lstScriptInstances.SelectedItem));
            display.Show();
        }
    }
}
