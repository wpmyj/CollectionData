using LY.DeveCollection.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Utility;
using Client.Utility.Logging;

namespace LY.DeveCollection
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                //   Application.Run(new DevStatus());
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Utils.Logger.Error("设备应用端终止：" + ex.ToString());
            }
        }
    }
}
