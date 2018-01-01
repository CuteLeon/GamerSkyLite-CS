using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GamerSkyLite_CS.Controller;

namespace GamerSkyLite_CS
{
    class UnityModule
    {
        /// <summary>
        /// 文章目录地址
        /// </summary>
        public static readonly string CatalogAddress = "http://www.gamersky.com/ent/qw/";
        /// <summary>
        /// 网站地址
        /// </summary>
        public static readonly string WebSite = "http://www.gamersky.com";
        /// <summary>
        /// 数据库文件名称
        /// </summary>
        private static readonly string DBName = "GamerSky.mdb";
        /// <summary>
        /// 存档目录名称
        /// </summary>
        private static readonly string CDName = "GamerSky-Content";
        /// <summary>
        /// 存档目录路径
        /// </summary>
        public static readonly string ContentDirectory = FileController.PathCombine(Application.StartupPath, CDName);
        /// <summary>
        /// 数据库路径
        /// </summary>
        public static readonly string DataBasePath = FileController.PathCombine(ContentDirectory, DBName);

        //用于鼠标拖动无边框窗体
        [DllImportAttribute("user32.dll")] private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")] private static extern bool ReleaseCapture();

        public const int HT_CAPTION = 0x2;
        public const int WM_SIZE = 0x5;
        public const int WM_NCCALCSIZE = 0x83;
        public const int WM_NCPAINT = 0x85;
        public const int WM_NCACTIVATE = 0x86;
        public const int WM_NCMOUSEMOVE = 0xA0;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int WM_NCLBUTTONUP = 0xA2;
        public const int WM_NCLBUTTONDBCLK = 0xA3;
        public const int WM_NCRBUTTONDOWN = 0xA4;
        public const int WM_NCRBUTTONUP = 0xA5;
        public const int WM_NCRBUTTONDBCLK = 0xA6;
        public const int WM_NCMOUSEHOVER = 0x2A0;
        public const int WM_NCMOUSELEAVE = 0x2A2;
        //鼠标拖动边框相关常量
        public const int WM_NCHITTEST = 0x0084;
        public const int HT_LEFT = 10;
        public const int HT_RIGHT = 11;
        public const int HT_TOP = 12;
        public const int HT_TOPLEFT = 13;
        public const int HT_TOPRIGHT = 14;
        public const int HT_BOTTOM = 15;
        public const int HT_BOTTOMLEFT = 16;
        public const int HT_BOTTOMRIGHT = 17;

        /// <summary>
        /// 注册以帮助鼠标拖动无边框窗体
        /// </summary>
        static public void MoveFormViaMouse(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage((sender is Form ? (sender as Form).Handle : (sender as Control).FindForm().Handle), WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// 封装的函数以输出调试信息
        /// </summary>
        /// <param name="DebugMessage">调试信息</param>
        static public void DebugPrint(string DebugMessage)
        {
            Debug.Print(string.Format("{0}    {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DebugMessage));
        }

        /// <summary>
        /// 封装的函数以输出调试信息
        /// </summary>
        /// <param name="DebugMessage">调试信息</param>
        /// <param name="DebugValue">调试信息的值</param>
        static public void DebugPrint(string DebugMessage, params object[] DebugValue)
        {
            DebugPrint(string.Format(DebugMessage, DebugValue));
        }
    }
}
