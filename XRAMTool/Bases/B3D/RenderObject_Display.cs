using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.B3D;
using XRAMTool.Bases.Sector;

namespace XRAMTool.Bases.B3D
{
    public partial class RenderObject_Display : Form
    {
        public RenderObject_Display()
        {
            InitializeComponent();
        }

        private RenderObject _RenderObject;

        public void LoadObject(RenderObject obj)
        {
            _RenderObject = obj;
            Reload();
        }


        private void _AddChildren(RenderObject obj, TreeNode node)
        {
            foreach(var child in obj.GetChildren(false))
            {
                var n = node.Nodes.Add(child.ID.ToString());
                _AddChildren(child, n);
            }
        }
        public void Reload()
        {
            numericIDObjectControl1.LoadObject(_RenderObject);
            namedNumericUpDown1.Value = _RenderObject.BodyID;
            namedNumericUpDown2.Value = _RenderObject.CollectionID;

            treeView1.Nodes.Clear();

            foreach(var child in _RenderObject.GetChildren(false))
            {
                var node = treeView1.Nodes.Add(child.ID.ToString());
                _AddChildren(child, node);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            var display = new RenderObject_Display();
            display.LoadObject(Program.GameHook.B3DBase.GetRenderObject(int.Parse(treeView1.SelectedNode.Text)));
            display.Show();
        }

        private void RenderObject_Display_Load(object sender, EventArgs e)
        {

        }

        private bool _CheckRenderObjectParents(int id, RenderObject ro)
        {
            if (ro.ID == id)
                return true;
            if(ro.Parent != null)
                return _CheckRenderObjectParents(id, ro.Parent);
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sb = Program.GameHook.SectorBase;
            var soIds = sb.GetSectorObjectIDs();

            foreach(var soID in soIds)
            {
                var so = sb.GetSectorObject(soID);

                if(_CheckRenderObjectParents(so.RenderObject.ID, _RenderObject))
                {
                    var display = new SectorObject_Display();
                    display.LoadObject(so);
                    display.Show();
                    return;
                }
            }
        }
    }
}
