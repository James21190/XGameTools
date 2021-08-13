using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Story.Scripting;
using XCommonLib.RAM;

namespace XCommonLib.UI.Bases.Story
{
    public partial class ScriptInstanceView : UserControl
    {
        private ScriptInstance m_ScriptInstance;
        public GameHook ReferenceGameHook = null;
        public ScriptInstanceView()
        {
            InitializeComponent();
        }

        public void LoadObject(ScriptInstance obj)
        {
            m_ScriptInstance = obj;
            Reload();
        }
        public void Reload()
        {
            numericIDObjectControl1.LoadObject(m_ScriptInstance);
        }
    }
}
