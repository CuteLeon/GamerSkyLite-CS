namespace GamerSkyLite_CS
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.IconLabel = new System.Windows.Forms.Label();
            this.MinButton = new LeonUI.TitleButtons.MinButton();
            this.RestoreButton = new LeonUI.TitleButtons.RestoreButton();
            this.MaxButton = new LeonUI.TitleButtons.MaxButton();
            this.CloseButton = new LeonUI.TitleButtons.CloseButton();
            this.LogPanel = new GamerSkyLite_CS.Controls.PanelEx();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.SQLTextBox = new System.Windows.Forms.TextBox();
            this.MainPanel = new GamerSkyLite_CS.Controls.PanelEx();
            this.CatalogLayoutPanel = new GamerSkyLite_CS.Controls.FlowLayoutPanelEx();
            this.ControlPanel = new GamerSkyLite_CS.Controls.FlowLayoutPanelEx();
            this.GoBackButton = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Label();
            this.LogButton = new System.Windows.Forms.Label();
            this.TitlePanel.SuspendLayout();
            this.LogPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Controls.Add(this.IconLabel);
            this.TitlePanel.Controls.Add(this.MinButton);
            this.TitlePanel.Controls.Add(this.RestoreButton);
            this.TitlePanel.Controls.Add(this.MaxButton);
            this.TitlePanel.Controls.Add(this.CloseButton);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(5, 5);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(790, 32);
            this.TitlePanel.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.Location = new System.Drawing.Point(32, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.TitleLabel.Size = new System.Drawing.Size(638, 32);
            this.TitleLabel.TabIndex = 7;
            this.TitleLabel.Text = "GamerSky-Lite [需求才是第一生产力]";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IconLabel
            // 
            this.IconLabel.AutoEllipsis = true;
            this.IconLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconLabel.Location = new System.Drawing.Point(0, 0);
            this.IconLabel.Name = "IconLabel";
            this.IconLabel.Size = new System.Drawing.Size(32, 32);
            this.IconLabel.TabIndex = 6;
            this.IconLabel.Click += new System.EventHandler(this.IconLabel_Click);
            // 
            // MinButton
            // 
            this.MinButton.BackColor = System.Drawing.Color.Transparent;
            this.MinButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinButton.BackgroundImage")));
            this.MinButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MinButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinButton.Location = new System.Drawing.Point(670, 0);
            this.MinButton.MaximumSize = new System.Drawing.Size(30, 30);
            this.MinButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(30, 30);
            this.MinButton.TabIndex = 4;
            // 
            // RestoreButton
            // 
            this.RestoreButton.BackColor = System.Drawing.Color.Transparent;
            this.RestoreButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RestoreButton.BackgroundImage")));
            this.RestoreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RestoreButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RestoreButton.Location = new System.Drawing.Point(700, 0);
            this.RestoreButton.MaximumSize = new System.Drawing.Size(30, 30);
            this.RestoreButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(30, 30);
            this.RestoreButton.TabIndex = 3;
            this.RestoreButton.Visible = false;
            // 
            // MaxButton
            // 
            this.MaxButton.BackColor = System.Drawing.Color.Transparent;
            this.MaxButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MaxButton.BackgroundImage")));
            this.MaxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MaxButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaxButton.Location = new System.Drawing.Point(730, 0);
            this.MaxButton.MaximumSize = new System.Drawing.Size(30, 30);
            this.MaxButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(30, 30);
            this.MaxButton.TabIndex = 2;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.Location = new System.Drawing.Point(760, 0);
            this.CloseButton.MaximumSize = new System.Drawing.Size(30, 30);
            this.CloseButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 1;
            // 
            // LogPanel
            // 
            this.LogPanel.Controls.Add(this.LogTextBox);
            this.LogPanel.Controls.Add(this.SQLTextBox);
            this.LogPanel.Location = new System.Drawing.Point(65, 328);
            this.LogPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Padding = new System.Windows.Forms.Padding(5);
            this.LogPanel.Size = new System.Drawing.Size(727, 267);
            this.LogPanel.TabIndex = 5;
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.White;
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(5, 27);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(717, 235);
            this.LogTextBox.TabIndex = 6;
            this.LogTextBox.WordWrap = false;
            // 
            // SQLTextBox
            // 
            this.SQLTextBox.BackColor = System.Drawing.Color.White;
            this.SQLTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SQLTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SQLTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SQLTextBox.ForeColor = System.Drawing.Color.OrangeRed;
            this.SQLTextBox.Location = new System.Drawing.Point(5, 5);
            this.SQLTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SQLTextBox.Name = "SQLTextBox";
            this.SQLTextBox.Size = new System.Drawing.Size(717, 22);
            this.SQLTextBox.TabIndex = 5;
            this.SQLTextBox.Text = "输入SQL指令，按Enter键执行...";
            this.SQLTextBox.WordWrap = false;
            this.SQLTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SQLTextBox_KeyDown);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.CatalogLayoutPanel);
            this.MainPanel.Location = new System.Drawing.Point(65, 37);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(730, 285);
            this.MainPanel.TabIndex = 4;
            // 
            // CatalogLayoutPanel
            // 
            this.CatalogLayoutPanel.AutoScroll = true;
            this.CatalogLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.CatalogLayoutPanel.Location = new System.Drawing.Point(21, 13);
            this.CatalogLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CatalogLayoutPanel.Name = "CatalogLayoutPanel";
            this.CatalogLayoutPanel.Size = new System.Drawing.Size(520, 261);
            this.CatalogLayoutPanel.TabIndex = 3;
            this.CatalogLayoutPanel.WrapContents = false;
            this.CatalogLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.CatalogLayoutPanel_Paint);
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.GoBackButton);
            this.ControlPanel.Controls.Add(this.RefreshButton);
            this.ControlPanel.Controls.Add(this.LogButton);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlPanel.Location = new System.Drawing.Point(5, 37);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.ControlPanel.Size = new System.Drawing.Size(60, 558);
            this.ControlPanel.TabIndex = 2;
            this.ControlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlPanel_Paint);
            this.ControlPanel.DoubleClick += new System.EventHandler(this.ControlPanel_DoubleClick);
            // 
            // GoBackButton
            // 
            this.GoBackButton.Image = global::GamerSkyLite_CS.UnityResource.GoBack_0;
            this.GoBackButton.Location = new System.Drawing.Point(5, 25);
            this.GoBackButton.Margin = new System.Windows.Forms.Padding(5);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(50, 50);
            this.GoBackButton.TabIndex = 5;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = global::GamerSkyLite_CS.UnityResource.Refresh_0;
            this.RefreshButton.Location = new System.Drawing.Point(5, 85);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(5);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(50, 50);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.Image = global::GamerSkyLite_CS.UnityResource.Log_0;
            this.LogButton.Location = new System.Drawing.Point(5, 145);
            this.LogButton.Margin = new System.Windows.Forms.Padding(5);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(50, 50);
            this.LogButton.TabIndex = 7;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.LogPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.TitlePanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 42);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GamerSky-Lite [需求才是第一生产力]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.TitlePanel.ResumeLayout(false);
            this.LogPanel.ResumeLayout(false);
            this.LogPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private LeonUI.TitleButtons.MinButton MinButton;
        private LeonUI.TitleButtons.RestoreButton RestoreButton;
        private LeonUI.TitleButtons.MaxButton MaxButton;
        private LeonUI.TitleButtons.CloseButton CloseButton;
        private System.Windows.Forms.Label IconLabel;
        private System.Windows.Forms.Label TitleLabel;
        private Controls.FlowLayoutPanelEx ControlPanel;
        private Controls.FlowLayoutPanelEx CatalogLayoutPanel;
        private System.Windows.Forms.Label GoBackButton;
        private System.Windows.Forms.Label RefreshButton;
        private Controls.PanelEx MainPanel;
        private System.Windows.Forms.Label LogButton;
        private Controls.PanelEx LogPanel;
        public System.Windows.Forms.TextBox SQLTextBox;
        public System.Windows.Forms.TextBox LogTextBox;
    }
}

