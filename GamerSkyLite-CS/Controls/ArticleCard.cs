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
using System.Diagnostics;
using GamerSkyLite_CS.Controller;

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
                DownloadDirectory = FileController.PathCombine(UnityModule.ContentDirectory, value);
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

        /// <summary>
        /// 下载目录
        /// </summary>
        private string DownloadDirectory = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        public enum StateEnum
        {
            /// <summary>
            /// 初始状态
            /// </summary>
            None=0,
            /// <summary>
            /// 正在分析
            /// </summary>
            Analysing=1,
            /// <summary>
            /// 正在下载
            /// </summary>
            Downloading=2,
            /// <summary>
            /// 暂停
            /// </summary>
            Pause=3,
            /// <summary>
            /// 下载结束
            /// </summary>
            Finish=4,
        }
        private StateEnum _state = StateEnum.None;
        /// <summary>
        /// 状态
        /// </summary>
        public StateEnum State
        {
            get => _state;
            set
            {
                _state = value;

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

        EventHandler ButtonMouseEnter;
        MouseEventHandler ButtonMouseDown;
        MouseEventHandler ButtonMouseUp;
        EventHandler ButtonMouseLeave;

        #endregion

        public ArticleCard()
        {
            InitializeComponent();
            InitializeControl();
            AttachEvent();

            if (Directory.Exists(DownloadDirectory))
            {
                StateLabel.Text = string.Format("已下载文件数：{0}", Directory.GetFiles(DownloadDirectory));
            }
            else
            {
                StateLabel.Text = "爸爸，点旁边的按钮开始下载...";
            }
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
            e.Graphics.FillRectangle(Brushes.SkyBlue, 0, UnityLayoutPanel.Bottom, this.Width - 1, this.Padding.Bottom);
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

            ButtonMouseEnter = new EventHandler((s,e)=> {(s as Label).ImageIndex = 1;});
            ButtonMouseDown = new MouseEventHandler((s,e)=> {(s as Label).ImageIndex = 0;});
            ButtonMouseUp = new MouseEventHandler((s,e)=> {(s as Label).ImageIndex = 1;});
            ButtonMouseLeave = new EventHandler((s,e)=> {(s as Label).ImageIndex = 0;});

            LocationButton.MouseEnter += ButtonMouseEnter;
            BrowseButton.MouseEnter += ButtonMouseEnter;
            DeleteButton.MouseEnter += ButtonMouseEnter;

            LocationButton.MouseDown += ButtonMouseDown;
            BrowseButton.MouseDown += ButtonMouseDown;
            DeleteButton.MouseDown += ButtonMouseDown;

            LocationButton.MouseUp += ButtonMouseUp;
            BrowseButton.MouseUp += ButtonMouseUp;
            DeleteButton.MouseUp += ButtonMouseUp;

            LocationButton.MouseLeave += ButtonMouseLeave;
            BrowseButton.MouseLeave += ButtonMouseLeave;
            DeleteButton.MouseLeave += ButtonMouseLeave;

        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitializeControl()
        {
            LocationButton.ImageList = new ImageList
            {
                ImageSize = new Size(28, 28)
            };
            LocationButton.ImageList.Images.Add(UnityResource.Location_0);
            LocationButton.ImageList.Images.Add(UnityResource.Location_1);
            LocationButton.ImageIndex = 0;

            BrowseButton.ImageList = new ImageList()
            {
                ImageSize = new Size(28, 28)
            };
            BrowseButton.ImageList.Images.Add(UnityResource.Browser_0);
            BrowseButton.ImageList.Images.Add(UnityResource.Browser_1);
            BrowseButton.ImageIndex = 0;

            DeleteButton.ImageList = new ImageList()
            {
                ImageSize = new Size(28, 28)
            };
            DeleteButton.ImageList.Images.Add(UnityResource.Delete_0);
            DeleteButton.ImageList.Images.Add(UnityResource.Delete_1);
            DeleteButton.ImageIndex = 0;
        }

        #endregion

        private void LocationButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(DownloadDirectory)) Process.Start(DownloadDirectory);

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            Process.Start(ArticleLink);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(DownloadDirectory)) return;
            foreach (string FilePath in Directory.GetFiles(DownloadDirectory))
                try { File.Delete(FilePath); } catch { }
            try { Directory.Delete(DownloadDirectory); } catch { }

            if (Directory.Exists(DownloadDirectory)) ;
            //TODO:显示目录内文件总数
        }

    }
}
