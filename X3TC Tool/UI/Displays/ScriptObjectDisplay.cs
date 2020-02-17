using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Memory;
using X3TCTools;
using X3TCTools.Bases;

namespace X3TC_Tool.UI.Displays
{
    public partial class ScriptObjectDisplay : Form
    {
        private GameHook m_GameHook;
        private ScriptObject m_ScriptObject;
        public ScriptObjectDisplay(GameHook gameHook)
        {
            m_GameHook = gameHook;
            InitializeComponent();
        }

        public void LoadObject(IntPtr pObject)
        {
            var newobj = new ScriptObject();
            newobj.SetLocation(m_GameHook.hProcess, pObject);
            LoadObject(newobj);
        }
        public void LoadObject(ScriptObject scriptObject)
        {
            m_ScriptObject = scriptObject;
            Reload();
        }

        public void Reload()
        {
            if(m_ScriptObject == null)
            {
                NextButton.Enabled = false;
                PreviousButton.Enabled = false;

                AddressBox.Text = "Not Found!";

                return;
            }
            if (m_ScriptObject.pThis.ToString("X") != AddressBox.Text) AddressBox.Text = m_ScriptObject.pThis.ToString("X");
            if (m_ScriptObject.ID != IDNumericUpDown.Value) IDNumericUpDown.Value = m_ScriptObject.ID;

            NextButton.Enabled = m_ScriptObject.pNext.IsValid;
            PreviousButton.Enabled = m_ScriptObject.pPrevious.IsValid;

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadObject((IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_ScriptObject.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_ScriptObject.pPrevious.obj);
        }

        private void LoadIDButton_Click(object sender, EventArgs e)
        {
            var storybase = m_GameHook.storyBase;
            try
            {
                var table = storybase.pScriptObjectHashTable.obj;
                var obj = table.GetObject((int)IDNumericUpDown.Value);
                LoadObject(obj);
            }
            catch (Exception)
            {
                m_ScriptObject = null;
                Reload();
            }
        }
    }
}
