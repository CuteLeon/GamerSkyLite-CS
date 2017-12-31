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
            this.CloseButton = new LeonUI.TitleButtons.CloseButton();
            this.MaxButton = new LeonUI.TitleButtons.MaxButton();
            this.RestoreButton = new LeonUI.TitleButtons.RestoreButton();
            this.MinButton = new LeonUI.TitleButtons.MinButton();
            this.IconLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitlePanel.SuspendLayout();
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
            this.TitlePanel.Size = new System.Drawing.Size(630, 32);
            this.TitlePanel.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.Location = new System.Drawing.Point(600, 0);
            this.CloseButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 32);
            this.CloseButton.TabIndex = 1;
            // 
            // MaxButton
            // 
            this.MaxButton.BackColor = System.Drawing.Color.Transparent;
            this.MaxButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MaxButton.BackgroundImage")));
            this.MaxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MaxButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaxButton.Location = new System.Drawing.Point(570, 0);
            this.MaxButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(30, 32);
            this.MaxButton.TabIndex = 2;
            // 
            // RestoreButton
            // 
            this.RestoreButton.BackColor = System.Drawing.Color.Transparent;
            this.RestoreButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RestoreButton.BackgroundImage")));
            this.RestoreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RestoreButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RestoreButton.Location = new System.Drawing.Point(540, 0);
            this.RestoreButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(30, 32);
            this.RestoreButton.TabIndex = 3;
            this.RestoreButton.Visible = false;
            // 
            // MinButton
            // 
            this.MinButton.BackColor = System.Drawing.Color.Transparent;
            this.MinButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinButton.BackgroundImage")));
            this.MinButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MinButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinButton.Location = new System.Drawing.Point(510, 0);
            this.MinButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(30, 32);
            this.MinButton.TabIndex = 4;
            // 
            // IconLabel
            // 
            this.IconLabel.AutoEllipsis = true;
            this.IconLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconLabel.Location = new System.Drawing.Point(0, 0);
            this.IconLabel.Name = "IconLabel";
            this.IconLabel.Size = new System.Drawing.Size(32, 32);
            this.IconLabel.TabIndex = 6;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.Location = new System.Drawing.Point(32, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.TitleLabel.Size = new System.Drawing.Size(478, 32);
            this.TitleLabel.TabIndex = 7;
            this.TitleLabel.Text = "GamerSky-Lite [需求才是第一生产力]";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 540);
            this.Controls.Add(this.TitlePanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(400, 42);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GamerSky-Lite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.TitlePanel.ResumeLayout(false);
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
    }
}

