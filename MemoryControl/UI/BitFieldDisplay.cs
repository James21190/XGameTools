using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonToolLib.UI
{
    public partial class BitFieldDisplay : UserControl
    {
        private int _Bits;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Bits
        {
            get
            {
                return _Bits;
            }
            set
            {
                _Bits = value;
                _ReloadCheckboxLables();
            }
        }


        private string[] _Lables;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string[] Lables
        {
            get
            {
                return _Lables;
            }
            set
            {
                _Lables = value;
                _ReloadCheckboxLables();
            }
        }

        private BitField _Value;
        public BitField Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                if (_Value != null)
                {
                    for (int i = 0; i < _Value.ByteSize * 8 && i < _Bits; i++)
                    {
                        checkedListBox1.SetItemChecked(i, _Value.GetBit(i));
                    }
                }
                else
                {
                    for (int i = 0; i < _Bits; i++)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void _ReloadCheckboxLables()
        {
            checkedListBox1.Items.Clear();
            for(int i = 0; i < _Bits; i++)
            {

                if(_Lables != null && _Lables.Length > i && !string.IsNullOrWhiteSpace(_Lables[i]))
                {
                    checkedListBox1.Items.Add(_Lables[i]);
                }
                else
                {
                    checkedListBox1.Items.Add("Bit " + i);
                }
            }
        }

        public BitFieldDisplay()
        {
            InitializeComponent();
        }
    }
}
