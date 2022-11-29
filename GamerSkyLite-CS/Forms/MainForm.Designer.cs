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
            this.ReadedButton = new System.Windows.Forms.Label();
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
            this.TitlePanel.Controls.Add(this.ReadedButton);
            this.TitlePanel.Controls.Add(this.IconLabel);
            this.TitlePanel.Controls.Add(this.MinButton);
            this.TitlePanel.Controls.Add(this.RestoreButton);
            this.TitlePanel.Controls.Add(this.MaxButton);
            this.TitlePanel.Controls.Add(this.CloseButton);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(6, 6);
            this.TitlePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(988, 40);
            this.TitlePanel.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.Location = new System.Drawing.Point(40, 0);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.TitleLabel.Size = new System.Drawing.Size(761, 40);
            this.TitleLabel.TabIndex = 11;
            this.TitleLabel.Text = "GamerSky-Lite [需求才是第一生产力]";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadedButton
            // 
            this.ReadedButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ReadedButton.Image = global::GamerSkyLite_CS.UnityResource.Flag_0;
            this.ReadedButton.Location = new System.Drawing.Point(801, 0);
            this.ReadedButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReadedButton.Name = "ReadedButton";
            this.ReadedButton.Size = new System.Drawing.Size(35, 40);
            this.ReadedButton.TabIndex = 10;
            this.ReadedButton.Click += new System.EventHandler(this.ReadedButton_Click);
            // 
            // IconLabel
            // 
            this.IconLabel.AutoEllipsis = true;
            this.IconLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconLabel.Location = new System.Drawing.Point(0, 0);
            this.IconLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IconLabel.Name = "IconLabel";
            this.IconLabel.Size = new System.Drawing.Size(40, 40);
            this.IconLabel.TabIndex = 6;
            this.IconLabel.Click += new System.EventHandler(this.IconLabel_Click);
            // 
            // MinButton
            // 
            this.MinButton.BackColor = System.Drawing.Color.Transparent;
            this.MinButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinButton.BackgroundImage")));
            this.MinButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MinButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinButton.Location = new System.Drawing.Point(836, 0);
            this.MinButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MinButton.MaximumSize = new System.Drawing.Size(38, 38);
            this.MinButton.MinimumSize = new System.Drawing.Size(25, 25);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(38, 38);
            this.MinButton.TabIndex = 4;
            // 
            // RestoreButton
            // 
            this.RestoreButton.BackColor = System.Drawing.Color.Transparent;
            this.RestoreButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RestoreButton.BackgroundImage")));
            this.RestoreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RestoreButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RestoreButton.Location = new System.Drawing.Point(874, 0);
            this.RestoreButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.RestoreButton.MaximumSize = new System.Drawing.Size(38, 38);
            this.RestoreButton.MinimumSize = new System.Drawing.Size(25, 25);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(38, 38);
            this.RestoreButton.TabIndex = 3;
            this.RestoreButton.Visible = false;
            // 
            // MaxButton
            // 
            this.MaxButton.BackColor = System.Drawing.Color.Transparent;
            this.MaxButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MaxButton.BackgroundImage")));
            this.MaxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MaxButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaxButton.Location = new System.Drawing.Point(912, 0);
            this.MaxButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaxButton.MaximumSize = new System.Drawing.Size(38, 38);
            this.MaxButton.MinimumSize = new System.Drawing.Size(25, 25);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(38, 38);
            this.MaxButton.TabIndex = 2;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.Location = new System.Drawing.Point(950, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CloseButton.MaximumSize = new System.Drawing.Size(38, 38);
            this.CloseButton.MinimumSize = new System.Drawing.Size(25, 25);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(38, 38);
            this.CloseButton.TabIndex = 1;
            // 
            // LogPanel
            // 
            this.LogPanel.Controls.Add(this.LogTextBox);
            this.LogPanel.Controls.Add(this.SQLTextBox);
            this.LogPanel.Location = new System.Drawing.Point(81, 410);
            this.LogPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LogPanel.Size = new System.Drawing.Size(909, 334);
            this.LogPanel.TabIndex = 5;
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.White;
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(6, 33);
            this.LogTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(897, 295);
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
            this.SQLTextBox.Location = new System.Drawing.Point(6, 6);
            this.SQLTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SQLTextBox.Name = "SQLTextBox";
            this.SQLTextBox.Size = new System.Drawing.Size(897, 27);
            this.SQLTextBox.TabIndex = 5;
            this.SQLTextBox.Text = "输入SQL指令，按Enter键执行...";
            this.SQLTextBox.WordWrap = false;
            this.SQLTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SQLTextBox_KeyDown);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.CatalogLayoutPanel);
            this.MainPanel.Location = new System.Drawing.Point(81, 46);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(912, 356);
            this.MainPanel.TabIndex = 4;
            // 
            // CatalogLayoutPanel
            // 
            this.CatalogLayoutPanel.AutoScroll = true;
            this.CatalogLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.CatalogLayoutPanel.Location = new System.Drawing.Point(26, 16);
            this.CatalogLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CatalogLayoutPanel.Name = "CatalogLayoutPanel";
            this.CatalogLayoutPanel.Size = new System.Drawing.Size(650, 326);
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
            this.ControlPanel.Location = new System.Drawing.Point(6, 46);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.ControlPanel.Size = new System.Drawing.Size(75, 698);
            this.ControlPanel.TabIndex = 2;
            this.ControlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlPanel_Paint);
            this.ControlPanel.DoubleClick += new System.EventHandler(this.ControlPanel_DoubleClick);
            // 
            // GoBackButton
            // 
            this.GoBackButton.Image = global::GamerSkyLite_CS.UnityResource.GoBack_0;
            this.GoBackButton.Location = new System.Drawing.Point(6, 31);
            this.GoBackButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(62, 62);
            this.GoBackButton.TabIndex = 5;
            this.GoBackButton.Click += new System.EventHandler(this.GoBackButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = global::GamerSkyLite_CS.UnityResource.Refresh_0;
            this.RefreshButton.Location = new System.Drawing.Point(6, 105);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(62, 62);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.Image = global::GamerSkyLite_CS.UnityResource.Log_0;
            this.LogButton.Location = new System.Drawing.Point(6, 179);
            this.LogButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(62, 62);
            this.LogButton.TabIndex = 7;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.LogPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.TitlePanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(500, 52);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
        private Controls.FlowLayoutPanelEx ControlPanel;
        private Controls.FlowLayoutPanelEx CatalogLayoutPanel;
        private System.Windows.Forms.Label GoBackButton;
        private System.Windows.Forms.Label RefreshButton;
        private Controls.PanelEx MainPanel;
        private System.Windows.Forms.Label LogButton;
        private Controls.PanelEx LogPanel;
        public System.Windows.Forms.TextBox SQLTextBox;
        public System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Label ReadedButton;
        private System.Windows.Forms.Label TitleLabel;
    }
}

