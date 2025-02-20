using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XCommonLib.UI.Bases.Story
{
    public partial class ScriptTaskObjectView: UserControl
    {
        private ScriptTaskObject _ScriptTaskObject;
        public GameHook ReferenceGameHook = null;
        public ScriptTaskObjectView()
        {
            InitializeComponent();
        }

        public void LoadObject(ScriptTaskObject obj)
        {
            _ScriptTaskObject = obj;
            Reload();
        }

        public void Reload()
        {
            scriptVariableArrayView1.DynamicValues = _ScriptTaskObject.Stack;
        }
    }
}
