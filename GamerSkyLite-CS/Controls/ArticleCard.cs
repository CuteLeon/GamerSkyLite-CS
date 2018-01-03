﻿using System;
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
using System.Threading;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace GamerSkyLite_CS.Controls
{
    //TODO:启动时计算是否已经缓存文章，已经缓存的要区别显示
    //TODO:新加入的文章要区别显示
    
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
            set
            {
                TitleLabel.Text = value;
                ArticleFilePath = FileController.PathCombine(DownloadDirectory, value);
            }
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
                if (File.Exists(value))
                {
                    UnityModule.DebugPrint("文章[{0}]目录图像存在，尝试读入图像...", ArticleID);
                    //图像存在，尝试显示图像
                    try
                    {
                        //非占用读取预览图像
                        using (FileStream ImageStream = new FileStream(value, FileMode.Open))
                        {
                            ImageLabel.Image = Image.FromStream(ImageStream);
                            ImageLabel.Text = string.Empty;
                        }
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex)
                    {
                        UnityModule.DebugPrint("文章[{0}]图像读入失败：{1}", ArticleID, ex.Message);
                        ImageLabel.Text = ex.Message;
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
                        Encoding = Encoding.UTF8,
                    })
                    {
                        try
                        {
                            ImageClient.DownloadFileCompleted += new AsyncCompletedEventHandler((s,e)=> {
                                try
                                {
                                    UnityModule.DebugPrint("图像下载完成：{0}", value);
                                    if (e.Cancelled) return;
                                    if (e.Error == null)
                                    {
                                        //异步下载成功，显示图像
                                        this.Invoke(new Action(() => {
                                            try
                                            {
                                                using (FileStream ImageStream = new FileStream(value, FileMode.Open))
                                                {
                                                    ImageLabel.Image = Image.FromStream(ImageStream);
                                                    ImageLabel.Text = string.Empty;
                                                    UnityModule.DebugPrint("文章[{0}]图像下载成功，尝试读入图像...", ArticleID);
                                                }
                                            }
                                            catch (ThreadAbortException) { }
                                            catch (Exception ex)
                                            {
                                                UnityModule.DebugPrint("文章[{0}]图像下载后读入失败：{1}", ArticleID, ex.Message);
                                                ImageLabel.Text = ex.Message;
                                            }
                                        }));
                                    }
                                    else
                                    {
                                        UnityModule.DebugPrint("文章[{0}]图像完成，发现错误：{1}", ArticleID, e.Error.Message);
                                        throw e.Error;
                                    }
                                }
                                catch (ThreadAbortException) { }
                                catch (IOException) { }
                                catch (Exception) { }
                            });
                            ImageClient.DownloadFileAsync(new Uri(ImageLink), value);
                        }
                        catch (ThreadAbortException) { }
                        catch (Exception ex)
                        {
                            UnityModule.DebugPrint("文章[{0}]图像下载失败：{1}", ArticleID, ex.Message);
                            ImageLabel.Text = ex.Message;
                        }
                    }
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
        /// 文章文件路径
        /// </summary>
        private string ArticleFilePath = string.Empty;
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
            /// 分析完成
            /// </summary>
            AnalyseFinish = 2,
            /// <summary>
            /// 正在下载
            /// </summary>
            Downloading=3,
            /// <summary>
            /// 下载完成
            /// </summary>
            DownloadFinish = 4,
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
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        _state = value;
                        switch (value)
                        {
                            case StateEnum.None:
                                {
                                    DownloadArticleThread?.Abort();
                                    DownloadArticleThread = null;
                                    AnalyseArticleThread?.Abort();
                                    AnalyseArticleThread = null;

                                    DownloadButton.Text = "下载";
                                    break;
                                }
                            case StateEnum.Analysing:
                                {
                                    PageIndex = 1;
                                    ContentIndex = 1;

                                    StateLabel.Text = "正在分析文章...";
                                    StateLabel.ForeColor = Color.DeepSkyBlue;
                                    DownloadButton.Text = "取消";

                                    AnalyseArticleThread = new Thread(new ThreadStart(() =>
                                    {
                                        try
                                        {
                                            AnalyseArticle(ArticleLink);
                                            State = StateEnum.Downloading;
                                        }
                                        catch (ThreadAbortException) { }
                                        catch (IOException) { }
                                        catch (Exception ex)
                                        {
                                            try
                                            {
                                                this.Invoke(new Action(() =>
                                                {
                                                    StateLabel.Text = ex.Message;
                                                    StateLabel.ForeColor = Color.OrangeRed;
                                                }));
                                                State = StateEnum.None;
                                            }
                                            catch (IOException) { }
                                        }
                                    }));
                                    AnalyseArticleThread.Start();
                                    break;
                                }
                            case StateEnum.AnalyseFinish:
                                {
                                    ContentIndex = 0;
                                    ErrorCount = 0;
                                    ContentCount = 0;

                                    DownloadArticleThread?.Abort();
                                    DownloadArticleThread = null;
                                    DownloadButton.Text = "继续";
                                    break;
                                }
                            case StateEnum.Downloading:
                                {
                                    ContentIndex = 0;
                                    lock (UnityModule.UnityDBController)
                                    {
                                        ContentCount = Convert.ToInt32(UnityModule.UnityDBController.ExecuteScalar("SELECT COUNT(ContentID) FROM ArticleBase WHERE ArticleID='{0}'", ArticleID));
                                    }

                                    StateLabel.Text = "正在下载文章...";
                                    StateLabel.ForeColor = Color.DeepSkyBlue;
                                    DownloadButton.Text = "取消";

                                    DownloadArticleThread = new Thread(new ThreadStart(() =>
                                    {
                                        try
                                        {
                                            DownloadArticle();
                                            ExportArticle();
                                            State = StateEnum.DownloadFinish;
                                        }
                                        catch (ThreadAbortException) { }
                                        catch (Exception ex)
                                        {
                                            try
                                            {
                                                this.Invoke(new Action(() =>
                                                {
                                                    StateLabel.Text = ex.Message;
                                                    StateLabel.ForeColor = Color.OrangeRed;
                                                }));
                                                State = StateEnum.AnalyseFinish;
                                            }
                                            catch (IOException) { }
                                        }
                                    }));
                                    DownloadArticleThread.Start();
                                    break;
                                }
                            case StateEnum.DownloadFinish:
                                {
                                    if (ErrorCount > 0)
                                    {
                                        StateLabel.ForeColor = Color.Orange;
                                        StateLabel.Text = string.Format("下载完成，共 {0} 个文件 / {1} 个失败", ContentCount, ErrorCount);
                                    }
                                    else
                                    {
                                        StateLabel.ForeColor = Color.SpringGreen;
                                        StateLabel.Text = string.Format("下载完成，共 {0} 个文件", ContentCount);
                                    }
                                    DownloadButton.Text = "已完成";
                                    break;
                                }
                            default:
                                {
                                    UnityModule.DebugPrint("未知的 ArticleCard.State : {0}", State.ToString());
                                    break;
                                }
                        }
                    }));
                }
                catch (ThreadAbortException) { }
                catch (IOException) { }
                catch (Exception) { }
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

        /// <summary>
        /// 分析线程
        /// </summary>
        private Thread AnalyseArticleThread = null;
        /// <summary>
        /// 下载进程
        /// </summary>
        private Thread DownloadArticleThread = null;

        /// <summary>
        /// 页码
        /// </summary>
        private int PageIndex = 0;
        /// <summary>
        /// 内容编码
        /// </summary>
        private int ContentIndex = 0;
        /// <summary>
        /// 内容总数
        /// </summary>
        private int ContentCount = 0;
        /// <summary>
        /// 错误总数
        /// </summary>
        private int ErrorCount = 0;

        #endregion

        public ArticleCard()
        {
            InitializeComponent();
            InitializeControl();
            AttachEvent();
        }

        public ArticleCard(string articleID, string title , string description , string time , string imageLink , string imagePath) : this()
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

            //释放时需要置空，结束分析和下载线程
            this.Disposed += new EventHandler((s, e)=> {
                State = StateEnum.None;
                base.Dispose();
            });
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

        /// <summary>
        /// 分析文章
        /// </summary>
        private void AnalyseArticle(string PageAddress)
        {
            if (!UnityModule.UnityDBController.IsConnected())
            {
                throw new Exception("分析失败，数据库连接不可用");
            }
            string ContentString = string.Empty, PaginationString = string.Empty;
            //下载目录信息
            using (WebClient UnityWebClient = new WebClient()
            {
                BaseAddress = PageAddress,
                Encoding = Encoding.UTF8,
            })
            {
                try
                {
                    ContentString = UnityWebClient.DownloadString(PageAddress);
                }
                catch (ThreadAbortException) { }
                catch (Exception ex)
                {
                    UnityModule.DebugPrint("下载文章遇到错误：{0} - {1}", PageAddress, ex.Message);
                    throw ex;
                }
            }
            if (ContentString == string.Empty) throw new Exception("目录页面为空！");
            UnityModule.DebugPrint("下载文章页面成功：{0}", PageAddress);

            string ContentPattern = string.Format("<([a-z]+)(?:(?!class)[^<>])*class=([\"']?){0}\\2[^>]*>(?>(?<o><\\1[^>]*>)|(?<-o></\\1>)|(?:(?!</?\\1).))*(?(o)(?!))</\\1>", Regex.Escape("Mid2L_con"));
            Regex ContentRegex = new Regex(ContentPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match ContentMatch = ContentRegex.Match(ContentString);
            ContentString = ContentMatch.Value;
            if (ContentString == string.Empty) throw new Exception("文章页面匹配失败");

            int PaginationStart = ContentString.IndexOf("<!--{pe.begin.pagination}-->");
            if (PaginationStart < 0) throw new Exception("未发现 Pagination 断句");

            //分割文章内容和换页按钮(上下行位置不可交换)
            PaginationString = ContentString.Substring(PaginationStart);
            ContentString = ContentString.Substring(0, PaginationStart);

            if (ContentString != string.Empty)
            {
                //分析文章内容
                string[] ContentItems = Regex.Split(ContentString, "</p>");
                string Link = string.Empty;
                string Description = string.Empty;
                string ContentWithoutNL = string.Empty;

                foreach (string Content in ContentItems)
                {
                    try
                    {
                        //去除换行符
                        ContentWithoutNL = Content.Replace("\n", "");

                        //使用第一种匹配策略获取图像路径
                        ContentPattern = "<a.*?shtml\\?(?<ImageLink>.+?)\"";
                        ContentRegex = new Regex(ContentPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        ContentMatch = ContentRegex.Match(ContentWithoutNL);
                        Link = string.Empty;
                        Description = string.Empty;
                        if (ContentMatch.Success)
                        {
                            //匹配成功
                            Link = ContentMatch.Groups["ImageLink"].Value as string;
                        }
                        else
                        {
                            //匹配失败，切换策略获取图像路径
                            ContentPattern = "<img.*?src=\"(?<ImageLink>.+?)\"";
                            ContentRegex = new Regex(ContentPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            ContentMatch = ContentRegex.Match(ContentWithoutNL);
                            if (ContentMatch.Success)
                            {
                                //匹配成功
                                Link = ContentMatch.Groups["ImageLink"].Value as string;
                            }
                            else
                            {
                                //再次匹配失败，自暴自弃~
                                continue;
                            }
                        }
                        //获取图像描述
                        string[] TempDescription = Regex.Split(ContentWithoutNL, "<br>");
                        Description = TempDescription.Length > 1 ? TempDescription.Last() : "";
                        if (Description.StartsWith("\n")) Description = Description.Substring(1);

                        this.Invoke(new Action(() =>
                        {
                            StateLabel.Text = string.Format("正在分析：{0} 页 / {1} 图", PageIndex, ContentIndex++);
                        }));

                        //不可去掉 lock(){} ，因为数据库无法响应并发
                        lock (UnityModule.UnityDBController)
                        {
                            if (UnityModule.UnityDBController.ExecuteScalar("SELECT ContentID FROM ArticleBase WHERE Link='{0}' AND ArticleID='{1}'", Link, ArticleID) == null)
                            {
                                //内容信息不存在，储存进入数据库
                                UnityModule.UnityDBController.ExecuteNonQuery("INSERT INTO ArticleBase (Link, Description, ImagePath, ArticleID) VALUES('{0}', '{1}', '{2}', '{3}')",
                                    Link,
                                    Description,
                                    FileController.PathCombine(DownloadDirectory, Path.GetFileName(Link)),
                                    ArticleID
                                    );
                            }
                        }
                    }
                    catch (ThreadAbortException) { }
                    catch (IOException) { }
                    catch (Exception) { }
                }
            }

            if (PaginationString != string.Empty)
            {
                //分析下一页
                ContentPattern = "<a href=\"(?<NextPageLink>.+?)\">下一页</a>";
                ContentRegex = new Regex(ContentPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                ContentMatch = ContentRegex.Match(PaginationString);

                if (ContentMatch.Success)
                {
                    PageIndex++;
                    //递归分析下一页链接地址
                    AnalyseArticle(ContentMatch.Groups["NextPageLink"].Value as string);
                }
                else
                {
                    //文章下载结束
                }
            }
        }

        /// <summary>
        /// 下载文章
        /// </summary>
        private void DownloadArticle()
        {
            //检查缓存目录
            if (!Directory.Exists(DownloadDirectory))
            {
                try
                {
                    Directory.CreateDirectory(DownloadDirectory);
                }
                catch (ThreadAbortException) { }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //获取文章内容
            OleDbDataAdapter ContentAdapter = null;
            lock (UnityModule.UnityDBController)
            {
                ContentAdapter = UnityModule.UnityDBController.ExecuteAdapter("SELECT * FROM ArticleBase WHERE ArticleID='{0}'", ArticleID);
            }
            using (DataTable ContentTable = new DataTable())
            {
                ContentAdapter.Fill(ContentTable);
                if (ContentTable.Rows.Count > 0)
                {
                    string ContentLink = string.Empty, ContentPath = string.Empty;
                    //遍历文章内容
                    foreach (DataRow ContentRow in ContentTable.Rows)
                    {
                        try
                        {
                            ContentLink = ContentRow["Link"] as string;
                            ContentPath = ContentRow["ImagePath"] as string;
                            ContentIndex++;

                            //文件大小为0时删除
                            if (File.Exists(ContentPath) && new FileInfo(ContentPath).Length == 0)
                                try { File.Delete(ContentPath); } catch { }

                            if (!File.Exists(ContentPath))
                            {
                                //图像不存在，下载图像
                                using (WebClient ImageClient = new WebClient()
                                {
                                    BaseAddress = ContentLink,
                                    Encoding = Encoding.UTF8,
                                })
                                {
                                    try
                                    {
                                        ImageClient.DownloadFile(ContentLink, ContentPath);
                                        UnityModule.DebugPrint("图像下载成功：{0}", ContentLink);
                                    }
                                    catch (ThreadAbortException) { }
                                    catch (Exception ex)
                                    {
                                        ErrorCount++;
                                        UnityModule.DebugPrint("图像下载异常：{0}\n\t\t{1}", ContentLink, ex.Message);
                                    }
                                }
                            }

                            this.Invoke(new Action(() =>
                            {
                                StateLabel.Text = string.Format("正在下载：{0} / {1}，{2}个失败", ContentIndex, ContentCount, ErrorCount);
                            }));
                        }
                        catch (ThreadAbortException) { }
                        catch (IOException) { }
                        catch (Exception) { }
                    }
                }
            }
            ContentAdapter.Dispose();
        }

        /// <summary>
        /// 导出文章
        /// </summary>
        private void ExportArticle()
        {
            StreamWriter ArticleStream = null;
            try
            {
                ArticleStream = new StreamWriter(FileController.PathCombine(DownloadDirectory, Title) + ".html", false, Encoding.UTF8);
                ArticleStream.Write(@"<html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" /></head><body style=""width:70%;margin:0 auto""><center><pre><h1><strong>{0}</strong></h1></pre>" + "\n", Title);

                OleDbDataAdapter ContentAdapter = null;
                lock (UnityModule.UnityDBController)
                {
                    ContentAdapter = UnityModule.UnityDBController.ExecuteAdapter("SELECT * FROM ArticleBase WHERE ArticleID='{0}'", ArticleID);
                }
                using (DataTable ContentTable = new DataTable())
                {
                    ContentAdapter.Fill(ContentTable);
                    if (ContentTable.Rows.Count > 0)
                    {
                        foreach (DataRow ContentRow in ContentTable.Rows)
                        {
                            try
                            {
                                ArticleStream.WriteLine(@"<img src="".\{0}"" alt=""{1}""><br>{2}<br><hr>",Path.GetFileName(ContentRow["ImagePath"] as string), ContentRow["Link"], ContentRow["Description"]);
                            }
                            catch (ThreadAbortException) { }
                            catch (Exception ex)
                            {
                                UnityModule.DebugPrint("组装文章时遇到错误：{0}", ex.Message);
                            }
                        }
                    }
                }
                ContentAdapter.Dispose();

                ArticleStream.Write("\n<hr><<<< 文章结束 >>>></center></body></html>");
                UnityModule.DebugPrint("文章组装完成：{0}", ArticleID);
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                UnityModule.DebugPrint("导出文章时遇到错误：{0}", ex.Message);
                throw ex;
            }
            finally
            {
                ArticleStream?.Close();
            }
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
            State = StateEnum.None;

            ThreadPool.QueueUserWorkItem(new WaitCallback((v) =>
            {
                try
                {
                    lock (UnityModule.UnityDBController)
                        if (UnityModule.UnityDBController != null && UnityModule.UnityDBController.IsConnected())
                            UnityModule.UnityDBController.ExecuteNonQuery("DELETE FROM ArticleBase WHERE ArticleID='{0}'", ArticleID);

                    //清空数据库项目
                    if (Directory.Exists(DownloadDirectory))
                    {
                        //删除缓存文件和文件夹
                        foreach (string FilePath in Directory.GetFiles(DownloadDirectory))
                            try { File.Delete(FilePath); } catch { }
                        try { Directory.Delete(DownloadDirectory); } catch { }
                    }

                    //显示目录内文件总数
                    this.Invoke(new Action(() =>
                    {
                        StateLabel.ForeColor = Color.DeepSkyBlue;
                        if (Directory.Exists(DownloadDirectory))
                            StateLabel.Text = string.Format("已下载文件数：{0}", Directory.GetFiles(DownloadDirectory));
                        else
                            StateLabel.Text = "爸爸，点旁边的按钮开始下载...";
                    }));
                }
                catch (ThreadAbortException) { }
                catch (IOException) { }
                catch (Exception) { }
            }));
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            switch (State)
            {
                case StateEnum.None:
                    {
                        State = StateEnum.Analysing;
                        break;
                    }
                case StateEnum.Analysing:
                    {
                        StateLabel.ForeColor = Color.DeepSkyBlue;
                        StateLabel.Text = "已取消分析~";
                        State = StateEnum.None;
                        break;
                    }
                case StateEnum.AnalyseFinish:
                    {
                        State = StateEnum.Downloading;
                        break;
                    }
                case StateEnum.Downloading:
                    {
                        StateLabel.Text = "已取消下载~";
                        StateLabel.ForeColor = Color.DeepSkyBlue;
                        State = StateEnum.AnalyseFinish;
                        break;
                    }
                case StateEnum.DownloadFinish:
                    {
                        break;
                    }
            }
        }

    }
}
