using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vSroMultiTool
{
    public class Logs
    {
        public static event Action<string> DoLogs;
        public static void addLog(string EventStr)
        {
            if (DoLogs != null)
                DoLogs.Invoke(EventStr);
        }
    }
}
