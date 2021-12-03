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
using XCommonLib.Files;

namespace XCatTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ExternalDataCollection _Data;

        private void Form1_Load(object sender, EventArgs e)
        {
            _Data = new ExternalDataCollection("./01.cat","./02.cat");
            ReloadTree();
        }

        public void PopulateTreeNode(ref TreeNode node, string basePath)
        {
            foreach(var dir in _Data.GetDirectories(basePath))
            {
                var name = Path.GetFileName(dir);
                var dirNode = new TreeNode(name);
                PopulateTreeNode(ref dirNode, dir);
                node.Nodes.Add(dirNode);
            }
            foreach(var file in _Data.GetFiles(basePath))
            {
                var name = Path.GetFileName(file);
                var fileNode = new TreeNode(name);
                fileNode.Tag = _Data.GetRecord(file);
                node.Nodes.Add(fileNode);
            }
        }
        private void ReloadTree()
        {
            treeView1.Nodes.Clear();
            foreach (var dir in _Data.GetDirectories(null))
            {
                var name = Path.GetFileName(dir);
                var dirNode = new TreeNode(name);
                PopulateTreeNode(ref dirNode, dir);
                treeView1.Nodes.Add(dirNode);
            }
            foreach (var file in _Data.GetFiles(null))
            {
                var name = Path.GetFileName(file);
                var fileNode = new TreeNode(name);
                fileNode.Tag = _Data.GetRecord(file);
                treeView1.Nodes.Add(fileNode);
            }
        }

        ExternalDataCollection.FileRecord _LoadedFile;

        private void ReloadHexView()
        {
            var data = _Data.GetFile(_LoadedFile);
            StringBuilder sb = new StringBuilder();
            sb.Append(0.ToString("X8") + " | ");
            for(int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("X2") + ((i+1)%16 == 0 ? "\n"+(i + 1).ToString("X8")+ " | " : " "));
            }
            rtxtHex.Text = sb.ToString();
        }

        private void ReloadTextView()
        {
            rtxtText.Text = Encoding.Default.GetString(_Data.GetFile(_LoadedFile));
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Tag == null)
                return;
            var record = (ExternalDataCollection.FileRecord)treeView1.SelectedNode.Tag;
            _LoadedFile = record;
            ReloadHexView();
            ReloadTextView();
        }
    }
}
