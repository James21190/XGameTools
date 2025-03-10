using FilePatching;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace X4DLSSModifier
{
    public partial class MainForm : Form
    {

        private PatchHandler _PatchHandler;
        private PatternPatch _Patch;
        private bool _DLSSIndicatorAvailable;
        private string _WorkingDirectory => Path.GetDirectoryName(_PatchHandler.FilePath);

        public MainForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_DLSSIndicatorAvailable)
                {
                    int regValue = (int)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "ShowDlssIndicator", 0);
                    int newRegValue;
                    if (chkDlssIndicator.Checked)
                    {
                        newRegValue = regValue | 0x400;
                    }
                    else
                    {
                        newRegValue = regValue & ~0x400;
                    }
                    if (newRegValue != regValue)
                        Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "ShowDlssIndicator", newRegValue, RegistryValueKind.DWord);
                }
                var patchResult = _PatchHandler.PatchWith(_Patch, true);
                if (((int)patchResult != (int)PatchResult.PATCH_SUCCESSFUL))
                {
                    string errorCode = ((PatternPatch.PatchErrors)((int)patchResult)).ToString();
                    throw new Exception("Failed to apply patch. Error Code: " + errorCode);
                }
                _PatchHandler.WriteChanges(false);

                SetDLL();

                MessageBox.Show("Patch was applied.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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

            _PatchHandler = new PatchHandler(ofd.FileName);

            var regValue = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "ShowDlssIndicator", 0);
            chkDlssIndicator.Checked = regValue != null ? (int)regValue == 0x400 : false;

            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            _DLSSIndicatorAvailable = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) &&
                ((int)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\Global\\NGXCore", "Installed", 0) == 1);

            chkDlssIndicator.Enabled = _DLSSIndicatorAvailable;
            cmbDLSSAllPreset.SelectedIndex = 3;

            ReloadDLLInfo();

            // Set to foreground because without it the window is shy and hides behind everything.
            SetForegroundWindow(this.Handle);
        }

        #region DLSS Presets
        private static int _GetDLSSPresetValue(string value)
        {
            switch (value)
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

        private bool _SetAllPreset = true;
        private void cmbDLSSAllPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDLSSAllPreset.SelectedIndex != -1)
            {
                _SetAllPreset = false;
                cmbDlssQualityPreset.SelectedIndex =
                    cmbDlssBalancedPreset.SelectedIndex =
                    cmbDlssPerformancePreset.SelectedIndex = cmbDLSSAllPreset.SelectedIndex;
                _SetAllPreset = true;
            }
        }

        #region Quality
        private void cmbDlssQualityPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SetAllPreset)
            {
                cmbDLSSAllPreset.SelectedIndex = -1;
            }
            if (cmbDlssQualityPreset.SelectedItem == "Custom")
            {
                nudDlssQualityPresetValue.Enabled = true;
            }
            else
            {
                nudDlssQualityPresetValue.Value = _GetDLSSPresetValue(cmbDlssQualityPreset.SelectedItem.ToString());
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
            if (_SetAllPreset)
            {
                cmbDLSSAllPreset.SelectedIndex = -1;
            }
            if (cmbDlssBalancedPreset.SelectedItem == "Custom")
            {
                nudDlssBalancedPresetValue.Enabled = true;
            }
            else
            {
                nudDlssBalancedPresetValue.Value = _GetDLSSPresetValue(cmbDlssBalancedPreset.SelectedItem.ToString());
                nudDlssBalancedPresetValue.Enabled = false;
            }
        }
        private void nudDlssBalancedPresetValue_ValueChanged(object sender, EventArgs e)
        {
            _Patch.SetParameter("DLSSBalancedPreset", (byte)nudDlssBalancedPresetValue.Value);
        }
        #endregion
        #region Performance
        private void cmbDlssPerformancePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SetAllPreset)
            {
                cmbDLSSAllPreset.SelectedIndex = -1;
            }
            if (cmbDlssPerformancePreset.SelectedItem == "Custom")
            {
                nudDlssPerformancePresetValue.Enabled = true;
            }
            else
            {
                nudDlssPerformancePresetValue.Value = _GetDLSSPresetValue(cmbDlssPerformancePreset.SelectedItem.ToString());
                nudDlssPerformancePresetValue.Enabled = false;
            }
        }
        private void nudDlssPerformancePresetValue_ValueChanged(object sender, EventArgs e)
        {
            _Patch.SetParameter("DLSSPerformancePreset", (byte)nudDlssPerformancePresetValue.Value);
        }
        #endregion
        #endregion

        #region DLSS DLL
        private class DLSSDLLInfo : IComparable, IEquatable<DLSSDLLInfo>
        {
            public int Major;
            public int Minor;
            public int Build;
            public int Private;

            public string FilePath;
            public DLSSDLLInfo(FileVersionInfo fvi, string filePath)
            {
                Major = fvi.ProductMajorPart;
                Minor = fvi.ProductMinorPart;
                Build = fvi.ProductBuildPart;
                Private = fvi.ProductPrivatePart;
                FilePath = filePath;
            }

            public int CompareTo(object? obj)
            {
                var other = (DLSSDLLInfo)(obj);

                if (Major != other.Major)
                {
                    return Major.CompareTo(other.Major);
                }
                else if (Minor != other.Minor)
                {
                    return Minor.CompareTo(other.Minor);
                }
                else if (Build != other.Build)
                {
                    return Build.CompareTo(other.Build);
                }
                else if (Private != other.Private)
                {
                    return Private.CompareTo(other.Private);
                }
                else
                {
                    return 0;
                }
            }

            public bool Equals(DLSSDLLInfo? other)
            {
                return Major == other.Major && Minor == other.Minor && Build == other.Build && Private == other.Private;
            }

            public override string ToString()
            {
                return string.Join(".", Major, Minor, Build, Private);
            }
        }
        private void ReloadDLLInfo()
        {
            cmbDlssDll.Items.Clear();
            List<DLSSDLLInfo> dlssVersions = new List<DLSSDLLInfo>();
            var currentDllPath = Path.Combine(_WorkingDirectory, "nvngx_dlss.dll");
            var nvidiaVersionDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "NVIDIA\\NGX\\models\\dlss\\versions");
            var files = Directory.GetFiles(nvidiaVersionDirectory, "*.bin", SearchOption.AllDirectories);


            foreach (var file in files)
            {
                var nvidiaBinVersion = new DLSSDLLInfo(FileVersionInfo.GetVersionInfo(file), file);
                if (!dlssVersions.Contains(nvidiaBinVersion))
                {
                    dlssVersions.Add(nvidiaBinVersion);
                }
            }


            if (File.Exists(currentDllPath))
            {
                var currentVersion = new DLSSDLLInfo(FileVersionInfo.GetVersionInfo(currentDllPath), null);
                if (dlssVersions.Contains(currentVersion))
                {
                    dlssVersions.Remove(currentVersion);
                }
                dlssVersions.Add(currentVersion);
                
                dlssVersions.Sort();
                dlssVersions.Reverse();
                cmbDlssDll.Items.AddRange(dlssVersions.ToArray());
                cmbDlssDll.SelectedItem = currentVersion;
            }
            else
            {
                dlssVersions.Sort();
                dlssVersions.Reverse();
                cmbDlssDll.Items.AddRange(dlssVersions.ToArray());
                cmbDlssDll.SelectedIndex = -1;
            }
        }

        private void SetDLL()
        {
            var selectedDLL = (DLSSDLLInfo)cmbDlssDll.SelectedItem;

            if (selectedDLL.FilePath != null)
            {
                File.Copy(selectedDLL.FilePath, Path.Combine(_WorkingDirectory, "nvngx_dlss.dll"), true);

                ReloadDLLInfo();
            }
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string DLSS_INDICATOR_INFO_LINK = "https://www.pcgamer.com/nvidia-dlss-indicator/";
            Process.Start(new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = DLSS_INDICATOR_INFO_LINK
            });
        }
    }
}
