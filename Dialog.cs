using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace telegraph_botnet
{
    internal class Dialog
    {
        public static int DialogShowInfo(string TEXT)
        {
            MessageBox.Show(TEXT, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*
            string result = Microsoft.VisualBasic.Interaction.InputBox("Prompt",
                       "Инфо",
                       $"{TEXT}",
                       0,
                       0);
            
            */
            return 1;
        }

        public static int DialogShowError(string TEXT)
        {
            MessageBox.Show(TEXT, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return 1;
        }

        public static int DialogShowWarning(string TEXT)
        {
            MessageBox.Show(TEXT, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 1;
        }
    }
}
