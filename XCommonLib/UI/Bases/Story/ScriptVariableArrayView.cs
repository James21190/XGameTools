using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XCommonLib.UI.Bases.Story
{
    public partial class ScriptVariableArrayView : UserControl
    {

        private DynamicValue[] _dynamicValues;

        public DynamicValue[] DynamicValues
        {
            get { return _dynamicValues; }
            set {
                if(_dynamicValues != null && _dynamicValues.Length == value.Length)
                {
                    _dynamicValues = value;
                    SoftReload();
                }
                else
                {
                    _dynamicValues = value;
                    Reload();
                }
            }
        }
        public ScriptInstanceType.VariableData[] Variables;

        public ScriptVariableArrayView()
        {
            InitializeComponent();
        }

        private string _GetVariableName(int index)
        {
            if(Variables != null && Variables.Length > index)
            {
                if(!String.IsNullOrWhiteSpace(Variables[index].Name))
                    return Variables[index].Name;
            }
            return "Var " + index;
        }

        private string _GetButtonText(int index)
        {
            if (Variables != null && Variables.Length > index)
            {
                switch (Variables[index].Type)
                {
                    case ScriptInstanceType.VariableType.ScriptInstanceID:
                        return "View ScriptInstance";
                    case ScriptInstanceType.VariableType.SectorObjectID:
                        return "View SectorObject";
                    case ScriptInstanceType.VariableType.Array:
                        return "View Array";
                    case ScriptInstanceType.VariableType.Table:
                        return "View Hash Table";
                    case ScriptInstanceType.VariableType.Object:
                        return "View as " + Variables[index].Additional.ToString();
                }
            }
            return null;
        }

        private void SoftReload()
        {
            if (DynamicValues != null)
                for (int i = 0; i < DynamicValues.Length; i++)
                {
                    var variable = DynamicValues[i];
                    dgvMemoryTable.Rows[i].SetValues(_GetVariableName(i), variable.Flag, variable.Value, variable.Value.ToString("X"), _GetButtonText(i));
                }
        }

        public void Reload()
        {
            dgvMemoryTable.Rows.Clear();

            if(DynamicValues != null)
                for (int i = 0; i < DynamicValues.Length; i++)
                {
                    var variable = DynamicValues[i];
                    dgvMemoryTable.Rows.Add(_GetVariableName(i), variable.Flag, variable.Value, variable.Value.ToString("X"), _GetButtonText(i));
                }
        }

        public delegate void RequestViewHandler(object sender, ScriptInstanceType.VariableType type, int variableValue, object additional);

        public event RequestViewHandler RequestView;

        private void dgvMemoryTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (Variables == null || e.RowIndex < 0 || Variables.Length < e.RowIndex)
                return;

            DataGridViewRow row = dgvMemoryTable.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvMemoryTable.Columns["colView"].Index && e.RowIndex >= 0)
            {
                if(Variables[e.RowIndex].Type != ScriptInstanceType.VariableType.None)
                {
                    if (RequestView != null)
                        RequestView(this, Variables[e.RowIndex].Type, DynamicValues[e.RowIndex].Value, Variables[e.RowIndex].Additional);
                }
            }
        }
    }
}
