using Server_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp
{
    public class Glabels
    {
        public static Form1 MainForm { set; get; }
        public static MainControl ServerManager { set; get; }

        public static void ShowFormTask(string TextPage, Control TargetControl, Control sender = null)
        {
            SuppWindow suppWindow = new SuppWindow(TextPage);
            TargetControl.Dock = DockStyle.Fill;
            suppWindow.Controls.Add(TargetControl);
            suppWindow.Show();
        }


    }
}
