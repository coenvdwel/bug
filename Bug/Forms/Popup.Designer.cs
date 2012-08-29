using Bug.Controls;

namespace Bug.Forms
{
  partial class Popup
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup));
      this.panel = new System.Windows.Forms.Panel();
      this.btnHide = new System.Windows.Forms.LinkLabel();
      this.borderBottom = new System.Windows.Forms.PictureBox();
      this.btnView = new System.Windows.Forms.LinkLabel();
      this.notificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cbInterval = new System.Windows.Forms.ToolStripComboBox();
      this.separator = new System.Windows.Forms.ToolStripSeparator();
      this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
      this.lblReference = new System.Windows.Forms.Label();
      this.lblToday = new System.Windows.Forms.Label();
      this.lblCurrent = new System.Windows.Forms.Label();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.tbEntry = new Bug.Controls.SelectionTextBox();
      this.tbReference = new Bug.Controls.SelectionTextBox();
      this.borderTop = new System.Windows.Forms.PictureBox();
      this.logo = new System.Windows.Forms.PictureBox();
      this.panel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.borderBottom)).BeginInit();
      this.contextMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.borderTop)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
      this.SuspendLayout();
      // 
      // panel
      // 
      this.panel.BackColor = System.Drawing.SystemColors.InactiveBorder;
      this.panel.Controls.Add(this.btnHide);
      this.panel.Controls.Add(this.borderBottom);
      this.panel.Controls.Add(this.btnView);
      this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel.Location = new System.Drawing.Point(0, 134);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(184, 50);
      this.panel.TabIndex = 0;
      // 
      // btnHide
      // 
      this.btnHide.ActiveLinkColor = System.Drawing.Color.Blue;
      this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnHide.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.btnHide.LinkColor = System.Drawing.Color.Blue;
      this.btnHide.Location = new System.Drawing.Point(12, 28);
      this.btnHide.Name = "btnHide";
      this.btnHide.Size = new System.Drawing.Size(160, 17);
      this.btnHide.TabIndex = 3;
      this.btnHide.TabStop = true;
      this.btnHide.Text = "Hide";
      this.btnHide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnHide.VisitedLinkColor = System.Drawing.Color.Blue;
      this.btnHide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnHide_LinkClicked);
      // 
      // borderBottom
      // 
      this.borderBottom.Dock = System.Windows.Forms.DockStyle.Top;
      this.borderBottom.Image = global::Bug.Properties.Resources.border;
      this.borderBottom.Location = new System.Drawing.Point(0, 0);
      this.borderBottom.Name = "borderBottom";
      this.borderBottom.Size = new System.Drawing.Size(184, 3);
      this.borderBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.borderBottom.TabIndex = 2;
      this.borderBottom.TabStop = false;
      // 
      // btnView
      // 
      this.btnView.ActiveLinkColor = System.Drawing.Color.Blue;
      this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnView.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.btnView.LinkColor = System.Drawing.Color.Blue;
      this.btnView.Location = new System.Drawing.Point(12, 10);
      this.btnView.Name = "btnView";
      this.btnView.Size = new System.Drawing.Size(160, 17);
      this.btnView.TabIndex = 1;
      this.btnView.TabStop = true;
      this.btnView.Text = "Open today\'s page";
      this.btnView.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnView.VisitedLinkColor = System.Drawing.Color.Blue;
      this.btnView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnView_LinkClicked);
      // 
      // notificationIcon
      // 
      this.notificationIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
      this.notificationIcon.BalloonTipText = "Please confirm your current activity!";
      this.notificationIcon.BalloonTipTitle = "BUG: Input required";
      this.notificationIcon.ContextMenuStrip = this.contextMenu;
      this.notificationIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notificationIcon.Icon")));
      this.notificationIcon.Visible = true;
      this.notificationIcon.Click += new System.EventHandler(this.notificationIcon_Click);
      // 
      // contextMenu
      // 
      this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbInterval,
            this.separator,
            this.btnExit});
      this.contextMenu.Name = "contextMenuStrip1";
      this.contextMenu.Size = new System.Drawing.Size(213, 59);
      // 
      // cbInterval
      // 
      this.cbInterval.Items.AddRange(new object[] {
            "1 minute",
            "2 minutes",
            "3 minutes",
            "5 minutes",
            "10 minutes",
            "15 minutes",
            "30 minutes",
            "60 minutes"});
      this.cbInterval.Name = "cbInterval";
      this.cbInterval.Size = new System.Drawing.Size(152, 23);
      this.cbInterval.Text = "Choose bug interval...";
      this.cbInterval.SelectedIndexChanged += new System.EventHandler(this.cbInterval_SelectedIndexChanged);
      // 
      // separator
      // 
      this.separator.Name = "separator";
      this.separator.Size = new System.Drawing.Size(209, 6);
      // 
      // btnExit
      // 
      this.btnExit.Image = global::Bug.Properties.Resources.clock_small;
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(212, 22);
      this.btnExit.Text = "Exit";
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // lblReference
      // 
      this.lblReference.AutoSize = true;
      this.lblReference.Location = new System.Drawing.Point(113, 106);
      this.lblReference.Name = "lblReference";
      this.lblReference.Size = new System.Drawing.Size(14, 13);
      this.lblReference.TabIndex = 3;
      this.lblReference.Text = "#";
      // 
      // lblToday
      // 
      this.lblToday.AutoSize = true;
      this.lblToday.Location = new System.Drawing.Point(54, 16);
      this.lblToday.Name = "lblToday";
      this.lblToday.Size = new System.Drawing.Size(46, 13);
      this.lblToday.TabIndex = 5;
      this.lblToday.Text = "Today: -";
      // 
      // lblCurrent
      // 
      this.lblCurrent.AutoSize = true;
      this.lblCurrent.Location = new System.Drawing.Point(55, 31);
      this.lblCurrent.Name = "lblCurrent";
      this.lblCurrent.Size = new System.Drawing.Size(50, 13);
      this.lblCurrent.TabIndex = 6;
      this.lblCurrent.Text = "Current: -";
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 500;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // tbEntry
      // 
      this.tbEntry.Location = new System.Drawing.Point(12, 79);
      this.tbEntry.Name = "tbEntry";
      this.tbEntry.Size = new System.Drawing.Size(160, 20);
      this.tbEntry.TabIndex = 1;
      this.tbEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEntry_KeyPress);
      // 
      // tbReference
      // 
      this.tbReference.Location = new System.Drawing.Point(129, 103);
      this.tbReference.Name = "tbReference";
      this.tbReference.Size = new System.Drawing.Size(43, 20);
      this.tbReference.TabIndex = 2;
      this.tbReference.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReference_KeyPress);
      // 
      // borderTop
      // 
      this.borderTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.borderTop.Image = global::Bug.Properties.Resources.border_gray;
      this.borderTop.Location = new System.Drawing.Point(0, 64);
      this.borderTop.Name = "borderTop";
      this.borderTop.Size = new System.Drawing.Size(184, 1);
      this.borderTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.borderTop.TabIndex = 3;
      this.borderTop.TabStop = false;
      // 
      // logo
      // 
      this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
      this.logo.Location = new System.Drawing.Point(14, 14);
      this.logo.Name = "logo";
      this.logo.Size = new System.Drawing.Size(32, 32);
      this.logo.TabIndex = 4;
      this.logo.TabStop = false;
      // 
      // Popup
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(184, 184);
      this.ControlBox = false;
      this.Controls.Add(this.lblCurrent);
      this.Controls.Add(this.lblToday);
      this.Controls.Add(this.borderTop);
      this.Controls.Add(this.logo);
      this.Controls.Add(this.tbEntry);
      this.Controls.Add(this.lblReference);
      this.Controls.Add(this.panel);
      this.Controls.Add(this.tbReference);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximumSize = new System.Drawing.Size(200, 200);
      this.MinimumSize = new System.Drawing.Size(200, 200);
      this.Name = "Popup";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.TopMost = true;
      this.Deactivate += new System.EventHandler(this.Popup_Deactivate);
      this.Load += new System.EventHandler(this.Popup_Load);
      this.panel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.borderBottom)).EndInit();
      this.contextMenu.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.borderTop)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel;
    private System.Windows.Forms.PictureBox borderBottom;
    private System.Windows.Forms.LinkLabel btnView;
    private System.Windows.Forms.NotifyIcon notificationIcon;
    private System.Windows.Forms.ContextMenuStrip contextMenu;
    private System.Windows.Forms.ToolStripComboBox cbInterval;
    private System.Windows.Forms.ToolStripSeparator separator;
    private System.Windows.Forms.ToolStripMenuItem btnExit;
    private System.Windows.Forms.Label lblReference;
    private System.Windows.Forms.PictureBox borderTop;
    private System.Windows.Forms.PictureBox logo;
    private System.Windows.Forms.Label lblToday;
    private System.Windows.Forms.Label lblCurrent;
    private SelectionTextBox tbEntry;
    private SelectionTextBox tbReference;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.LinkLabel btnHide;
  }
}