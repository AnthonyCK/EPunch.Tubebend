using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace EPunch.Tubebend
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string email = ConfigurationManager.AppSettings["Email"];
            string uuid = ConfigurationManager.AppSettings["uuid"];
            string sn = ConfigurationManager.AppSettings["sn"];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AnyCAD.Platform.GlobalInstance.Application.SetLogFileName(new AnyCAD.Platform.Path("anycad.net.sdk.log"));
            AnyCAD.Platform.GlobalInstance.RegisterSDK(email, uuid, sn);
            Application.Run(new TestForm());
        }
    }
}
