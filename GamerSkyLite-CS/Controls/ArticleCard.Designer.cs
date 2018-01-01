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
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.UnityLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnityLayoutPanel
            // 
            this.UnityLayoutPanel.ColumnCount = 6;
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.Controls.Add(this.TimeLabel, 1, 2);
            this.UnityLayoutPanel.Controls.Add(this.DescriptionLabel, 1, 1);
            this.UnityLayoutPanel.Controls.Add(this.ImageLabel, 0, 0);
            this.UnityLayoutPanel.Controls.Add(this.TitleLabel, 1, 0);
            this.UnityLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnityLayoutPanel.Location = new System.Drawing.Point(0, 3);
            this.UnityLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UnityLayoutPanel.Name = "UnityLayoutPanel";
            this.UnityLayoutPanel.RowCount = 3;
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UnityLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.UnityLayoutPanel.Size = new System.Drawing.Size(640, 112);
            this.UnityLayoutPanel.TabIndex = 0;
            // 
            // TimeLabel
            // 
            this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeLabel.ForeColor = System.Drawing.Color.DimGray;
            this.TimeLabel.Image = global::GamerSkyLite_CS.UnityResource.ClockIcon;
            this.TimeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeLabel.Location = new System.Drawing.Point(200, 92);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TimeLabel.Size = new System.Drawing.Size(172, 20);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "Time";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DescriptionLabel
            // 
            this.UnityLayoutPanel.SetColumnSpan(this.DescriptionLabel, 5);
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DescriptionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.DescriptionLabel.Location = new System.Drawing.Point(200, 32);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Padding = new System.Windows.Forms.Padding(5);
            this.DescriptionLabel.Size = new System.Drawing.Size(440, 60);
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
            this.TitleLabel.Location = new System.Drawing.Point(200, 0);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLabel.Size = new System.Drawing.Size(344, 32);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(640, 115);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ArticleCard_Paint);
            this.UnityLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GamerSkyLite_CS.Controls.TableLayoutPanelEx UnityLayoutPanel;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label TimeLabel;
    }
}
