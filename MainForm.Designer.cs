namespace hands_viewer.cs
{
    partial class MainForm
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
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Live = new System.Windows.Forms.ToolStripMenuItem();
            this.Playback = new System.Windows.Forms.ToolStripMenuItem();
            this.Record = new System.Windows.Forms.ToolStripMenuItem();
            this.Joints = new System.Windows.Forms.CheckBox();
            this.Depth = new System.Windows.Forms.RadioButton();
            this.Labelmap = new System.Windows.Forms.RadioButton();
            this.Skeleton = new System.Windows.Forms.CheckBox();
            this.Status2 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Scale2 = new System.Windows.Forms.CheckBox();
            this.Panel2 = new System.Windows.Forms.PictureBox();
            this.Mirror = new System.Windows.Forms.CheckBox();
            this.cmbGesturesList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFPS = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkExport = new System.Windows.Forms.CheckBox();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.chkAbsolutePosition = new System.Windows.Forms.CheckBox();
            this.chkAbsoluteAngle = new System.Windows.Forms.CheckBox();
            this.chkRelativePosition = new System.Windows.Forms.CheckBox();
            this.chkRelativeAngle = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEnableColor = new System.Windows.Forms.CheckBox();
            this.MainMenu.SuspendLayout();
            this.Status2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel2)).BeginInit();
            this.grpExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Start.BackColor = System.Drawing.Color.ForestGreen;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Start.Font = new System.Drawing.Font("Webdings", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Start.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Start.Location = new System.Drawing.Point(757, 501);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(80, 75);
            this.Start.TabIndex = 2;
            this.Start.Text = "4";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(97, 344);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(80, 27);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Visible = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.sourceToolStripMenuItem.Text = "Device";
            this.sourceToolStripMenuItem.Visible = false;
            // 
            // moduleToolStripMenuItem
            // 
            this.moduleToolStripMenuItem.Name = "moduleToolStripMenuItem";
            this.moduleToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.moduleToolStripMenuItem.Text = "Module";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceToolStripMenuItem,
            this.moduleToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(849, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Live,
            this.Playback,
            this.Record});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // Live
            // 
            this.Live.Checked = true;
            this.Live.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Live.Name = "Live";
            this.Live.Size = new System.Drawing.Size(121, 22);
            this.Live.Text = "Live";
            this.Live.Click += new System.EventHandler(this.Live_Click);
            // 
            // Playback
            // 
            this.Playback.Name = "Playback";
            this.Playback.Size = new System.Drawing.Size(121, 22);
            this.Playback.Text = "Playback";
            this.Playback.Click += new System.EventHandler(this.Playback_Click);
            // 
            // Record
            // 
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(121, 22);
            this.Record.Text = "Record";
            this.Record.Click += new System.EventHandler(this.Record_Click);
            // 
            // Joints
            // 
            this.Joints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Joints.AutoSize = true;
            this.Joints.Checked = true;
            this.Joints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Joints.Location = new System.Drawing.Point(10, 65);
            this.Joints.Name = "Joints";
            this.Joints.Size = new System.Drawing.Size(53, 17);
            this.Joints.TabIndex = 19;
            this.Joints.Text = "Joints";
            this.Joints.UseVisualStyleBackColor = true;
            // 
            // Depth
            // 
            this.Depth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Depth.AutoSize = true;
            this.Depth.Checked = true;
            this.Depth.Location = new System.Drawing.Point(34, 331);
            this.Depth.Name = "Depth";
            this.Depth.Size = new System.Drawing.Size(54, 17);
            this.Depth.TabIndex = 20;
            this.Depth.TabStop = true;
            this.Depth.Text = "Depth";
            this.Depth.UseVisualStyleBackColor = true;
            this.Depth.Visible = false;
            // 
            // Labelmap
            // 
            this.Labelmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Labelmap.AutoSize = true;
            this.Labelmap.Location = new System.Drawing.Point(35, 354);
            this.Labelmap.Name = "Labelmap";
            this.Labelmap.Size = new System.Drawing.Size(95, 17);
            this.Labelmap.TabIndex = 21;
            this.Labelmap.Text = "Labeled Image";
            this.Labelmap.UseVisualStyleBackColor = true;
            this.Labelmap.Visible = false;
            // 
            // Skeleton
            // 
            this.Skeleton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Skeleton.AutoSize = true;
            this.Skeleton.Checked = true;
            this.Skeleton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Skeleton.Location = new System.Drawing.Point(10, 88);
            this.Skeleton.Name = "Skeleton";
            this.Skeleton.Size = new System.Drawing.Size(68, 17);
            this.Skeleton.TabIndex = 23;
            this.Skeleton.Text = "Skeleton";
            this.Skeleton.UseVisualStyleBackColor = true;
            // 
            // Status2
            // 
            this.Status2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.Status2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Status2.Location = new System.Drawing.Point(0, 579);
            this.Status2.Name = "Status2";
            this.Status2.Size = new System.Drawing.Size(849, 20);
            this.Status2.TabIndex = 25;
            this.Status2.Text = "Status2";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(23, 15);
            this.StatusLabel.Text = "OK";
            // 
            // Scale2
            // 
            this.Scale2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Scale2.AutoSize = true;
            this.Scale2.Checked = true;
            this.Scale2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Scale2.Location = new System.Drawing.Point(10, 19);
            this.Scale2.Name = "Scale2";
            this.Scale2.Size = new System.Drawing.Size(53, 17);
            this.Scale2.TabIndex = 26;
            this.Scale2.Text = "Scale";
            this.Scale2.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel2.ErrorImage = null;
            this.Panel2.Image = global::FF_HandsViewer.cs.Properties.Resources.logo;
            this.Panel2.InitialImage = null;
            this.Panel2.Location = new System.Drawing.Point(12, 27);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(400, 349);
            this.Panel2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Panel2.TabIndex = 27;
            this.Panel2.TabStop = false;
            this.Panel2.Click += new System.EventHandler(this.Panel2_Click);
            // 
            // Mirror
            // 
            this.Mirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mirror.AutoSize = true;
            this.Mirror.Checked = true;
            this.Mirror.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Mirror.Location = new System.Drawing.Point(10, 42);
            this.Mirror.Name = "Mirror";
            this.Mirror.Size = new System.Drawing.Size(52, 17);
            this.Mirror.TabIndex = 30;
            this.Mirror.Text = "Mirror";
            this.Mirror.UseVisualStyleBackColor = true;
            // 
            // cmbGesturesList
            // 
            this.cmbGesturesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGesturesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbGesturesList.FormattingEnabled = true;
            this.cmbGesturesList.Location = new System.Drawing.Point(84, 301);
            this.cmbGesturesList.Name = "cmbGesturesList";
            this.cmbGesturesList.Size = new System.Drawing.Size(122, 17);
            this.cmbGesturesList.TabIndex = 35;
            this.cmbGesturesList.Visible = false;
            this.cmbGesturesList.SelectedIndexChanged += new System.EventHandler(this.cmbGesturesList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Gesture:";
            this.label2.Visible = false;
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Location = new System.Drawing.Point(595, 563);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(16, 13);
            this.labelFPS.TabIndex = 39;
            this.labelFPS.Text = "...";
            this.labelFPS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // infoTextBox
            // 
            this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextBox.Location = new System.Drawing.Point(22, 327);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(69, 44);
            this.infoTextBox.TabIndex = 40;
            this.infoTextBox.Text = "";
            this.infoTextBox.Visible = false;
            // 
            // txtExportPath
            // 
            this.txtExportPath.Enabled = false;
            this.txtExportPath.Location = new System.Drawing.Point(14, 55);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(270, 20);
            this.txtExportPath.TabIndex = 41;
            this.txtExportPath.TextChanged += new System.EventHandler(this.txtExportPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Export Path";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(290, 53);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 43;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkExport
            // 
            this.chkExport.AutoSize = true;
            this.chkExport.Location = new System.Drawing.Point(14, 19);
            this.chkExport.Name = "chkExport";
            this.chkExport.Size = new System.Drawing.Size(59, 17);
            this.chkExport.TabIndex = 45;
            this.chkExport.Text = "Enable";
            this.chkExport.UseVisualStyleBackColor = true;
            this.chkExport.CheckedChanged += new System.EventHandler(this.chkExport_CheckedChanged);
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.chkAbsolutePosition);
            this.grpExport.Controls.Add(this.chkAbsoluteAngle);
            this.grpExport.Controls.Add(this.chkRelativePosition);
            this.grpExport.Controls.Add(this.chkRelativeAngle);
            this.grpExport.Controls.Add(this.label3);
            this.grpExport.Controls.Add(this.chkExport);
            this.grpExport.Controls.Add(this.txtExportPath);
            this.grpExport.Controls.Add(this.label1);
            this.grpExport.Controls.Add(this.btnBrowse);
            this.grpExport.Location = new System.Drawing.Point(218, 387);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(371, 189);
            this.grpExport.TabIndex = 46;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "Export Options";
            // 
            // chkAbsolutePosition
            // 
            this.chkAbsolutePosition.AutoSize = true;
            this.chkAbsolutePosition.Checked = true;
            this.chkAbsolutePosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAbsolutePosition.Location = new System.Drawing.Point(95, 158);
            this.chkAbsolutePosition.Name = "chkAbsolutePosition";
            this.chkAbsolutePosition.Size = new System.Drawing.Size(107, 17);
            this.chkAbsolutePosition.TabIndex = 53;
            this.chkAbsolutePosition.Text = "Absolute Position";
            this.chkAbsolutePosition.UseVisualStyleBackColor = true;
            // 
            // chkAbsoluteAngle
            // 
            this.chkAbsoluteAngle.AutoSize = true;
            this.chkAbsoluteAngle.Checked = true;
            this.chkAbsoluteAngle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAbsoluteAngle.Location = new System.Drawing.Point(95, 135);
            this.chkAbsoluteAngle.Name = "chkAbsoluteAngle";
            this.chkAbsoluteAngle.Size = new System.Drawing.Size(97, 17);
            this.chkAbsoluteAngle.TabIndex = 52;
            this.chkAbsoluteAngle.Text = "Absolute Angle";
            this.chkAbsoluteAngle.UseVisualStyleBackColor = true;
            // 
            // chkRelativePosition
            // 
            this.chkRelativePosition.AutoSize = true;
            this.chkRelativePosition.Checked = true;
            this.chkRelativePosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRelativePosition.Location = new System.Drawing.Point(95, 112);
            this.chkRelativePosition.Name = "chkRelativePosition";
            this.chkRelativePosition.Size = new System.Drawing.Size(105, 17);
            this.chkRelativePosition.TabIndex = 51;
            this.chkRelativePosition.Text = "Relative Position";
            this.chkRelativePosition.UseVisualStyleBackColor = true;
            // 
            // chkRelativeAngle
            // 
            this.chkRelativeAngle.AutoSize = true;
            this.chkRelativeAngle.Checked = true;
            this.chkRelativeAngle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRelativeAngle.Location = new System.Drawing.Point(95, 89);
            this.chkRelativeAngle.Name = "chkRelativeAngle";
            this.chkRelativeAngle.Size = new System.Drawing.Size(95, 17);
            this.chkRelativeAngle.TabIndex = 50;
            this.chkRelativeAngle.Text = "Relative Angle";
            this.chkRelativeAngle.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Joint Data:";
            // 
            // Panel3
            // 
            this.Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel3.ErrorImage = null;
            this.Panel3.Image = global::FF_HandsViewer.cs.Properties.Resources.logo;
            this.Panel3.InitialImage = null;
            this.Panel3.Location = new System.Drawing.Point(437, 27);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(400, 349);
            this.Panel3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Panel3.TabIndex = 47;
            this.Panel3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Scale2);
            this.groupBox1.Controls.Add(this.Joints);
            this.groupBox1.Controls.Add(this.Skeleton);
            this.groupBox1.Controls.Add(this.Mirror);
            this.groupBox1.Location = new System.Drawing.Point(12, 387);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 189);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing Options";
            // 
            // chkEnableColor
            // 
            this.chkEnableColor.AutoSize = true;
            this.chkEnableColor.Checked = true;
            this.chkEnableColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableColor.Location = new System.Drawing.Point(437, 6);
            this.chkEnableColor.Name = "chkEnableColor";
            this.chkEnableColor.Size = new System.Drawing.Size(122, 17);
            this.chkEnableColor.TabIndex = 49;
            this.chkEnableColor.Text = "Enable Color Stream";
            this.chkEnableColor.UseVisualStyleBackColor = true;
            this.chkEnableColor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(849, 599);
            this.Controls.Add(this.chkEnableColor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.grpExport);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.labelFPS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGesturesList);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Status2);
            this.Controls.Add(this.Labelmap);
            this.Controls.Add(this.Depth);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "RealSense Stream Export Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Status2.ResumeLayout(false);
            this.Status2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel2)).EndInit();
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panel3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moduleToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.CheckBox Joints;
        private System.Windows.Forms.RadioButton Depth;
        private System.Windows.Forms.RadioButton Labelmap;
        private System.Windows.Forms.CheckBox Skeleton;
        private System.Windows.Forms.StatusStrip Status2;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.CheckBox Scale2;
        private System.Windows.Forms.PictureBox Panel2;
        private System.Windows.Forms.CheckBox Mirror;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Live;
        private System.Windows.Forms.ToolStripMenuItem Playback;
        private System.Windows.Forms.ToolStripMenuItem Record;
        private System.Windows.Forms.ComboBox cmbGesturesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.RichTextBox infoTextBox;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkExport;
        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox Panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAbsolutePosition;
        private System.Windows.Forms.CheckBox chkAbsoluteAngle;
        private System.Windows.Forms.CheckBox chkRelativePosition;
        private System.Windows.Forms.CheckBox chkRelativeAngle;
        private System.Windows.Forms.CheckBox chkEnableColor;
    }
}