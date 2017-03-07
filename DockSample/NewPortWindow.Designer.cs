namespace DockSample
{
    partial class NewPortWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPortWindow));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.portTreeView = new System.Windows.Forms.TreeView();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.parityComboBox = new System.Windows.Forms.ComboBox();
            this.parityLabel = new System.Windows.Forms.Label();
            this.stopbitsLabel = new System.Windows.Forms.Label();
            this.databitsLabel = new System.Windows.Forms.Label();
            this.databitsComboBox = new System.Windows.Forms.ComboBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRcvWinName = new System.Windows.Forms.ComboBox();
            this.flowComboBox = new System.Windows.Forms.ComboBox();
            this.flowLabel = new System.Windows.Forms.Label();
            this.stopbitsComboBox = new System.Windows.Forms.ComboBox();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.baudrateComboBox = new System.Windows.Forms.ComboBox();
            this.stateFaceImageList = new System.Windows.Forms.ImageList(this.components);
            this.OpenPortTitleToolStrip = new System.Windows.Forms.ToolStrip();
            this.btClose = new System.Windows.Forms.ToolStripButton();
            this.btOpenPort = new System.Windows.Forms.ToolStripButton();
            this.btAddCfg = new System.Windows.Forms.ToolStripButton();
            this.btDelCfg = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btEnableCustomBaud = new System.Windows.Forms.ToolStripButton();
            this.portOpenStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.portInfoStatusStrip = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.OpenPortTitleToolStrip.SuspendLayout();
            this.portInfoStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.portTreeView);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(2, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 197);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List";
            // 
            // portTreeView
            // 
            this.portTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portTreeView.ImageIndex = 0;
            this.portTreeView.ImageList = this.treeViewImageList;
            this.portTreeView.Location = new System.Drawing.Point(3, 17);
            this.portTreeView.Name = "portTreeView";
            this.portTreeView.SelectedImageIndex = 2;
            this.portTreeView.Size = new System.Drawing.Size(202, 177);
            this.portTreeView.StateImageList = this.treeViewImageList;
            this.portTreeView.TabIndex = 0;
            this.portTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.portTreeView_BeforeSelect);
            this.portTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.portTreeView_AfterSelect);
            this.portTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.portTreeView_NodeMouseDoubleClick);
            this.portTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.portTreeView_MouseClick);
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImageList.Images.SetKeyName(0, "link.png");
            this.treeViewImageList.Images.SetKeyName(1, "link-broken.png");
            this.treeViewImageList.Images.SetKeyName(2, "checkbox-empty.png");
            this.treeViewImageList.Images.SetKeyName(3, "checkbox.png");
            this.treeViewImageList.Images.SetKeyName(4, "connect-alt-1.png");
            this.treeViewImageList.Images.SetKeyName(5, "connection-error-alt-1.png");
            // 
            // parityComboBox
            // 
            this.parityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parityComboBox.FormattingEnabled = true;
            this.parityComboBox.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.parityComboBox.Location = new System.Drawing.Point(102, 143);
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(95, 20);
            this.parityComboBox.TabIndex = 14;
            // 
            // parityLabel
            // 
            this.parityLabel.AutoSize = true;
            this.parityLabel.Location = new System.Drawing.Point(6, 151);
            this.parityLabel.Name = "parityLabel";
            this.parityLabel.Size = new System.Drawing.Size(41, 12);
            this.parityLabel.TabIndex = 12;
            this.parityLabel.Text = "Parity";
            // 
            // stopbitsLabel
            // 
            this.stopbitsLabel.AutoSize = true;
            this.stopbitsLabel.Location = new System.Drawing.Point(6, 126);
            this.stopbitsLabel.Name = "stopbitsLabel";
            this.stopbitsLabel.Size = new System.Drawing.Size(59, 12);
            this.stopbitsLabel.TabIndex = 11;
            this.stopbitsLabel.Text = "Stop bits";
            // 
            // databitsLabel
            // 
            this.databitsLabel.AutoSize = true;
            this.databitsLabel.Location = new System.Drawing.Point(6, 101);
            this.databitsLabel.Name = "databitsLabel";
            this.databitsLabel.Size = new System.Drawing.Size(59, 12);
            this.databitsLabel.TabIndex = 10;
            this.databitsLabel.Text = "Data bits";
            // 
            // databitsComboBox
            // 
            this.databitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databitsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.databitsComboBox.FormattingEnabled = true;
            this.databitsComboBox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.databitsComboBox.Location = new System.Drawing.Point(102, 93);
            this.databitsComboBox.Name = "databitsComboBox";
            this.databitsComboBox.Size = new System.Drawing.Size(95, 20);
            this.databitsComboBox.TabIndex = 8;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(6, 76);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(59, 12);
            this.speedLabel.TabIndex = 7;
            this.speedLabel.Text = "Baud rate";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.portLabel.Location = new System.Drawing.Point(6, 51);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 12);
            this.portLabel.TabIndex = 6;
            this.portLabel.Text = "Port";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbRcvWinName);
            this.groupBox1.Controls.Add(this.flowComboBox);
            this.groupBox1.Controls.Add(this.parityComboBox);
            this.groupBox1.Controls.Add(this.flowLabel);
            this.groupBox1.Controls.Add(this.parityLabel);
            this.groupBox1.Controls.Add(this.stopbitsLabel);
            this.groupBox1.Controls.Add(this.databitsLabel);
            this.groupBox1.Controls.Add(this.stopbitsComboBox);
            this.groupBox1.Controls.Add(this.databitsComboBox);
            this.groupBox1.Controls.Add(this.speedLabel);
            this.groupBox1.Controls.Add(this.portLabel);
            this.groupBox1.Controls.Add(this.portComboBox);
            this.groupBox1.Controls.Add(this.baudrateComboBox);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(216, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 197);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // cbRcvWinName
            // 
            this.cbRcvWinName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRcvWinName.FormattingEnabled = true;
            this.cbRcvWinName.Location = new System.Drawing.Point(103, 18);
            this.cbRcvWinName.Name = "cbRcvWinName";
            this.cbRcvWinName.Size = new System.Drawing.Size(95, 20);
            this.cbRcvWinName.TabIndex = 16;
            // 
            // flowComboBox
            // 
            this.flowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flowComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flowComboBox.FormattingEnabled = true;
            this.flowComboBox.Items.AddRange(new object[] {
            "None",
            "Hardware",
            "Software"});
            this.flowComboBox.Location = new System.Drawing.Point(102, 168);
            this.flowComboBox.Name = "flowComboBox";
            this.flowComboBox.Size = new System.Drawing.Size(95, 20);
            this.flowComboBox.TabIndex = 15;
            // 
            // flowLabel
            // 
            this.flowLabel.AutoSize = true;
            this.flowLabel.Location = new System.Drawing.Point(6, 176);
            this.flowLabel.Name = "flowLabel";
            this.flowLabel.Size = new System.Drawing.Size(77, 12);
            this.flowLabel.TabIndex = 13;
            this.flowLabel.Text = "Flow control";
            // 
            // stopbitsComboBox
            // 
            this.stopbitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopbitsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopbitsComboBox.FormattingEnabled = true;
            this.stopbitsComboBox.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stopbitsComboBox.Location = new System.Drawing.Point(102, 118);
            this.stopbitsComboBox.Name = "stopbitsComboBox";
            this.stopbitsComboBox.Size = new System.Drawing.Size(95, 20);
            this.stopbitsComboBox.TabIndex = 9;
            // 
            // portComboBox
            // 
            this.portComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(102, 43);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(95, 20);
            this.portComboBox.TabIndex = 0;
            this.portComboBox.SelectedIndexChanged += new System.EventHandler(this.portComboBox_SelectedIndexChanged);
            // 
            // baudrateComboBox
            // 
            this.baudrateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudrateComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baudrateComboBox.FormattingEnabled = true;
            this.baudrateComboBox.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "128000",
            "115200",
            "256000"});
            this.baudrateComboBox.Location = new System.Drawing.Point(102, 68);
            this.baudrateComboBox.Name = "baudrateComboBox";
            this.baudrateComboBox.Size = new System.Drawing.Size(95, 20);
            this.baudrateComboBox.TabIndex = 5;
            this.baudrateComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.baudrateComboBox_KeyPress);
            // 
            // stateFaceImageList
            // 
            this.stateFaceImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateFaceImageList.ImageStream")));
            this.stateFaceImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.stateFaceImageList.Images.SetKeyName(0, "connect.png");
            this.stateFaceImageList.Images.SetKeyName(1, "connection-error.png");
            this.stateFaceImageList.Images.SetKeyName(2, "user-locked.png");
            this.stateFaceImageList.Images.SetKeyName(3, "user.png");
            // 
            // OpenPortTitleToolStrip
            // 
            this.OpenPortTitleToolStrip.BackColor = System.Drawing.SystemColors.Window;
            this.OpenPortTitleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.OpenPortTitleToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btClose,
            this.btOpenPort,
            this.btAddCfg,
            this.btDelCfg,
            this.toolStripLabel1,
            this.btEnableCustomBaud});
            this.OpenPortTitleToolStrip.Location = new System.Drawing.Point(0, 1);
            this.OpenPortTitleToolStrip.Margin = new System.Windows.Forms.Padding(2);
            this.OpenPortTitleToolStrip.Name = "OpenPortTitleToolStrip";
            this.OpenPortTitleToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.OpenPortTitleToolStrip.Size = new System.Drawing.Size(422, 25);
            this.OpenPortTitleToolStrip.TabIndex = 27;
            this.OpenPortTitleToolStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenPortTitleToolStrip_MouseDown);
            this.OpenPortTitleToolStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenPortTitleToolStrip_MouseMove);
            this.OpenPortTitleToolStrip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenPortTitleToolStrip_MouseUp);
            // 
            // btClose
            // 
            this.btClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btClose.Image = global::DockSample.Properties.Resources.cancel;
            this.btClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(23, 22);
            this.btClose.Text = "Cancel";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btOpenPort
            // 
            this.btOpenPort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btOpenPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btOpenPort.Image = global::DockSample.Properties.Resources.check_alt;
            this.btOpenPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOpenPort.Name = "btOpenPort";
            this.btOpenPort.Size = new System.Drawing.Size(23, 22);
            this.btOpenPort.Text = "Open";
            this.btOpenPort.Click += new System.EventHandler(this.btOpenPort_Click);
            // 
            // btAddCfg
            // 
            this.btAddCfg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btAddCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAddCfg.Image = global::DockSample.Properties.Resources.database_add_alt_2;
            this.btAddCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAddCfg.Name = "btAddCfg";
            this.btAddCfg.Size = new System.Drawing.Size(23, 22);
            this.btAddCfg.Text = "Add To List";
            this.btAddCfg.Click += new System.EventHandler(this.btAddCfg_Click);
            // 
            // btDelCfg
            // 
            this.btDelCfg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btDelCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btDelCfg.Image = global::DockSample.Properties.Resources.database_remove_alt_2;
            this.btDelCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDelCfg.Name = "btDelCfg";
            this.btDelCfg.Size = new System.Drawing.Size(23, 22);
            this.btDelCfg.Text = "Del From List";
            this.btDelCfg.Click += new System.EventHandler(this.btDelCfg_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::DockSample.Properties.Resources.terminal;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 22);
            this.toolStripLabel1.Text = "Port";
            // 
            // btEnableCustomBaud
            // 
            this.btEnableCustomBaud.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btEnableCustomBaud.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btEnableCustomBaud.Image = global::DockSample.Properties.Resources.user_locked;
            this.btEnableCustomBaud.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEnableCustomBaud.Name = "btEnableCustomBaud";
            this.btEnableCustomBaud.Size = new System.Drawing.Size(23, 22);
            this.btEnableCustomBaud.Text = "Custom Baud";
            this.btEnableCustomBaud.Click += new System.EventHandler(this.btEnableCustomBaud_Click);
            // 
            // portOpenStatusLabel
            // 
            this.portOpenStatusLabel.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portOpenStatusLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.portOpenStatusLabel.Margin = new System.Windows.Forms.Padding(2);
            this.portOpenStatusLabel.Name = "portOpenStatusLabel";
            this.portOpenStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.portOpenStatusLabel.Size = new System.Drawing.Size(95, 18);
            this.portOpenStatusLabel.Text = "Port Status";
            // 
            // portInfoStatusStrip
            // 
            this.portInfoStatusStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.portInfoStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portOpenStatusLabel});
            this.portInfoStatusStrip.Location = new System.Drawing.Point(0, 227);
            this.portInfoStatusStrip.Name = "portInfoStatusStrip";
            this.portInfoStatusStrip.Size = new System.Drawing.Size(422, 22);
            this.portInfoStatusStrip.SizingGrip = false;
            this.portInfoStatusStrip.Stretch = false;
            this.portInfoStatusStrip.TabIndex = 26;
            this.portInfoStatusStrip.Text = "portInfoStatusStrip";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 1);
            this.panel1.TabIndex = 28;
            // 
            // NewPortWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 249);
            this.Controls.Add(this.OpenPortTitleToolStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.portInfoStatusStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPortWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewPortWindow";
            this.Load += new System.EventHandler(this.NewPortWindow_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.OpenPortTitleToolStrip.ResumeLayout(false);
            this.OpenPortTitleToolStrip.PerformLayout();
            this.portInfoStatusStrip.ResumeLayout(false);
            this.portInfoStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox parityComboBox;
        private System.Windows.Forms.Label parityLabel;
        private System.Windows.Forms.Label stopbitsLabel;
        private System.Windows.Forms.Label databitsLabel;
        private System.Windows.Forms.ComboBox databitsComboBox;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox stopbitsComboBox;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.ComboBox baudrateComboBox;
        private System.Windows.Forms.TreeView portTreeView;
        private System.Windows.Forms.ImageList treeViewImageList;
        private System.Windows.Forms.ImageList stateFaceImageList;
        private System.Windows.Forms.ToolStrip OpenPortTitleToolStrip;
        private System.Windows.Forms.ToolStripButton btClose;
        private System.Windows.Forms.ToolStripButton btDelCfg;
        private System.Windows.Forms.ToolStripButton btAddCfg;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btOpenPort;
        private System.Windows.Forms.ToolStripStatusLabel portOpenStatusLabel;
        private System.Windows.Forms.StatusStrip portInfoStatusStrip;
        private System.Windows.Forms.ToolStripButton btEnableCustomBaud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRcvWinName;
        private System.Windows.Forms.ComboBox flowComboBox;
        private System.Windows.Forms.Label flowLabel;
        private System.Windows.Forms.Panel panel1;
    }
}