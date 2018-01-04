using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamerSkyLite_CS
{
    static class Program
    {
        public static MainForm UnityMainForm = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UnityMainForm = new MainForm();
            Application.Run(UnityMainForm);
        }
    }
}
