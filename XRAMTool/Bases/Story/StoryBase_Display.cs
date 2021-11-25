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

            lstScriptInstances.Items.Clear();
            foreach(var scriptInstanceID in storyBase.GetAllScriptInstances())
                lstScriptInstances.Items.Add(scriptInstanceID);
        }

        private void lstScriptInstances_DoubleClick(object sender, System.EventArgs e)
        {
            var display = new ScriptInstance_Display();
            display.LoadObject(Program.GameHook.StoryBase.GetScriptInstance((int)lstScriptInstances.SelectedItem));
            display.Show();
        }
    }
}
