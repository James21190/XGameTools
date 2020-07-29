using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X3TCTools;
using Common.Memory;


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

        public void LoadPage(int languageID, int pageID)
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
            LoadPage((int)nudLanguageID.Value, (int)nudPageID.Value);
        }
    }
}
