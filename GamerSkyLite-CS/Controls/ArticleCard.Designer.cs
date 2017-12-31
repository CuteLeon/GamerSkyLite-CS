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
            this.UnityLayoutPanel = new GamerSkyLite_CS.Controls.TableLayoutPanelEx();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.LocationButton = new LeonUI.Controls.ImageButton();
            this.BrowseButton = new LeonUI.Controls.ImageButton();
            this.imageButton2 = new LeonUI.Controls.ImageButton();
            this.UnityLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnityLayoutPanel
            // 
            this.UnityLayoutPanel.ColumnCount = 5;
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.Controls.Add(this.imageButton2, 4, 0);
            this.UnityLayoutPanel.Controls.Add(this.BrowseButton, 3, 0);
            this.UnityLayoutPanel.Controls.Add(this.TimeLabel, 1, 2);
            this.UnityLayoutPanel.Controls.Add(this.DescriptionLabel, 1, 1);
            this.UnityLayoutPanel.Controls.Add(this.ImageLabel, 0, 0);
            this.UnityLayoutPanel.Controls.Add(this.TitleLabel, 1, 0);
            this.UnityLayoutPanel.Controls.Add(this.LocationButton, 2, 0);
            this.UnityLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnityLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.UnityLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UnityLayoutPanel.Name = "UnityLayoutPanel";
            this.UnityLayoutPanel.RowCount = 3;
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.UnityLayoutPanel.Size = new System.Drawing.Size(640, 112);
            this.UnityLayoutPanel.TabIndex = 0;
            // 
            // ImageLabel
            // 
            this.ImageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.Location = new System.Drawing.Point(203, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(338, 32);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionLabel
            // 
            this.UnityLayoutPanel.SetColumnSpan(this.DescriptionLabel, 4);
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DescriptionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.DescriptionLabel.Location = new System.Drawing.Point(203, 32);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Padding = new System.Windows.Forms.Padding(3);
            this.DescriptionLabel.Size = new System.Drawing.Size(434, 60);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "Description";
            // 
            // TimeLabel
            // 
            this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeLabel.ForeColor = System.Drawing.Color.DimGray;
            this.TimeLabel.Image = global::GamerSkyLite_CS.UnityResource.ClockIcon;
            this.TimeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeLabel.Location = new System.Drawing.Point(203, 92);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Padding = new System.Windows.Forms.Padding(3);
            this.TimeLabel.Size = new System.Drawing.Size(338, 20);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "Time";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LocationButton
            // 
            this.LocationButton.AutoEllipsis = true;
            this.LocationButton.BackColor = System.Drawing.Color.Transparent;
            this.LocationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationButton.DownBitmap = global::GamerSkyLite_CS.UnityResource.Location_2;
            this.LocationButton.EnterBitmap = global::GamerSkyLite_CS.UnityResource.Location_1;
            this.LocationButton.ForeColor = System.Drawing.Color.White;
            this.LocationButton.Image = global::GamerSkyLite_CS.UnityResource.Location_0;
            this.LocationButton.Location = new System.Drawing.Point(547, 0);
            this.LocationButton.Name = "LocationButton";
            this.LocationButton.NormalBitmap = global::GamerSkyLite_CS.UnityResource.Location_0;
            this.LocationButton.Size = new System.Drawing.Size(26, 32);
            this.LocationButton.TabIndex = 4;
            this.LocationButton.Text = "imageButton1";
            this.LocationButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrowseButton
            // 
            this.BrowseButton.AutoEllipsis = true;
            this.BrowseButton.BackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseButton.DownBitmap = null;
            this.BrowseButton.EnterBitmap = null;
            this.BrowseButton.ForeColor = System.Drawing.Color.White;
            this.BrowseButton.Location = new System.Drawing.Point(579, 0);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.NormalBitmap = null;
            this.BrowseButton.Size = new System.Drawing.Size(26, 32);
            this.BrowseButton.TabIndex = 5;
            this.BrowseButton.Text = "imageButton1";
            this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageButton2
            // 
            this.imageButton2.AutoEllipsis = true;
            this.imageButton2.BackColor = System.Drawing.Color.Transparent;
            this.imageButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageButton2.DownBitmap = null;
            this.imageButton2.EnterBitmap = null;
            this.imageButton2.ForeColor = System.Drawing.Color.White;
            this.imageButton2.Location = new System.Drawing.Point(611, 0);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.NormalBitmap = null;
            this.imageButton2.Size = new System.Drawing.Size(26, 32);
            this.imageButton2.TabIndex = 6;
            this.imageButton2.Text = "imageButton1";
            this.imageButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Size = new System.Drawing.Size(640, 112);
            this.UnityLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GamerSkyLite_CS.Controls.TableLayoutPanelEx UnityLayoutPanel;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label TimeLabel;
        private LeonUI.Controls.ImageButton LocationButton;
        private LeonUI.Controls.ImageButton imageButton2;
        private LeonUI.Controls.ImageButton BrowseButton;
    }
}
