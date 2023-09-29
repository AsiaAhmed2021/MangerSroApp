namespace vSroMultiTool
{
    using System;

    internal class Globals
    {
        public static App MainWindow;
        public static ServerEnum Server = ServerEnum.None;

        public enum ServerEnum
        {
            None,
            Gateway,
            Agent
        }
    }
}

