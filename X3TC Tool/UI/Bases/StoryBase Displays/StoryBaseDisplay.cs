using System;
using System.Windows.Forms;
using X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting;
using X3Tools;
using X3Tools.Bases;
using X3Tools.Bases.StoryBase_Objects;
using X3Tools.Bases.StoryBase_Objects.Scripting;

namespace X3_Tool.UI.Displays
{
    public partial class StoryBaseDisplay : Form
    {
        private StoryBase m_StoryBase;
        public StoryBaseDisplay()
        {
            InitializeComponent();
            Reload();
        }

        public void Reload()
        {
            // Update instance
            m_StoryBase = GameHook.storyBase;
            m_StoryBase.ReloadFromMemory();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("StoryBase - ScriptingObjects");
            display.LoadTable(m_StoryBase.pHashTable_ScriptInstance.address);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reload();
            ScriptTaskObjectDisplay display = new ScriptTaskObjectDisplay();
            display.LoadObject(m_StoryBase.pCurrentScriptObject.obj);
            display.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay( "StoryBase - Scripting Arrays");
            display.LoadTable(m_StoryBase.pHashTable_ScriptArrayObject.address);
            display.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay( "StoryBase - Scripting HashTables");
            display.LoadTable(m_StoryBase.pHashTable_ScriptTableObject.address);
            display.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay();
            display.LoadTable(m_StoryBase.TextHashTableArray[44].address);
            display.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay("StoryBase - Scripting TextObjects");
            display.LoadTable(m_StoryBase.pHashTable_ScriptStringObject.address);
            display.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay();
            display.LoadTable(m_StoryBase.pHashTable_ScriptTaskObject.address);
            display.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ScriptTaskObject[] ScriptObjects = m_StoryBase.GetScriptObjectsWithReferenceTo((int)numericUpDown1.Value);

            listBox1.Items.Clear();
            listBox1.Items.AddRange(ScriptObjects);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= listBox1.Items.Count)
            {
                return;
            }

            ScriptTaskObjectDisplay display = new ScriptTaskObjectDisplay();
            display.LoadObject((ScriptTaskObject)listBox1.Items[listBox1.SelectedIndex]);
            display.Show();
        }

        private void ReloadScriptFunction(int index)
        {
            var functions = GameHook.storyBase.FunctionArray[index];

            txtPrimaryFunction.Text = functions.pPrimaryFunction.ToString("X");
            txtRegistrationFunction.Text = functions.pFunction2.ToString("X");
            txtFunction3.Text = functions.pFunction3.ToString("X");
            txtFunction4.Text = functions.pFunction4.ToString("X");
            txtFunctionUnknown.Text = functions.Index.ToString("X");

            txtDefinedFunctions.Text = string.Join("\n", functions.FunctionNames);

        }

        private void nudFunctionIndex_ValueChanged(object sender, EventArgs e)
        {
            ReloadScriptFunction((int)nudFunctionIndex.Value);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var searcher = new ScriptMemorySearcher();
            searcher.Show();
            searcher.Search(dynamicValueDisplay1.Value);
        }
    }
}
