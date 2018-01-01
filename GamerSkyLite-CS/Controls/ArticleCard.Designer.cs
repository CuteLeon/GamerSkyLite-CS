namespace GamerSkyLite_CS.Controls
{
    partial class ArticleCard
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleCard));
            this.UnityLayoutPanel = new GamerSkyLite_CS.Controls.TableLayoutPanelEx();
            this.StateLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Label();
            this.PublishTimeLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.LocationButton = new System.Windows.Forms.Label();
            this.DownloadButton = new LeonUI.Controls.RoundedButton();
            this.UnityLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnityLayoutPanel
            // 
            this.UnityLayoutPanel.ColumnCount = 6;
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.UnityLayoutPanel.Controls.Add(this.StateLabel, 2, 2);
            this.UnityLayoutPanel.Controls.Add(this.DeleteButton, 5, 0);
            this.UnityLayoutPanel.Controls.Add(this.BrowseButton, 4, 0);
            this.UnityLayoutPanel.Controls.Add(this.PublishTimeLabel, 1, 2);
            this.UnityLayoutPanel.Controls.Add(this.DescriptionLabel, 1, 1);
            this.UnityLayoutPanel.Controls.Add(this.ImageLabel, 0, 0);
            this.UnityLayoutPanel.Controls.Add(this.TitleLabel, 1, 0);
            this.UnityLayoutPanel.Controls.Add(this.LocationButton, 3, 0);
            this.UnityLayoutPanel.Controls.Add(this.DownloadButton, 3, 2);
            this.UnityLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnityLayoutPanel.Location = new System.Drawing.Point(0, 3);
            this.UnityLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UnityLayoutPanel.Name = "UnityLayoutPanel";
            this.UnityLayoutPanel.RowCount = 3;
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.UnityLayoutPanel.Size = new System.Drawing.Size(680, 112);
            this.UnityLayoutPanel.TabIndex = 0;
            // 
            // StateLabel
            // 
            this.StateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StateLabel.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.StateLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StateLabel.Image = global::GamerSkyLite_CS.UnityResource.DownloadIcon;
            this.StateLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StateLabel.Location = new System.Drawing.Point(354, 83);
            this.StateLabel.Margin = new System.Windows.Forms.Padding(1);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.StateLabel.Size = new System.Drawing.Size(227, 28);
            this.StateLabel.TabIndex = 8;
            this.StateLabel.Text = "State";
            this.StateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteButton.Image = global::GamerSkyLite_CS.UnityResource.Delete_0;
            this.DeleteButton.Location = new System.Drawing.Point(648, 2);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(30, 28);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseButton.Image = global::GamerSkyLite_CS.UnityResource.Browser_0;
            this.BrowseButton.Location = new System.Drawing.Point(616, 2);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(28, 28);
            this.BrowseButton.TabIndex = 5;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PublishTimeLabel
            // 
            this.PublishTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PublishTimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PublishTimeLabel.ForeColor = System.Drawing.Color.DimGray;
            this.PublishTimeLabel.Image = global::GamerSkyLite_CS.UnityResource.ClockIcon;
            this.PublishTimeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PublishTimeLabel.Location = new System.Drawing.Point(201, 83);
            this.PublishTimeLabel.Margin = new System.Windows.Forms.Padding(1);
            this.PublishTimeLabel.Name = "PublishTimeLabel";
            this.PublishTimeLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PublishTimeLabel.Size = new System.Drawing.Size(151, 28);
            this.PublishTimeLabel.TabIndex = 3;
            this.PublishTimeLabel.Text = "Time";
            this.PublishTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoEllipsis = true;
            this.UnityLayoutPanel.SetColumnSpan(this.DescriptionLabel, 5);
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.DescriptionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.DescriptionLabel.Location = new System.Drawing.Point(201, 33);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(1);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Padding = new System.Windows.Forms.Padding(2);
            this.DescriptionLabel.Size = new System.Drawing.Size(478, 48);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "Description";
            // 
            // ImageLabel
            // 
            this.ImageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.ImageLabel.Location = new System.Drawing.Point(0, 0);
            this.ImageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ImageLabel.Name = "ImageLabel";
            this.UnityLayoutPanel.SetRowSpan(this.ImageLabel, 3);
            this.ImageLabel.Size = new System.Drawing.Size(200, 112);
            this.ImageLabel.TabIndex = 0;
            this.ImageLabel.Text = "正在下载图像...";
            this.ImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.UnityLayoutPanel.SetColumnSpan(this.TitleLabel, 2);
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.Location = new System.Drawing.Point(201, 1);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(1);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.TitleLabel.Size = new System.Drawing.Size(380, 30);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LocationButton
            // 
            this.LocationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationButton.Image = global::GamerSkyLite_CS.UnityResource.Location_0;
            this.LocationButton.Location = new System.Drawing.Point(584, 2);
            this.LocationButton.Margin = new System.Windows.Forms.Padding(2);
            this.LocationButton.Name = "LocationButton";
            this.LocationButton.Size = new System.Drawing.Size(28, 28);
            this.LocationButton.TabIndex = 4;
            this.LocationButton.Click += new System.EventHandler(this.LocationButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.AutoEllipsis = true;
            this.DownloadButton.BackColor = System.Drawing.Color.Transparent;
            this.DownloadButton.CenterRectangle = new System.Drawing.Rectangle(17, 16, 70, 2);
            this.UnityLayoutPanel.SetColumnSpan(this.DownloadButton, 3);
            this.DownloadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownloadButton.DownBitmap = ((System.Drawing.Bitmap)(resources.GetObject("DownloadButton.DownBitmap")));
            this.DownloadButton.EnterBitmap = ((System.Drawing.Bitmap)(resources.GetObject("DownloadButton.EnterBitmap")));
            this.DownloadButton.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.DownloadButton.Image = ((System.Drawing.Image)(resources.GetObject("DownloadButton.Image")));
            this.DownloadButton.Location = new System.Drawing.Point(585, 82);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.NormalBitmap = ((System.Drawing.Bitmap)(resources.GetObject("DownloadButton.NormalBitmap")));
            this.DownloadButton.Size = new System.Drawing.Size(92, 30);
            this.DownloadButton.TabIndex = 7;
            this.DownloadButton.Text = "下载";
            this.DownloadButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ArticleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.UnityLayoutPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ArticleCard";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.Size = new System.Drawing.Size(680, 120);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ArticleCard_Paint);
            this.UnityLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GamerSkyLite_CS.Controls.TableLayoutPanelEx UnityLayoutPanel;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label PublishTimeLabel;
        private System.Windows.Forms.Label LocationButton;
        private System.Windows.Forms.Label DeleteButton;
        private System.Windows.Forms.Label BrowseButton;
        private LeonUI.Controls.RoundedButton DownloadButton;
        private System.Windows.Forms.Label StateLabel;
    }
}
