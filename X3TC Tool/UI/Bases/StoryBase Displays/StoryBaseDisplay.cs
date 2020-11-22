using System;
using System.Windows.Forms;

using X3TCTools;
using X3TCTools.Bases;
using X3TCTools.Bases.StoryBase_Objects;
using X3TCTools.Bases.StoryBase_Objects.Scripting;

namespace X3TC_Tool.UI.Displays
{
    public partial class StoryBaseDisplay : Form
    {
        private GameHook GameHook;
        private StoryBase m_StoryBase;
        public StoryBaseDisplay(GameHook gameHook)
        {
            InitializeComponent();
            GameHook = gameHook;
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
            HashTableDisplay display = new HashTableDisplay( "StoryBase - EventObjects");
            display.LoadTable(m_StoryBase.pEventObjectHashTable.address);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reload();
            ScriptObjectDisplay display = new ScriptObjectDisplay();
            display.LoadObject(m_StoryBase.pCurrentScriptObject.obj);
            display.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DynamicValueArrayDisplay display = new DynamicValueArrayDisplay();
            display.LoadFrom(m_StoryBase.pInstructionArray.address, 0, 0);
            display.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay( "StoryBase - Scripting Arrays");
            display.LoadTable(m_StoryBase.pScriptingArrayObject_HashTable.address);
            display.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay( "StoryBase - Scripting HashTables");
            display.LoadTable(m_StoryBase.pScriptingHashTableObject_HashTable.address);
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
            display.LoadTable(m_StoryBase.pScriptingTextObject_HashTable.address);
            display.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay();
            display.LoadTable(m_StoryBase.pScriptObjectHashTable.address);
            display.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TaskObject[] ScriptObjects = m_StoryBase.GetScriptObjectsWithReferenceTo((int)numericUpDown1.Value);

            listBox1.Items.Clear();
            listBox1.Items.AddRange(ScriptObjects);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= listBox1.Items.Count)
            {
                return;
            }

            ScriptObjectDisplay display = new ScriptObjectDisplay();
            display.LoadObject((TaskObject)listBox1.Items[listBox1.SelectedIndex]);
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
    }
}
