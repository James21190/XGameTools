using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace X4DLSSModifier
{
    public partial class Form1 : Form
    {

        private FilePatching.PatchHandler _PatchHandler;
        private FilePatching.PatternPatch _Patch;
        private bool _DLSSIndicatorAvailable;
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (_DLSSIndicatorAvailable)
            {
                int regValue = (int)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "ShowDlssIndicator", 0);
                if (checkBox1.Checked)
                {
                    regValue |= 0x400;
                }
                else
                {
                    regValue &= ~0x400;
                }
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "ShowDlssIndicator", regValue, RegistryValueKind.DWord);
            }
            var patchResult = _PatchHandler.PatchWith(_Patch, true);
            if (((int)patchResult & (int)FilePatching.PatchHandler.PatchResult.PATCH_SUCCESSFUL) != 0)
            {
                throw new Exception("Failed to apply patch!");
            }
            _PatchHandler.WriteChanges(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Patch = new FilePatching.PatternPatch(File.ReadAllLines(".\\DLSSPatch.txt"));

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "X4|X4.exe|All files|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }

            _PatchHandler = new FilePatching.PatchHandler(ofd.FileName);

            var regValue = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "ShowDlssIndicator", 0);
            checkBox1.Checked = regValue != null ? (int)regValue == 0x400 : false;

            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            _DLSSIndicatorAvailable = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) &&
                ((int)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "Installed", 0) == 1);

            checkBox1.Enabled = _DLSSIndicatorAvailable;
            cmbDlssPreset.SelectedIndex =
                comboBox1.SelectedIndex =
                comboBox2.SelectedIndex = 3;
            SetForegroundWindow(this.Handle);
        }

        private void cmbDlssPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbDlssPreset.SelectedItem)
            {
                case "Default":
                    nudDlssPresetValue.Value = 0;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "A":
                    nudDlssPresetValue.Value = 1;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "B":
                    nudDlssPresetValue.Value = 2;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "C":
                    nudDlssPresetValue.Value = 3;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "D":
                    nudDlssPresetValue.Value = 4;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "E":
                    nudDlssPresetValue.Value = 5;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "F":
                    nudDlssPresetValue.Value = 6;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "J":
                    nudDlssPresetValue.Value = 10;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "K":
                    nudDlssPresetValue.Value = 11;
                    nudDlssPresetValue.Enabled = false;
                    break;
                case "Custom":
                    nudDlssPresetValue.Enabled = true;
                    break;
            }
        }

        private void nudDlssPresetValue_ValueChanged(object sender, EventArgs e)
        {
            _Patch.SetParameter("DLSSQualityPreset", (byte)nudDlssPresetValue.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _Patch.SetParameter("DLSSBalancedPreset", (byte)numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            _Patch.SetParameter("DLSSPerformancePreset", (byte)numericUpDown2.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Default":
                    numericUpDown1.Value = 0;
                    numericUpDown1.Enabled = false;
                    break;
                case "A":
                    numericUpDown1.Value = 1;
                    numericUpDown1.Enabled = false;
                    break;
                case "B":
                    numericUpDown1.Value = 2;
                    numericUpDown1.Enabled = false;
                    break;
                case "C":
                    numericUpDown1.Value = 3;
                    numericUpDown1.Enabled = false;
                    break;
                case "D":
                    numericUpDown1.Value = 4;
                    numericUpDown1.Enabled = false;
                    break;
                case "E":
                    numericUpDown1.Value = 5;
                    numericUpDown1.Enabled = false;
                    break;
                case "F":
                    numericUpDown1.Value = 6;
                    numericUpDown1.Enabled = false;
                    break;
                case "J":
                    numericUpDown1.Value = 10;
                    numericUpDown1.Enabled = false;
                    break;
                case "K":
                    numericUpDown1.Value = 11;
                    numericUpDown1.Enabled = false;
                    break;
                case "Custom":
                    numericUpDown1.Enabled = true;
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem)
            {
                case "Default":
                    numericUpDown2.Value = 0;
                    numericUpDown2.Enabled = false;
                    break;
                case "A":
                    numericUpDown2.Value = 1;
                    numericUpDown2.Enabled = false;
                    break;
                case "B":
                    numericUpDown2.Value = 2;
                    numericUpDown2.Enabled = false;
                    break;
                case "C":
                    numericUpDown2.Value = 3;
                    numericUpDown2.Enabled = false;
                    break;
                case "D":
                    numericUpDown2.Value = 4;
                    numericUpDown2.Enabled = false;
                    break;
                case "E":
                    numericUpDown2.Value = 5;
                    numericUpDown2.Enabled = false;
                    break;
                case "F":
                    numericUpDown2.Value = 6;
                    numericUpDown2.Enabled = false;
                    break;
                case "J":
                    numericUpDown2.Value = 10;
                    numericUpDown2.Enabled = false;
                    break;
                case "K":
                    numericUpDown2.Value = 11;
                    numericUpDown2.Enabled = false;
                    break;
                case "Custom":
                    numericUpDown2.Enabled = true;
                    break;
            }
        }
    }
}
