using FilePatching;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace X4DLSSModifier
{
    public partial class MainForm : Form
    {

        private PatchHandler _PatchHandler;
        private PatternPatch _Patch;
        private bool _DLSSIndicatorAvailable;
        public MainForm()
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
                if (chkDlssIndicator.Checked)
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
            if (((int)patchResult != (int)PatchResult.PATCH_SUCCESSFUL))
            {
                string errorCode = ((PatternPatch.PatchErrors)((int)patchResult)).ToString();
                throw new Exception("Failed to apply patch. Error Code: " + errorCode);
            }
            _PatchHandler.WriteChanges(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _Patch = new PatternPatch(File.ReadAllLines(".\\DLSSPatch.txt"));

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "X4|X4.exe|All files|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }

            _PatchHandler = new FilePatching.PatchHandler(ofd.FileName);

            var regValue = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "ShowDlssIndicator", 0);
            chkDlssIndicator.Checked = regValue != null ? (int)regValue == 0x400 : false;

            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            _DLSSIndicatorAvailable = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) &&
                ((int)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "Installed", 0) == 1);

            chkDlssIndicator.Enabled = _DLSSIndicatorAvailable;
            cmbDlssQualityPreset.SelectedIndex =
                cmbDlssBalancedPreset.SelectedIndex =
                cmbDlssPerformancePreset.SelectedIndex = 3;

            // Set to foreground because without it the window is shy and hides behind everything.
            SetForegroundWindow(this.Handle);
        }

        private static int _GetDLSSValue(string value)
        {
            case "Default":
                return 0;
            case "A":
                return 1;
            case "B":
                return 2;
            case "C":
                return 3;
            case "D":
                return 4;
            case "E":
                return 5;
            case "F":
                return 6;
            case "J":
                return 10;
            case "K":
                return 11;
            }
            throw new ArgumentException();
        }

        #region Quality
        private void cmbDlssQualityPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDlssQualityPreset.SelectedItem == "Custom")
            {
                nudDlssQualityPresetValue.Enabled = true;
            }
            else
            {
                nudDlssQualityPresetValue.Value = _GetDLSSValue(cmbDlssQualityPreset.SelectedItem.ToString());
                nudDlssQualityPresetValue.Enabled = false;
            }
        }
        private void nudDlssQualityPresetValue_ValueChanged(object sender, EventArgs e)
        {
            _Patch.SetParameter("DLSSQualityPreset", (byte)nudDlssQualityPresetValue.Value);
        }
        #endregion
        #region Balanced
        private void cmbDlssBalancedPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDlssBalancedPreset.SelectedItem == "Custom")
            {
                nudDlssBalancedPresetValue.Enabled = true;
            }
            else
            {
                nudDlssBalancedPresetValue.Value = _GetDLSSValue(cmbDlssBalancedPreset.SelectedItem.ToString());
                nudDlssBalancedPresetValue.Enabled = false;
            }
        }
        private void nudDlssBalancedPresetValue_ValueChanged(object sender, EventArgs e)
        {
            _Patch.SetParameter("DLSSBalancedPreset", (byte)nudDlssBalancedPresetValue.Value);
        }
        #endregion
        #region Performance
        private void nudDlssPerformancePresetValue_ValueChanged(object sender, EventArgs e)
        {
            _Patch.SetParameter("DLSSPerformancePreset", (byte)nudDlssPerformancePresetValue.Value);
        }
        private void cmbDlssPerformancePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDlssPerformancePreset.SelectedItem == "Custom")
            {
                nudDlssPerformancePresetValue.Enabled = true;
            }
            else
            {
                nudDlssPerformancePresetValue.Value = _GetDLSSValue(cmbDlssPerformancePreset.SelectedItem.ToString());
                nudDlssPerformancePresetValue.Enabled = false;
            }
        }
        #endregion
    }
}
