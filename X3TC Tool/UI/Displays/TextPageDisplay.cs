using System;
using System.Windows.Forms;

using X3TCTools;


namespace X3TC_Tool.UI
{
    public partial class TextPageDisplay : Form
    {
        private GameHook GameHook;

        private TextPage m_TextPage;

        public TextPageDisplay(GameHook gameHook)
        {
            GameHook = gameHook;
            InitializeComponent();
        }

        public void LoadPage(GameHook.Language languageID, int pageID)
        {
            m_TextPage = GameHook.storyBase.GetTextPage(languageID, pageID);
            Reload();
        }

        public void Reload()
        {
            txtAddress.Text = m_TextPage.pThis.ToString("X");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadPage((GameHook.Language)nudLanguageID.Value, (int)nudPageID.Value);
        }
    }
}
