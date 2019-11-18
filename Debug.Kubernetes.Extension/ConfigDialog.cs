namespace Debug.Kubernetes.Extension
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Debug.Kubernetes.Extension.Kubernetes;

    public partial class ConfigDialog : Form
    {
        private KubeCtl kubectl;

        public string SelectedContext => lbContexts.Text;

        public string SelectedNamespace
        {
            get
            {
                return lbNamespaces.Text;
            }
        }

        public string AppName
        {
            get
            {
                return cbAppName.Text;
            }
        }

        public string SelectedPodName
        {
            get
            {
                return lbPods.Text;
            }
        }

        public bool UseCustomScript => (Pages.SelectedTab == tabCustomScript);

        public string CustomScriptContent => txScript.Text;

        public string DefaultScriptFileName { get; set; }

        public string CustomScriptFileName { get; private set; }

        public bool CustomScriptChanged
        {
            get => laCustomScriptFile.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText;
            set => laCustomScriptFile.DisplayStyle = value ? ToolStripItemDisplayStyle.ImageAndText : ToolStripItemDisplayStyle.Text;
        }

        /// <summary>
        /// Creates a new Config Dialog
        /// </summary>
        public ConfigDialog()
        {
            InitializeComponent();
            Pages.SelectedTab = tabDefault;
            txScript.Text = "";
            CustomScriptChanged = false;

            kubectl = new KubeCtl();
        }

        public void SetAppNames(IEnumerable<string> items)
        {
            cbAppName.Items.Clear();
            if (items?.Any() ?? false)
            {
                cbAppName.Items.AddRange(items.ToArray());
                cbAppName.SelectedIndex = 0;
            }
        }

        public void SetProgress(string text)
        {
            Cursor.Current = Cursors.WaitCursor;
            sbProgress.Style = ProgressBarStyle.Marquee;
            sbStatus.Text = text;
            Application.DoEvents();
        }

        public void ResetProgress()
        {
            Cursor.Current = Cursors.Default;
            sbStatus.Text = "Ready.";
            sbProgress.Style = ProgressBarStyle.Blocks;
        }

        private void ConfigDialog_Shown(object sender, EventArgs e)
        {
            SetProgress("Initializing...");

            LoadCustomScriptFile(null);

            // Get all contexts configured in the system
            var contexts = kubectl.ListContexts();
            lbContexts.Items.AddRange(contexts.ToArray());

            if (lbContexts.Items.Count == 0)
            {
                ResetProgress();
                throw new Exception("No contexts configured in the system.");
            }

            lbContexts.SelectedItem = kubectl.GetContext();
            RefreshPods();
            ResetProgress();
        }

        private void LoadCustomScriptFile(string filename)
        {
            CustomScriptFileName = filename;

            if (CustomScriptFileName != null && File.Exists(CustomScriptFileName))
            {
                txScript.Text = File.ReadAllText(CustomScriptFileName);
                laCustomScriptFile.Text = Path.GetFileName(CustomScriptFileName);
            }
            else
            {
                ClearCustomScript();
            }

            CustomScriptChanged = false;
        }

        private void ClearCustomScript()
        {
            CustomScriptFileName = null;

            if (DefaultScriptFileName != null && File.Exists(DefaultScriptFileName))
            {
                txScript.Text = File.ReadAllText(DefaultScriptFileName);
                laCustomScriptFile.Text = "(default)";
            }
            else
            {
                txScript.Text = "";
                laCustomScriptFile.Text = "(none)";
            }

            CustomScriptChanged = false;
        }

        private void ReloadCustomScript()
        {
            LoadCustomScriptFile(CustomScriptFileName);
        }

        private void CheckBtnState()
        {
            btDebug.Enabled = (Pages.SelectedTab != tabHelp) &&
                (
                    (Pages.SelectedTab == tabCustomScript && !string.IsNullOrWhiteSpace(txScript.Text)) ||
                    (Pages.SelectedTab == tabDefault && !string.IsNullOrWhiteSpace(SelectedPodName))
                );
        }

        private void RefreshPods()
        {
            lbPods.Items.Clear();
            if (!string.IsNullOrEmpty(AppName))
            {
                SetProgress("Searching for Pods...");
                var pods = kubectl.ListPods(AppName);
                if (pods?.Any() ?? false)
                {
                    lbPods.Items.AddRange(pods.ToArray());
                    lbPods.SelectedIndex = 0;
                }
                ResetProgress();
            }
        }

        private void lbContexts_SelectedIndexChanged(object sender, EventArgs e)
        {
            kubectl.SetContext(SelectedContext);

            lbNamespaces.Items.Clear();
            txClusterInfo.Text = "";
            var cluster = kubectl.GetCluster(SelectedContext);
            var server = kubectl.GetServer(cluster);
            txClusterInfo.Text = $"{server} ({cluster})";

            lbNamespaces.Items.Add("");
            var ns = kubectl.ListNamespaces();
            lbNamespaces.Items.AddRange(ns.ToArray());
        }

        private void lbNamespaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ns = lbNamespaces.Text;
            kubectl.DefaultNamespace = ns;
            RefreshPods();
        }

        private void laCustomScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ODlgScript.ShowDialog() == DialogResult.OK)
            {
                txScript.Text = File.ReadAllText(ODlgScript.FileName);
                Pages.SelectedTab = tabCustomScript;
                txScript.Focus();
                CheckBtnState();
            }
        }

        private void Pages_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBtnState();
        }

        private void btDebug_Click(object sender, EventArgs e)
        {
            Pages.Enabled = false;
        }

        private void cbAppName_Validated(object sender, EventArgs e)
        {
            RefreshPods();
        }

        private void cbAppName_TextChanged(object sender, EventArgs e)
        {
            lbPods.Items.Clear();
        }

        private void lbNamespaces_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RefreshPods();
        }

        private void btCustomScriptOpen_Click(object sender, EventArgs e)
        {
            if (CustomScriptChanged && MessageBox.Show("Script has unsaved changes. Continue anyway?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (ODlgScript.ShowDialog(this) == DialogResult.OK)
            {
                LoadCustomScriptFile(ODlgScript.FileName);
            }
        }

        private void btCustomScriptReload_Click(object sender, EventArgs e)
        {
            if (CustomScriptChanged && MessageBox.Show("Are you sure you want to reload the file and lose the changes?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            LoadCustomScriptFile(CustomScriptFileName);
        }

        private void btCustomScriptClear_Click(object sender, EventArgs e)
        {
            if (CustomScriptChanged && MessageBox.Show("Script has unsaved changes. Continue anyway?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            ClearCustomScript();
        }

        private void txScript_TextChanged(object sender, EventArgs e)
        {
            CustomScriptChanged = true;
        }

        private void btCustomScriptSave_Click(object sender, EventArgs e)
        {
            if (!CustomScriptChanged)
            {
                return;
            }

            if (string.IsNullOrEmpty(CustomScriptFileName))
            {
                if (SDlgScript.ShowDialog(this) == DialogResult.OK)
                {
                    CustomScriptFileName = SDlgScript.FileName;
                }
                else
                {
                    return;
                }
            }

            SetProgress($"Saving: {CustomScriptFileName}");
            File.WriteAllText(CustomScriptFileName, txScript.Text);
            CustomScriptChanged = false;
            ResetProgress();
        }
    }
}
