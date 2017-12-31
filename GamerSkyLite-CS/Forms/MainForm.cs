using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GamerSkyLite_CS.Controller;
using LeonUI;
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

        /// <summary>
        /// 允许关闭
        /// </summary>
        private bool AllowToClose = false;

        /// <summary>
        /// 全局数据库连接
        /// </summary>
        private DataBaseController UnityDBController = new DataBaseController();

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


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        //TODO:如果是浏览文章状态，则返回文章目录
                        //TODO:如果是文章目录状态，则退出应用程序
                        this.Close();
                        break;
                    }
            }
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
            if (UnityDBController.CreateConnection(UnityModule.DataBasePath))
            {
                UnityModule.DebugPrint("数据库连接创建成功...");
            }
            else
            {
                new LeonMessageBox("数据库连接失败：", "无法连接数据库，GamerSky-Lite 即将退出...", LeonMessageBox.IconType.Error).ShowDialog(this);
                CloseMainForm();
                return;
            }
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
            IconLabel.MouseDown += new MouseEventHandler(UnityModule.MoveFormViaMouse);

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
        }

        /// <summary>
        /// 初始化程序
        /// </summary>
        private void InitializeApplication()
        {
            UnityModule.DebugPrint("初始化应用程序");
            this.Icon = UnityResource.GamerSky;
            IconLabel.Image = new Bitmap(UnityResource.GamerSky.ToBitmap(), 24, 24);
        }

        /// <summary>
        /// 关闭工作站主界面
        /// </summary>
        private void CloseMainForm()
        {
            AllowToClose = true;
            new Thread(new ThreadStart(delegate
            {
                while (this.Opacity > 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Top -= 1;
                        this.Opacity -= 0.1;
                    }));
                    Thread.Sleep(30);
                }
                //关闭数据库连接
                UnityDBController?.CloseConnection();
                this.Close();
            })).Start();
        }

        #endregion

    }
}
