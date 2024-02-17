using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace telegraph_botnet
{
    internal class cmd
    {
        public string ComType { get; set; }
        public string ComContent { get; set; }

        public cmd(string input_content) 
        {


            Console.WriteLine(Environment.CurrentDirectory);

            string[] cmd_cnt = Regex.Split(input_content, config.spliter);

            try
            {
                ComType = cmd_cnt[0];
                ComContent = cmd_cnt[1];
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
