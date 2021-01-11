﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using X3Tools;

using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;

namespace X3_Tool.UI.Displays
{
    public partial class ScriptArrayObjectDisplay : Form
    {
        ScriptArrayObject m_obj;

        public ScriptArrayObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadArray(ScriptArrayObject obj)
        {
            m_obj = obj;
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_obj.pThis.ToString("X");
            txtID.Text = m_obj.ID.ToString();
            var arr = new ScriptMemoryObject(m_obj.Length);
            arr.SetLocation(GameHook.hProcess, m_obj.pDynamicValueArr.address);
            arr.ReloadFromMemory();
            scriptMemoryObject_Raw_Panel1.LoadObject(arr);
        }

        private void ScriptArrayObjectDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}
