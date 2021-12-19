using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.Files.CatDat;
using X2Lib.Files.CatDat;

namespace XCatTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CatDatReader<X2CatFile, X2DatFile, X2PckFile> _Reader = new CatDatReader<X2CatFile,X2DatFile, X2PckFile>();
        //CATDATBuilder _Builder = new CATDATBuilder();

        List<string> _ExternalFiles = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadTree();
        }

        private string GetLastPathPart(string path)
        {
            var split = path.Split('/');
            return split[split.Length - 1];
        }

        private void _SetLoadedFile(CatDatFile file)
        {
            _LoadedFile = file;
            switch (file.Extension)
            {
                case ".pck":
                    var pckFile = _Reader.GetPckFile(file.InternalPath);
                    _LoadedFileData = pckFile.Decompress();
                    break;
                default:
                    _LoadedFileData = _LoadedFile.Data;
                    break;
            }
        }
        private CatDatFile _LoadedFile;
        private byte[] _LoadedFileData;

        private void ReloadHexView()
        {
            var sb = new StringBuilder();
            sb.Append(0.ToString("X8") + ": ");
            for(int i = 0; i < _LoadedFileData.Length; i++)
            {
                sb.Append(" " + _LoadedFileData[i].ToString("X2"));
                if((i+1) % 16 == 0)
                {
                    sb.Append("\n" + i.ToString("X8") + ": ");
                }
                else if((i+1) % 4 == 0)
                {
                    sb.Append("  | ");
                }
            }
            rtxtHex.Text = sb.ToString();
        }

        private void ReloadTextView()
        {
            rtxtText.Text = Encoding.Default.GetString(_LoadedFileData);
        }

        private void ReloadImage()
        {
            try
            {
                using(var ms = new MemoryStream(_LoadedFileData))
                    picImage.Image = new Bitmap(ms);
            }
            catch(Exception ex)
            {
                picImage.Image = null;
            }
        }


        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode == null || treeView1.SelectedNode.Tag == null)
                return;
            string path = (string)treeView1.SelectedNode.Tag;
            try
            {
                _SetLoadedFile(_Reader.GetFile(path));
            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show(string.Format("Dat file not found: " + fnfe.FileName));
            }
            ReloadViews();
        }

        private void loadCatFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ofdGetCats.ShowDialog() == DialogResult.OK)
            {
                var files = ofdGetCats.FileNames;
                foreach(var file in files)
                {
                    _Reader.AppendCatDat(file);
                }
                ReloadTree();
            }
            
        }

        private void exportToDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = new FolderBrowserDialog();
            if (d.ShowDialog() == DialogResult.OK)
                _Reader.ExportToDirectory(d.SelectedPath, true);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _Reader.Clear();
            _ExternalFiles.Clear();
            //_Builder.Clear();
            ReloadTree();
            ReloadExternalFileList();
        }

        private void ReloadViews()
        {
            ReloadHexView();
            ReloadTextView();
            ReloadImage();
        }

        #region Reload Tree

        public void PopulateTreeNode(ref TreeNode node, string basePath)
        {
            foreach (var dir in _Reader.GetDirectories(basePath))
            {
                var dirNode = new TreeNode(GetLastPathPart(dir));
                PopulateTreeNode(ref dirNode, dir);
                node.Nodes.Add(dirNode);
            }
            foreach (var file in _Reader.GetFiles(basePath))
            {
                var fileNode = new TreeNode(GetLastPathPart(file));
                fileNode.Tag = file;
                node.Nodes.Add(fileNode);
            }
        }
        private void ReloadTree()
        {
            bgdReloadTree.RunWorkerAsync();   
        }
        private void bgdReloadTree_DoWork(object sender, DoWorkEventArgs e)
        {
            treeView1.Invoke(new Action(() =>
            {
                treeView1.Nodes.Clear();
            }));
            foreach (var dir in _Reader.GetDirectories(null))
            {
                var dirNode = new TreeNode(GetLastPathPart(dir));
                PopulateTreeNode(ref dirNode, dir);
                treeView1.Invoke(new Action(() =>
                {
                    treeView1.Nodes.Add(dirNode);
                }));
            }
            foreach (var file in _Reader.GetFiles(null))
            {
                var fileNode = new TreeNode(GetLastPathPart(file));
                fileNode.Tag = file;
                treeView1.Invoke(new Action(() =>
                {
                    treeView1.Nodes.Add(fileNode);
                }));
            }
        }
        #endregion

        private void ReloadExternalFileList()
        {
            listBox1.Items.Clear();
            foreach (var file in _ExternalFiles)
                listBox1.Items.Add(file);
        }
        private void exportReadableCatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = new FolderBrowserDialog();
            if (d.ShowDialog() == DialogResult.OK)
                _Reader.ExportCatsToDirectory(d.SelectedPath, true);
        }

        private void externalFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdGetPcks.ShowDialog() == DialogResult.OK)
            {
                var files = ofdGetPcks.FileNames;
                foreach (var file in files)
                {
                    _ExternalFiles.Add(file);
                }
                ReloadExternalFileList();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == null)
                return;
            var path = listBox1.SelectedItem.ToString();
            switch (Path.GetExtension(path))
            {
                case ".pck":
                    var pckFile = new X2PckFile();
                    pckFile.SetData(File.ReadAllBytes(path));
                    _LoadedFileData = pckFile.Decompress();
                    break;
                default:
                    _LoadedFileData = File.ReadAllBytes(path);
                    break;
            }
            ReloadViews();
        }

        private void exportAsCatDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var builder = _Reader.ToBuilder();
            builder.ExportToCatDat(".", "test");

        }
    }
}
