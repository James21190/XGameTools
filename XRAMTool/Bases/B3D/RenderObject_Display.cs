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

        public void Reload()
        {
            numericIDObjectControl1.LoadObject(_RenderObject);
        }
    }
}
