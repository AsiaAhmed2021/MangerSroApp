using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.ExtensionsClass
{
    public static class Logs
    {
        public static void AddLogs(this ListBox _this, string Msg, params object[] values)
        {
            try
            {
                Msg = string.Format(Msg, values);
                _this.Items.Add("[" + System.DateTime.Now.ToLongTimeString() + "] " + Msg);
                _this.TopIndex = _this.Items.Count - 1;
            }
            catch (Exception)
            {
            }
        }
    }
}
