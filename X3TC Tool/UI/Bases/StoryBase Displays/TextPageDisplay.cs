using System;
using System.Windows.Forms;

using X3TCTools;
using X3TCTools.Bases.StoryBase_Objects;
using X3TCTools.Generics;

namespace X3TC_Tool.UI
{
    public partial class TextPageDisplay : Form
    {
        private TextPage m_TextPage;

        public TextPageDisplay()
        {
            InitializeComponent();
        }

        public void LoadPage(GameHook.Language languageID, int pageID)
        {
            try
            {
                m_TextPage = GameHook.storyBase.GetTextPage(languageID, pageID);
            }
            catch (HashTableElementNotFoundException)
            {
                m_TextPage = null;
            }
            Reload();
        }

        public void Reload()
        {
            dataGridView1.Rows.Clear();
            if(m_TextPage == null)
            {
                txtAddress.Text = "Not found!";
                return;
            }
            txtAddress.Text = m_TextPage.pThis.ToString("X");

            foreach(var entry in m_TextPage.textEntries)
            {
                var text = entry.value.GetAsTextObject().pText.obj.value;
                dataGridView1.Rows.Add(entry.pThis.ToString("X"),entry.ID, text, GameHook.storyBase.GetParsedText((GameHook.Language)nudLanguageID.Value, text));
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadPage((GameHook.Language)nudLanguageID.Value, (int)nudPageID.Value);
        }
    }
}
