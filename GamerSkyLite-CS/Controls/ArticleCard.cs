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
using System.Net;

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
        public string PublishTime
        {
            get => PublishTimeLabel.Text;
            set => PublishTimeLabel.Text = value;
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
                    if (File.Exists(value))
                    {
                        UnityModule.DebugPrint("文章[{0}]目录图像存在，尝试读入图像...", ArticleID);
                        //图像存在，尝试显示图像
                        using (FileStream ImageStream = new FileStream(value, FileMode.Open))
                        {
                            ImageLabel.Image = Image.FromStream(ImageStream);
                            ImageLabel.Text = string.Empty;
                        }
                    }
                    else
                    {
                        UnityModule.DebugPrint("文章[{0}]目录图像不存在，尝试下载图像...", ArticleID);
                        //图像不存在，尝试下载图像
                        if (ImageLink == string.Empty) throw new Exception("图像下载连接为空");
                        using (WebClient ImageClient = new WebClient()
                        {
                            BaseAddress = ImageLink,
                        })
                        {
                            ImageClient.DownloadFileCompleted += new AsyncCompletedEventHandler((s,e)=> {
                                if (e.Cancelled) return;
                                if (e.Error == null)
                                {
                                    //异步下载成功，显示图像
                                    this.Invoke(new Action(()=> {
                                        try
                                        {
                                            using (FileStream ImageStream = new FileStream(value, FileMode.Open))
                                            {
                                                ImageLabel.Image = Image.FromStream(ImageStream);
                                                ImageLabel.Text = string.Empty;
                                                UnityModule.DebugPrint("文章[{0}]图像下载成功，尝试读入图像...", ArticleID);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            UnityModule.DebugPrint("文章[{0}]图像下载失败：{1}", ArticleID, ex.Message);
                                            ImageLabel.Text = ex.Message;
                                        }
                                    }));
                                }
                                else
                                {
                                    throw e.Error;
                                }
                            });
                            ImageClient.DownloadFileAsync(new Uri(ImageLink), value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    UnityModule.DebugPrint("文章[{0}]图像读入/下载失败：{1}", ArticleID, ex.Message);
                    ImageLabel.Text = ex.Message;
                }
            }
        }

        private string _articleLink = string.Empty;
        /// <summary>
        /// 文章链接
        /// </summary>
        public string ArticleLink
        {
            get => _articleLink;
            set => _articleLink = value;
        }

        private string _imageLink = string.Empty;
        /// <summary>
        /// 图像链接
        /// </summary>
        public string ImageLink
        {
            get => _imageLink;
            set => _imageLink = value;
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

        public ArticleCard(string articleID, string title = "", string description = "", string time = "", string imageLink = "", string imagePath="") : this()
        {
            ArticleID = articleID;
            Title = title;
            Description = description;
            PublishTime = time;
            ImageLink = imageLink;
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
            PublishTimeLabel.MouseEnter += CardMouseEnter;
            PublishTimeLabel.MouseLeave += CardMouseLeave;
        }

        #endregion

    }
}
