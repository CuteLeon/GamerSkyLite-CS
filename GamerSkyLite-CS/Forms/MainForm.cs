using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GamerSkyLite_CS.Controller;
using GamerSkyLite_CS.Controls;
using LeonUI;
using LeonUI.Controls;
using LeonUI.Forms;

namespace GamerSkyLite_CS
{
    public partial class MainForm : Form
    {

        #region "REDRAW"
        const int WM_SIZE = 0x5;
        const int SIZE_MAXIMIZED = 0x2;
        const uint RDW_INVALIDATE = 0x1;
        const uint RDW_IUPDATENOW = 0x100;
        const uint RDW_FRAME = 0x400;
        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
        #endregion

        #region 私有变量

        public new string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                TitleLabel.Text = value;
            }
        }

        WebBrowser ArticleBrowser = null;

        /// <summary>
        /// 允许关闭
        /// </summary>
        private bool AllowToClose = false;

        private UIStateEnum _uiState = UIStateEnum.Catalog;
        /// <summary>
        /// 界面状态
        /// </summary>
        private UIStateEnum UIState
        {
            get => _uiState;
            set
            {
                _uiState = value;
                switch (value)
                {
                    case UIStateEnum.Catalog:
                        {
                            this.Text = "GamerSky-Lite [需求才是第一生产力]";
                            LogPanel.Hide();
                            ArticleBrowser?.Hide();
                            ArticleBrowser?.Dispose();
                            ArticleBrowser = null;
                            GC.Collect();

                            MainPanel.Show();
                            MainPanel.Dock = DockStyle.Fill;
                            CatalogLayoutPanel.Show();
                            CatalogLayoutPanel.Dock = DockStyle.Fill;
                            break;
                        }
                    case UIStateEnum.Article:
                        {
                            LogPanel.Hide();
                            CatalogLayoutPanel.Hide();
                            if (ArticleBrowser == null)
                            {
                                ArticleBrowser = new WebBrowser()
                                {
                                    Margin = new Padding(0, 0, 0, 0),
                                };
                            }
                            MainPanel.Show();
                            MainPanel.Dock = DockStyle.Fill;
                            MainPanel.Controls.Add(ArticleBrowser);
                            ArticleBrowser.BringToFront();
                            ArticleBrowser.Show();
                            ArticleBrowser.Dock = DockStyle.Fill;
                            break;
                        }
                    case UIStateEnum.Log:
                        {
                            MainPanel.Hide();
                            LogPanel.Show();
                            LogPanel.Dock = DockStyle.Fill;
                            break;
                        }
                }
            }
        }
        private enum UIStateEnum
        {
            /// <summary>
            /// 目录界面
            /// </summary>
            Catalog=0,
            /// <summary>
            /// 文章界面
            /// </summary>
            Article=1,
            /// <summary>
            /// Log界面
            /// </summary>
            Log=2,
        }

        #endregion

        #region 窗体事件

        public MainForm()
        {
            UnityModule.DebugPrint("构造 MainForm() ...");
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);
            UpdateStyles();

            InitializeApplication();

            AttachEvent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.LightGray, 0, 0, this.Width - 1, this.Height - 1);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //Check存档目录
            if (!Directory.Exists(UnityModule.ContentDirectory))
            {
                try
                {
                    Directory.CreateDirectory(UnityModule.ContentDirectory);
                }
                catch (Exception ex)
                {
                    new LeonMessageBox("无法创建缓存目录", "存档目录不存在，创建存档目录时遇到错误：\n{0}", LeonMessageBox.IconType.Error, ex.Message).ShowDialog(this);
                    CloseMainForm();
                    return;
                }
            }
            //Check数据库文件
            if (!File.Exists(UnityModule.DataBasePath))
            {
                try
                {
                    FileController.SaveResource(UnityResource.DataBase, UnityModule.DataBasePath);
                }
                catch (Exception ex)
                {
                    new LeonMessageBox("无法释放数据库文件", "数据库文件不存在，释放数据库文件时遇到错误：\n{0}", LeonMessageBox.IconType.Error, ex.Message).ShowDialog(this);
                }
            }

            //连接数据库
            if (UnityModule.UnityDBController.CreateConnection(UnityModule.DataBasePath))
            {
                UnityModule.DebugPrint("数据库连接创建成功...");
            }
            else
            {
                new LeonMessageBox("数据库连接失败：", "无法连接数据库，GamerSky-Lite 即将退出...", LeonMessageBox.IconType.Error).ShowDialog(this);
                CloseMainForm();
                return;
            }

            RefreshCatalog();
        }

        //为窗体添加阴影
        protected override CreateParams CreateParams
        {
            get
            {
                if (!DesignMode)
                {
                    CreateParams baseParams = base.CreateParams;
                    baseParams.ClassStyle |= 131072;
                    baseParams.ExStyle |= 33554432;
                    return baseParams;
                }
                else
                {
                    return base.CreateParams;
                }
            }
        }

        /// <summary>
        /// 消息拦截
        /// </summary>
        /// <param name="ProcessMessage"></param>
        protected override void WndProc(ref Message ProcessMessage)
        {
            switch (ProcessMessage.Msg)
            {
                case WM_SIZE:
                    {
                        base.WndProc(ref ProcessMessage);
                        if (ProcessMessage.WParam.ToInt32() == SIZE_MAXIMIZED)
                            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
                        break;
                    }
                case UnityModule.WM_NCHITTEST:
                    {
                        if (this.WindowState == FormWindowState.Maximized)
                        {
                            base.WndProc(ref ProcessMessage);
                            break;
                        }
                        int nPosX = (ProcessMessage.LParam.ToInt32() & 65535);
                        int nPosY = (ProcessMessage.LParam.ToInt32() >> 16);

                        if (nPosX >= this.Right - 5 && nPosY >= this.Bottom - 5)
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_BOTTOMRIGHT);
                        else if (nPosX <= this.Left + 5 && nPosY <= this.Top + 5)
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_TOPLEFT);
                        else if (nPosX <= this.Left + 5 && nPosY >= this.Bottom - 5)
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_BOTTOMLEFT);
                        else if (nPosX >= this.Right - 5 && nPosY <= this.Top + 5)
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_TOPRIGHT);
                        else if (nPosX >= this.Right - 5)
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_RIGHT);
                        else if (nPosY >= this.Bottom - 5)
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_BOTTOM);
                        else if (nPosX <= this.Left + 5)
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_LEFT);
                        else if (nPosY <= this.Top + 5)
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_TOP);
                        else
                            ProcessMessage.Result = new IntPtr(UnityModule.HT_CAPTION);
                        break;
                    }
                default:
                    {
                        base.WndProc(ref ProcessMessage);
                        break;
                    }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllowToClose)
            {
                e.Cancel = true;
                if (new LeonMessageBox("确定要退出吗？", "您确定要退出 GamerSke-Lite 吗？", LeonMessageBox.IconType.Question) { ThemeColor = TitleLabel.ForeColor }.ShowDialog(this) == DialogResult.OK)
                {
                    UnityModule.DebugPrint("关闭 MainForm() ...");
                    CloseMainForm();
                }
                else { AllowToClose = false; }
            }
        }

        #endregion

        #region "功能函数"
        /// <summary>
        /// 初始化控件事件绑定
        /// </summary>
        private void AttachEvent()
        {
            UnityModule.DebugPrint("初始化事件列表");
            TitlePanel.MouseDown += new MouseEventHandler(UnityModule.MoveFormViaMouse);
            TitleLabel.MouseDown += new MouseEventHandler(UnityModule.MoveFormViaMouse);

            this.Resize += new EventHandler((s, e) => {
                switch (this.WindowState)
                {
                    case FormWindowState.Maximized:
                        {
                            MaxButton.Hide();
                            RestoreButton.Show();
                            break;
                        }
                    case FormWindowState.Normal:
                        {
                            RestoreButton.Hide();
                            MaxButton.Show();
                            break;
                        }
                }
            });
            this.SizeChanged += new EventHandler((s, e) => RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE));

            EventHandler ButtonMouseEnter = new EventHandler((s, e) => { (s as Label).ImageIndex = 1; });
            MouseEventHandler ButtonMouseDown = new MouseEventHandler((s, e) => { (s as Label).ImageIndex = 0; });
            MouseEventHandler ButtonMouseUp = new MouseEventHandler((s, e) => { (s as Label).ImageIndex = 1; });
            EventHandler ButtonMouseLeave = new EventHandler((s, e) => { (s as Label).ImageIndex = 0; });

            GoBackButton.MouseEnter += ButtonMouseEnter;
            GoBackButton.MouseDown += ButtonMouseDown;
            GoBackButton.MouseUp += ButtonMouseUp;
            GoBackButton.MouseLeave += ButtonMouseLeave;

            RefreshButton.MouseEnter += ButtonMouseEnter;
            RefreshButton.MouseDown += ButtonMouseDown;
            RefreshButton.MouseUp += ButtonMouseUp;
            RefreshButton.MouseLeave += ButtonMouseLeave;

            LogButton.MouseEnter += ButtonMouseEnter;
            LogButton.MouseDown += ButtonMouseDown;
            LogButton.MouseUp += ButtonMouseUp;
            LogButton.MouseLeave += ButtonMouseLeave;

            SQLTextBox.GotFocus += new EventHandler((s,e)=> {
                if (SQLTextBox.Text == "输入SQL指令，按Enter键执行...") SQLTextBox.Text = "";
            });
            SQLTextBox.LostFocus += new EventHandler((s, e) =>
            {
                if (SQLTextBox.Text == "") SQLTextBox.Text = "输入SQL指令，按Enter键执行...";
            });
        }

        /// <summary>
        /// 初始化程序
        /// </summary>
        private void InitializeApplication()
        {
            UnityModule.DebugPrint("初始化应用程序");
            this.Icon = UnityResource.GamerSky;
            IconLabel.Image = new Bitmap(UnityResource.GamerSky.ToBitmap(), 24, 24);

            GoBackButton.ImageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth24Bit,
                ImageSize = new Size(50, 50),
            };
            GoBackButton.ImageList.Images.Add(UnityResource.GoBack_0);
            GoBackButton.ImageList.Images.Add(UnityResource.GoBack_1);
            GoBackButton.ImageIndex = 0;

            RefreshButton.ImageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth24Bit,
                ImageSize = new Size(50, 50),
            };
            RefreshButton.ImageList.Images.Add(UnityResource.Refresh_0);
            RefreshButton.ImageList.Images.Add(UnityResource.Refresh_1);
            RefreshButton.ImageIndex = 0;

            LogButton.ImageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth24Bit,
                ImageSize = new Size(50, 50),
            };
            LogButton.ImageList.Images.Add(UnityResource.Log_0);
            LogButton.ImageList.Images.Add(UnityResource.Log_1);
            LogButton.ImageIndex = 0;

            UIState = UIStateEnum.Catalog;
        }

        /// <summary>
        /// 关闭工作站主界面
        /// </summary>
        private void CloseMainForm()
        {
            AllowToClose = true;
            new Thread(new ThreadStart(delegate
            {
                //关闭数据库连接
                UnityModule.UnityDBController?.CloseConnection();
                while (this.Opacity > 0)
                {
                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.Top -= 1;
                            this.Opacity -= 0.1;
                        }));
                        Thread.Sleep(30);
                    }
                    catch (ThreadAbortException) { return; }
                    catch (IOException) { return; }
                    catch (Exception) { }
                }
                this.Close();
            })).Start();
        }

        /// <summary>
        /// 刷新目录
        /// </summary>
        private void RefreshCatalog()
        {
            foreach (IComponent CatalogControl in CatalogLayoutPanel.Controls)
            {
                CatalogControl.Dispose();
            }
            CatalogLayoutPanel.Controls.Clear();
            GC.Collect();

            //更新文章目录
            try
            {
                foreach(string CatalogAddress in UnityModule.CatalogAddressList)
                    CatalogController.GetCatalog(CatalogAddress);
            }
            catch (Exception ex)
            {
                new LeonMessageBox("更新目录失败", "无法联网更新文章目录，请阅读离线文章。\n{0}", LeonMessageBox.IconType.Error, ex.Message).ShowDialog(this);
            }

            //加载文章目录
            LoadCatalog();
        }

        private void BrowseArticle(object sender, EventArgs e)
        {
            if (File.Exists((sender as ArticleCard).ArticleFilePath))
            {
                UIState = UIStateEnum.Article;
                this.Text = string.Format("{0} / GamerSky-Lite", (sender as ArticleCard).Title);
                ArticleBrowser.Navigate((sender as ArticleCard).ArticleFilePath);
            }
        }

        #endregion

        private void CatalogLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            if (CatalogLayoutPanel.Width > 750)
                e.Graphics.DrawString("嘻嘻嘻~\n我不管，我最帅，\n我是你们的小可爱~~~", this.Font, Brushes.DeepSkyBlue, 750, 100);
        }

        private void ControlPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Red, this.Width - 5, 0, this.Width - 5, this.Height - 1);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                switch (UIState)
                {
                    case UIStateEnum.Catalog:
                        {
                            this.Close();
                            break;
                        }
                    case UIStateEnum.Article:
                        {
                            UIState = UIStateEnum.Catalog;
                            break;
                        }
                    case UIStateEnum.Log:
                        {
                            UIState = (ArticleBrowser == null ? UIStateEnum.Catalog : UIStateEnum.Article);
                            break;
                        }
                }
            }
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            switch (UIState)
            {
                case UIStateEnum.Catalog:
                    {
                        this.Close();
                        break;
                    }
                case UIStateEnum.Article:
                    {
                        UIState = UIStateEnum.Catalog;
                        break;
                    }
                case UIStateEnum.Log:
                    {
                        UIState = (ArticleBrowser == null ? UIStateEnum.Catalog : UIStateEnum.Article);
                        break;
                    }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshButton.Enabled = false;
            if (UIState == UIStateEnum.Catalog)
            {
                RefreshCatalog();
            }
            else if (UIState == UIStateEnum.Article)
            {
                ArticleBrowser.Refresh();
            }
            RefreshButton.Enabled = true;
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            UIState = UIStateEnum.Log;
        }

        private void SQLTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if(SQLTextBox.Text !="")
                    lock (UnityModule.UnityDBController)
                        UnityModule.UnityDBController.ExecuteNonQuery(SQLTextBox.Text);
        }

        private void IconLabel_Click(object sender, EventArgs e)
        {
            //最近发现经常发布了新文章后并没有发布在文章目录界面，我们来手动扫描~
            int StartIndex = 1004000;
            int EndIndex = 1006000;
            string DateString = "201801";

            using (Form InputForm = new Form()
            {
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                Size = new Size(240, 100),
                StartPosition = FormStartPosition.CenterParent,
                KeyPreview = true,
            })
            {
                RoundedTextBox InputTextBox = new RoundedTextBox()
                {
                    BackColor = Color.White,
                    Font = this.Font,
                    ForeColor = Color.OrangeRed,
                    TextAlign = HorizontalAlignment.Center,
                    Dock = DockStyle.Top,
                    Visible = true,
                };
                RoundedButton InputButton = new RoundedButton()
                {
                    Dock = DockStyle.Bottom,
                    Text = "确定",
                    BackColor = Color.White,
                    Font = this.Font,
                    ForeColor = Color.OrangeRed,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 34,
                    Visible = true,
                };

                InputForm.KeyDown += new KeyEventHandler((s, v) => { if (v.KeyCode == Keys.Enter) InputForm.DialogResult = DialogResult.OK; else if (v.KeyCode == Keys.Escape) InputForm.DialogResult = DialogResult.Cancel; });
                InputButton.Click += new EventHandler((s, v) => { InputForm.DialogResult = DialogResult.OK; });

                InputForm.Controls.Add(InputTextBox);
                InputForm.Controls.Add(InputButton);

                InputForm.Text = "请输入日期编码";
                InputTextBox.Text = DateString;
                if (InputForm.ShowDialog(this) != DialogResult.OK) return;
                DateString = InputTextBox.Text.Trim();
                UnityModule.DebugPrint("输入日期编码：{0}", DateString);

                InputForm.Text = "请输入开始Index:";
                InputTextBox.Text = StartIndex.ToString();
                if (InputForm.ShowDialog(this) != DialogResult.OK) return;
                if (!int.TryParse(InputTextBox.Text.Trim(), out StartIndex))  return;
                UnityModule.DebugPrint("输入开始Index：{0}", StartIndex.ToString());

                InputForm.Text = "请输入结束Index:";
                InputTextBox.Text = EndIndex.ToString();
                if (InputForm.ShowDialog(this) != DialogResult.OK) return;
                if (!int.TryParse(InputTextBox.Text.Trim(), out EndIndex)) return;
                UnityModule.DebugPrint("输入结束Index：{0}", EndIndex.ToString());

                UnityModule.DebugPrint("======<开始并行扫描文章>======");
                //开始扫描
                ThreadPool.QueueUserWorkItem(new WaitCallback((x) => {
                    Parallel.For(StartIndex, EndIndex, delegate (int Index) {
                        try
                        {
                            using (WebClient ScanClient = new WebClient())
                            {
                                string Address = string.Format("http://www.gamersky.com/ent/{0}/{1}.shtml", DateString, Index);
                                if (ScanClient.DownloadString(Address).Length > 0)
                                {
                                    if (((int)UnityModule.UnityDBController.ExecuteScalar("SELECT COUNT(*) FROM CatalogBase WHERE ArticleLink = '{0}'", Address)) == 0)
                                    {
                                        UnityModule.DebugPrint("发现新文章：{0}", Index);
                                        UnityModule.UnityDBController.ExecuteNonQuery("INSERT INTO CatalogBase (ArticleID, Title, ArticleLink, ImagePath, ImageLink, Description, PublishTime, IsNew) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', YES)",
                                            Index.ToString(),
                                            "扫描文章：" + Index.ToString(),
                                            Address,
                                            string.Empty,
                                            string.Empty,
                                            "手动扫描到的文章。",
                                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                        );
                                    }
                                }
                            }
                        }
                        catch { }
                    });
                    UnityModule.DebugPrint("======<文章手动扫描结束>======");

                    this.Invoke(new Action(()=> {
                        new LeonMessageBox("文章手动扫描结束", "文章手动扫描结束，请手动刷新文章目录。", LeonMessageBox.IconType.Info).ShowDialog(this);
                    }));
                }));
            }
        }

        private void ControlPanel_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath);
        }
    }
}
