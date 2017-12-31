using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GamerSkyLite_CS.Controls;
using System.IO;

namespace GamerSkyLite_CS.Controls
{
    public partial class ArticleCard : UserControl
    {
        #region 属性字段
        private string _articleID = string.Empty;
        /// <summary>
        /// 文章ID
        /// </summary>
        public string ArticleID
        {
            get => _articleID;
            set
            {
                _articleID = value;
            }
        }

        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title
        {
            get => TitleLabel.Text;
            set => TitleLabel.Text = value;
        }

        /// <summary>
        /// 文章描述
        /// </summary>
        public string Description
        {
            get => DescriptionLabel.Text;
            set => DescriptionLabel.Text = value;
        }

        /// <summary>
        /// 文章时间
        /// </summary>
        public string Time
        {
            get => TimeLabel.Text;
            set => TimeLabel.Text = value;
        }

        private string _imagePath = string.Empty;
        /// <summary>
        /// 图像路径
        /// </summary>
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                //非占用读取预览图像
                try
                {
                    using (FileStream ImageStream = new FileStream(value, FileMode.Open))
                    {
                        ImageLabel.Image = Image.FromStream(ImageStream);
                    }
                }
                catch (Exception ex)
                {
                    ImageLabel.Text = ex.Message;
                }
            }
        }

        #endregion

        #region 私有变量

        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        EventHandler CardMouseEnter;

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        EventHandler CardMouseLeave;

        #endregion

        public ArticleCard()
        {
            InitializeComponent();
            AttachEvent();
        }

        public ArticleCard(string articleID, string title="", string description="", string time="", string imagePath="") : this()
        {
            ArticleID = articleID;
            Title = title;
            Description = description;
            Time = time;
            ImagePath = imagePath;
        }

        private void ArticleCard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, 0, 0, this.Width - 1, 3);
        }

        #region 功能函数

        /// <summary>
        /// 初始化控件事件绑定
        /// </summary>
        private void AttachEvent()
        {
            CardMouseEnter = new EventHandler((s,e)=> {
                TitleLabel.ForeColor = Color.OrangeRed;
            });
            CardMouseLeave = new EventHandler((s, e) => {
                //TODO:新加入的文章，使用深空蓝
                TitleLabel.ForeColor = Color.Black;
            });

            this.MouseEnter += CardMouseEnter;
            UnityLayoutPanel.MouseEnter += CardMouseEnter;
            this.MouseLeave += CardMouseLeave;
            UnityLayoutPanel.MouseLeave += CardMouseLeave;
            TitleLabel.MouseEnter += CardMouseEnter;
            TitleLabel.MouseLeave += CardMouseLeave;
            ImageLabel.MouseEnter += CardMouseEnter;
            ImageLabel.MouseLeave += CardMouseLeave;
            DescriptionLabel.MouseEnter += CardMouseEnter;
            DescriptionLabel.MouseLeave += CardMouseLeave;
            TimeLabel.MouseEnter += CardMouseEnter;
            TimeLabel.MouseLeave += CardMouseLeave;
        }

        #endregion

    }
}
