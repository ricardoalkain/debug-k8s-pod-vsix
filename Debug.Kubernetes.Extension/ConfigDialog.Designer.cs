namespace Debug.Kubernetes.Extension
{
    partial class ConfigDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ssProgress = new System.Windows.Forms.StatusStrip();
            this.sbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.sbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ODlgScript = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txClusterInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbContexts = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btDebug = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.Pages = new System.Windows.Forms.TabControl();
            this.tabDefault = new System.Windows.Forms.TabPage();
            this.lbPods = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbNamespaces = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAppName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabCustomScript = new System.Windows.Forms.TabPage();
            this.txScript = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btCustomScriptOpen = new System.Windows.Forms.ToolStripButton();
            this.btCustomScriptSave = new System.Windows.Forms.ToolStripButton();
            this.btCustomScriptReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btCustomScriptClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.laCustomScriptFile = new System.Windows.Forms.ToolStripLabel();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SDlgScript = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ssProgress.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Pages.SuspendLayout();
            this.tabDefault.SuspendLayout();
            this.tabCustomScript.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssProgress
            // 
            this.ssProgress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbProgress,
            this.sbStatus});
            this.ssProgress.Location = new System.Drawing.Point(0, 469);
            this.ssProgress.Name = "ssProgress";
            this.ssProgress.Size = new System.Drawing.Size(434, 22);
            this.ssProgress.TabIndex = 17;
            this.ssProgress.Text = "statusStrip1";
            // 
            // sbProgress
            // 
            this.sbProgress.MarqueeAnimationSpeed = 10;
            this.sbProgress.Name = "sbProgress";
            this.sbProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // sbStatus
            // 
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(34, 17);
            this.sbStatus.Text = "         ";
            // 
            // ODlgScript
            // 
            this.ODlgScript.AddExtension = false;
            this.ODlgScript.Filter = "PowerShell script|*.ps1|Batch Files|*.bat;*.cmd|All Files|*.*";
            this.ODlgScript.Title = "Select Custom Debug Script";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(434, 128);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txClusterInfo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbContexts);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(418, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Kubernetes Config";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Cluster:";
            // 
            // txClusterInfo
            // 
            this.txClusterInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txClusterInfo.Location = new System.Drawing.Point(81, 85);
            this.txClusterInfo.Name = "txClusterInfo";
            this.txClusterInfo.ReadOnly = true;
            this.txClusterInfo.Size = new System.Drawing.Size(326, 20);
            this.txClusterInfo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Context:";
            // 
            // lbContexts
            // 
            this.lbContexts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContexts.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbContexts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lbContexts.Location = new System.Drawing.Point(81, 58);
            this.lbContexts.Name = "lbContexts";
            this.lbContexts.Size = new System.Drawing.Size(326, 21);
            this.lbContexts.TabIndex = 0;
            this.lbContexts.SelectedIndexChanged += new System.EventHandler(this.lbContexts_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(8, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(402, 34);
            this.label7.TabIndex = 32;
            this.label7.Text = "WARNING: These settings affefct Kubernetes configuration globally in the system a" +
    "nd not only in this debugging session.";
            // 
            // btDebug
            // 
            this.btDebug.AutoSize = true;
            this.btDebug.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btDebug.Dock = System.Windows.Forms.DockStyle.Right;
            this.btDebug.Location = new System.Drawing.Point(272, 4);
            this.btDebug.Name = "btDebug";
            this.btDebug.Size = new System.Drawing.Size(75, 23);
            this.btDebug.TabIndex = 1;
            this.btDebug.Text = "Debug";
            this.btDebug.UseVisualStyleBackColor = true;
            this.btDebug.Click += new System.EventHandler(this.btDebug_Click);
            // 
            // btCancel
            // 
            this.btCancel.AutoSize = true;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCancel.Location = new System.Drawing.Point(347, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // Pages
            // 
            this.Pages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Pages.Controls.Add(this.tabDefault);
            this.Pages.Controls.Add(this.tabCustomScript);
            this.Pages.Controls.Add(this.tabHelp);
            this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pages.Location = new System.Drawing.Point(0, 128);
            this.Pages.Multiline = true;
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.Size = new System.Drawing.Size(434, 310);
            this.Pages.TabIndex = 1;
            this.Pages.SelectedIndexChanged += new System.EventHandler(this.Pages_SelectedIndexChanged);
            // 
            // tabDefault
            // 
            this.tabDefault.AutoScroll = true;
            this.tabDefault.Controls.Add(this.lbPods);
            this.tabDefault.Controls.Add(this.label4);
            this.tabDefault.Controls.Add(this.label6);
            this.tabDefault.Controls.Add(this.lbNamespaces);
            this.tabDefault.Controls.Add(this.label10);
            this.tabDefault.Controls.Add(this.label8);
            this.tabDefault.Controls.Add(this.cbAppName);
            this.tabDefault.Controls.Add(this.label5);
            this.tabDefault.Controls.Add(this.label3);
            this.tabDefault.Location = new System.Drawing.Point(4, 25);
            this.tabDefault.Name = "tabDefault";
            this.tabDefault.Padding = new System.Windows.Forms.Padding(8);
            this.tabDefault.Size = new System.Drawing.Size(426, 281);
            this.tabDefault.TabIndex = 0;
            this.tabDefault.Text = "Debug Configuration";
            this.tabDefault.UseVisualStyleBackColor = true;
            // 
            // lbPods
            // 
            this.lbPods.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lbPods.FormattingEnabled = true;
            this.lbPods.Location = new System.Drawing.Point(8, 247);
            this.lbPods.Name = "lbPods";
            this.lbPods.Size = new System.Drawing.Size(410, 21);
            this.lbPods.Sorted = true;
            this.lbPods.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(8, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(410, 39);
            this.label4.TabIndex = 27;
            this.label4.Text = "Provide the POD name running the application to be debugged. If the POD has more " +
    "than one container, the first one returned by the cluster will be used.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(8, 175);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 16, 0, 4);
            this.label6.Size = new System.Drawing.Size(61, 33);
            this.label6.TabIndex = 25;
            this.label6.Text = "POD Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbNamespaces
            // 
            this.lbNamespaces.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbNamespaces.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbNamespaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lbNamespaces.Location = new System.Drawing.Point(8, 154);
            this.lbNamespaces.Name = "lbNamespaces";
            this.lbNamespaces.Size = new System.Drawing.Size(410, 21);
            this.lbNamespaces.TabIndex = 38;
            this.lbNamespaces.SelectedIndexChanged += new System.EventHandler(this.lbNamespaces_SelectedIndexChanged_1);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(8, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(410, 39);
            this.label10.TabIndex = 40;
            this.label10.Text = "You can provide a specific namespace to look for the POD. If none is specified, t" +
    "he current namespace will be searched.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(8, 82);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 16, 0, 4);
            this.label8.Size = new System.Drawing.Size(113, 33);
            this.label8.TabIndex = 39;
            this.label8.Text = "Namespace (optional):";
            // 
            // cbAppName
            // 
            this.cbAppName.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAppName.FormattingEnabled = true;
            this.cbAppName.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cbAppName.Location = new System.Drawing.Point(8, 61);
            this.cbAppName.Name = "cbAppName";
            this.cbAppName.Size = new System.Drawing.Size(410, 21);
            this.cbAppName.Sorted = true;
            this.cbAppName.TabIndex = 0;
            this.cbAppName.TextChanged += new System.EventHandler(this.cbAppName_TextChanged);
            this.cbAppName.Validated += new System.EventHandler(this.cbAppName_Validated);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label5.Size = new System.Drawing.Size(410, 36);
            this.label5.TabIndex = 24;
            this.label5.Text = "Inform the name used to deploy the application to Kubernetes. If solution has Hel" +
    "m project folders, you can select a name from the list below.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Application Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tabCustomScript
            // 
            this.tabCustomScript.Controls.Add(this.txScript);
            this.tabCustomScript.Controls.Add(this.label1);
            this.tabCustomScript.Controls.Add(this.toolStrip1);
            this.tabCustomScript.Location = new System.Drawing.Point(4, 25);
            this.tabCustomScript.Name = "tabCustomScript";
            this.tabCustomScript.Padding = new System.Windows.Forms.Padding(8);
            this.tabCustomScript.Size = new System.Drawing.Size(426, 281);
            this.tabCustomScript.TabIndex = 1;
            this.tabCustomScript.Text = "Custom Script";
            this.tabCustomScript.UseVisualStyleBackColor = true;
            // 
            // txScript
            // 
            this.txScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.txScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txScript.DetectUrls = false;
            this.txScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txScript.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txScript.ForeColor = System.Drawing.Color.Silver;
            this.txScript.Location = new System.Drawing.Point(8, 33);
            this.txScript.Name = "txScript";
            this.txScript.ShortcutsEnabled = false;
            this.txScript.ShowSelectionMargin = true;
            this.txScript.Size = new System.Drawing.Size(410, 207);
            this.txScript.TabIndex = 1;
            this.txScript.Text = "Script";
            this.txScript.WordWrap = false;
            this.txScript.TextChanged += new System.EventHandler(this.txScript_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(8, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 33);
            this.label1.TabIndex = 32;
            this.label1.Text = "This script will be executed by Debug.MIEngine command in Visual Studio. It needs" +
    " to fully prepare the container for debugging and can be edited before execution" +
    ".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btCustomScriptOpen,
            this.btCustomScriptSave,
            this.btCustomScriptReload,
            this.toolStripSeparator2,
            this.btCustomScriptClear,
            this.toolStripSeparator1,
            this.laCustomScriptFile});
            this.toolStrip1.Location = new System.Drawing.Point(8, 8);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(410, 25);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btCustomScriptOpen
            // 
            this.btCustomScriptOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCustomScriptOpen.Image = global::Debug.Kubernetes.Extension.Properties.Resources.open_outline_black;
            this.btCustomScriptOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCustomScriptOpen.Name = "btCustomScriptOpen";
            this.btCustomScriptOpen.Size = new System.Drawing.Size(23, 22);
            this.btCustomScriptOpen.Text = "toolStripButton1";
            this.btCustomScriptOpen.ToolTipText = "Open custom script";
            this.btCustomScriptOpen.Click += new System.EventHandler(this.btCustomScriptOpen_Click);
            // 
            // btCustomScriptSave
            // 
            this.btCustomScriptSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCustomScriptSave.Image = global::Debug.Kubernetes.Extension.Properties.Resources.save_outline_black;
            this.btCustomScriptSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCustomScriptSave.Name = "btCustomScriptSave";
            this.btCustomScriptSave.Size = new System.Drawing.Size(23, 22);
            this.btCustomScriptSave.Text = "toolStripButton2";
            this.btCustomScriptSave.ToolTipText = "Save custom script";
            this.btCustomScriptSave.Click += new System.EventHandler(this.btCustomScriptSave_Click);
            // 
            // btCustomScriptReload
            // 
            this.btCustomScriptReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCustomScriptReload.Image = global::Debug.Kubernetes.Extension.Properties.Resources.reload_outline_black;
            this.btCustomScriptReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCustomScriptReload.Name = "btCustomScriptReload";
            this.btCustomScriptReload.Size = new System.Drawing.Size(23, 22);
            this.btCustomScriptReload.Text = "toolStripButton3";
            this.btCustomScriptReload.ToolTipText = "Reload script content from disk";
            this.btCustomScriptReload.Click += new System.EventHandler(this.btCustomScriptReload_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btCustomScriptClear
            // 
            this.btCustomScriptClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCustomScriptClear.Image = global::Debug.Kubernetes.Extension.Properties.Resources.remove_outline_black;
            this.btCustomScriptClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCustomScriptClear.Name = "btCustomScriptClear";
            this.btCustomScriptClear.Size = new System.Drawing.Size(23, 22);
            this.btCustomScriptClear.Text = "toolStripButton1";
            this.btCustomScriptClear.ToolTipText = "Reset custom script";
            this.btCustomScriptClear.Click += new System.EventHandler(this.btCustomScriptClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // laCustomScriptFile
            // 
            this.laCustomScriptFile.AutoToolTip = true;
            this.laCustomScriptFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.laCustomScriptFile.Enabled = false;
            this.laCustomScriptFile.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.laCustomScriptFile.Image = global::Debug.Kubernetes.Extension.Properties.Resources.edit_outline_black;
            this.laCustomScriptFile.Name = "laCustomScriptFile";
            this.laCustomScriptFile.Size = new System.Drawing.Size(52, 22);
            this.laCustomScriptFile.Text = "(default)";
            // 
            // tabHelp
            // 
            this.tabHelp.Location = new System.Drawing.Point(4, 25);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabHelp.Size = new System.Drawing.Size(426, 281);
            this.tabHelp.TabIndex = 2;
            this.tabHelp.Text = "Help";
            this.tabHelp.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btDebug);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 438);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.panel2.Size = new System.Drawing.Size(434, 31);
            this.panel2.TabIndex = 2;
            // 
            // SDlgScript
            // 
            this.SDlgScript.DefaultExt = "ps1";
            this.SDlgScript.Filter = "PowerShell script|*.ps1|Batch Files|*.bat;*.cmd|All Files|*.*";
            this.SDlgScript.RestoreDirectory = true;
            this.SDlgScript.Title = "Save Script";
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(434, 491);
            this.Controls.Add(this.Pages);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ssProgress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 530);
            this.Name = "ConfigDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Debug Kubernetes Container";
            this.Shown += new System.EventHandler(this.ConfigDialog_Shown);
            this.ssProgress.ResumeLayout(false);
            this.ssProgress.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Pages.ResumeLayout(false);
            this.tabDefault.ResumeLayout(false);
            this.tabDefault.PerformLayout();
            this.tabCustomScript.ResumeLayout(false);
            this.tabCustomScript.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip ssProgress;
        private System.Windows.Forms.ToolStripProgressBar sbProgress;
        private System.Windows.Forms.ToolStripStatusLabel sbStatus;
        private System.Windows.Forms.OpenFileDialog ODlgScript;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btDebug;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage tabDefault;
        private System.Windows.Forms.ComboBox lbPods;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAppName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabCustomScript;
        private System.Windows.Forms.RichTextBox txScript;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.ComboBox lbContexts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txClusterInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lbNamespaces;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btCustomScriptOpen;
        private System.Windows.Forms.ToolStripButton btCustomScriptSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btCustomScriptReload;
        private System.Windows.Forms.ToolStripLabel laCustomScriptFile;
        private System.Windows.Forms.SaveFileDialog SDlgScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btCustomScriptClear;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}