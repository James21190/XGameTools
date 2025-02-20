using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Story.Scripting;
using XCommonLib.UI.Bases.Story;

namespace XRAMTool.Bases.Story
{
    public partial class ScriptTaskObject_Display: Form
    {
        private ScriptTaskObject _ScriptTaskObject;
        public ScriptTaskObject_Display()
        {
            InitializeComponent();
            scriptTaskObjectView1.ReferenceGameHook = Program.GameHook;
        }

        public void LoadObject(ScriptTaskObject obj)
        {
            _ScriptTaskObject = obj;
            scriptTaskObjectView1.LoadObject(_ScriptTaskObject);
        }
        private void ScriptTaskObject_Display_Load(object sender, EventArgs e)
        {

        }
    }
}
