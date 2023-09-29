namespace SilkroadLauncher
{
    using System;
    using System.Linq;
    using Pk2ReaderAPI;
    using SilkroadLauncher.Network;
    using SilkroadLauncher.Utility;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;


    public class CheckUpdate
    {
        public delegate void Logs(string txt);
        public event Logs LogsLauncher;

        ~CheckUpdate()
        {
            if (Instance != null) Instance = null;
        }
        public static CheckUpdate Instance { set; get; }

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);

        #region Singleton
        /// <summary>
        /// Unique instance of this class
        /// </summary>
        // public static LauncherViewModel Instance { get; } = new LauncherViewModel();
        #endregion

        #region Private Properties
        /// <summary>
        /// Application title
        /// </summary>
        /// <summary>
        /// The window this view model controls
        /// </summary>
        //private IWindow m_Window;
        /// <summary>
        /// Division info
        /// </summary>
        private Dictionary<string, List<string>> m_DivisionInfo;
        /// <summary>
        /// Gateway port
        /// </summary>
        private ushort m_Gateport;
        /// <summary>
        /// Client version handled internally by game
        /// </summary>
        private uint m_Version;

        /// <summary>
        /// Arguments used to start the game client
        /// </summary>
        private string m_ClientArgs;

        /// <summary>
        /// Locale type
        /// </summary>
        private byte m_Locale;

        /// <summary>
        /// The initial connection to server
        /// </summary>
        private Client m_GatewaySession;

        /// <summary>
        /// The current bytes downloaded to apply patch
        /// </summary>
        private ulong m_UpdatingBytesDownloading;

        /// <summary>
        /// The current patch percentage
        /// </summary>
        private int m_UpdatingPercentage;

        /// <summary>
        /// Indicates if the game can be started
        /// </summary>
        internal bool m_CanStartGame;
        #endregion

        #region Public Properties
        /// <summary>
        /// Application title shown on windows title bar
        /// </summary>
        public string Title { get; set; } = SilkroadLauncher.LauncherSettings.APP_TITLE;
        /// <summary>
        /// Client locale
        /// </summary>
        public byte Locale
        {
            get => m_Locale;
            set =>
                // set new value
                m_Locale = value;
        }

        public uint Version
        {
            get => m_Version;
            set
            {
                // set new value
                m_Version = value;
                // Set as string
                var strVer = (1000 + m_Version).ToString();
                ClientVersion = strVer.Substring(0, 1) + "." + strVer.Substring(1);
          


            }
        }
        /// <summary>
        /// Client version shown to the user
        /// </summary>
        public string ClientVersion { get; private set; } = string.Empty;
        /// <summary>
        /// Check if the Pk2 has been correctly loaded
        /// </summary>
        public bool IsLoaded { get; private set; }
        /// <summary>
        /// Check if the launcher is on game config screen
        /// </summary>
        public bool IsViewingConfig { get; set; }
        ///// <summary>
        ///// The basic view config used by the game client
        ///// </summary>
        //public ConfigViewModel Config { get; set; } = new ConfigViewModel();
        /// <summary>
        /// Check if the launcher is on game language config window
        /// </summary>
        public bool IsViewingLangConfig { get; set; }
        /// <summary>
        /// Language temporally selected as new option
        /// </summary>
        public int LangConfigIndex { get; set; }
        /// <summary>
        /// Check if the launcher is looking for update the client
        /// </summary>
        public bool IsCheckingUpdates { get; set; }

        /// <summary>
        /// Check if cannot connect to server
        /// </summary>
        public bool IsUnderInspection { get; set; } = true;
        /// <summary>
        /// All notices loaded after checking updates
        /// </summary>
        //public List<WebNoticeViewModel> WebNotices { get; set; } = new List<WebNoticeViewModel>();
        /// <summary>
        /// The notice selected, the first one as default.
        /// </summary>
        //public WebNoticeViewModel SelectedWebNotice { get; set; }
        /// <summary>
        /// Check if the launcher is updating the client
        /// </summary>
        public bool IsUpdating { get; set; }
        /// <summary>
        /// Get or sets the max. bytes quantity to be downloaded to apply patch
        /// </summary>
        public ulong UpdatingBytesMaxDownloading { get; set; }
        /// <summary>
        /// Get or sets the bytes quantity downloaded to apply patch
        /// </summary>
        public ulong UpdatingBytesDownloading
        {
            get => m_UpdatingBytesDownloading;
            set
            {
                // set new value
                m_UpdatingBytesDownloading = value;

                // Set percentage
                if (UpdatingBytesMaxDownloading != 0)
                    UpdatingPercentage = (int)(m_UpdatingBytesDownloading * 100ul / UpdatingBytesMaxDownloading);
            }
        }
        /// <summary>
        /// Get the current percentage from patch download
        /// </summary>
        public int UpdatingPercentage
        {
            get => m_UpdatingPercentage;
            set
            {
                if (m_UpdatingPercentage == value)
                    return;

                m_UpdatingPercentage = value;

            }
        }
        /// <summary>
        /// The current file being downloaded and imported
        /// </summary>
        public string UpdatingFilePath { get; set; }
        /// <summary>
        /// Get the current file percentage being updated
        /// </summary>
        public int UpdatingFilePercentage { get; set; }
        /// <summary>
        /// Check if the game can be started
        /// </summary>
        public bool CanStartGame
        {
            get => m_CanStartGame;
            set =>
                // set new value
                m_CanStartGame = value;// notify event
        }
        /// <summary>
        /// Contains all assets to be displayed
        /// </summary>
        //public LauncherAssets Assets { get; private set; }
        #endregion


        #region Public Methods
        /// <summary>
        /// Set the window this view model controls
        /// </summary>
        //public void SetWindow(IWindow Window)
        //{
        //    // Just save a reference
        //    m_Window = Window;
        //}
        /// <summary>
        /// Show message to the user
        /// </summary>
        public void ShowMessage(string Text)
        {
            if (LogsLauncher != null)
                LogsLauncher.Invoke(Text);
        }
        /// <summary>
        /// Check and loads the patch updates
        /// </summary>
        public void CheckUpdatesAsync()
        {
            if (!IsLoaded)
                return;

            IsCheckingUpdates = true;

            // Find the best connection
            long bestTime = 0;
            string hostAddress = null;

            var divIdx = 0;
            foreach (var div in m_DivisionInfo)
            {
                for (var hostIdx = 0; hostIdx < div.Value.Count; hostIdx++)
                {
                    var session = new Client();
                    // Connect to server and find the time used
                    if (session.Start(div.Value[hostIdx], m_Gateport, 5000, out var elapsedTime))
                    {
                        session.Stop();
                        // Check the best time
                        if (hostAddress == null || elapsedTime < bestTime)
                        {
                            hostAddress = div.Value[hostIdx];
                            elapsedTime = bestTime;
                            m_ClientArgs = "0 /" + m_Locale + " " + divIdx + " " + hostIdx;
                        }
                    }
                }
                divIdx++;
            }

            // Start gateway connection
            if (hostAddress != null)
            {
                m_GatewaySession = new Client();
                // Packet handlers
                m_GatewaySession.RegisterHandler(GatewayModule.Opcode.GLOBAL_IDENTIFICATION, GatewayModule.Server_GlobalIdentification);
                m_GatewaySession.RegisterHandler(GatewayModule.Opcode.SERVER_PATCH_RESPONSE, GatewayModule.Server_PatchResponse);
                m_GatewaySession.RegisterHandler(GatewayModule.Opcode.SERVER_SHARD_LIST_RESPONSE, GatewayModule.Server_ShardListResponse);
                m_GatewaySession.RegisterHandler(GatewayModule.Opcode.SERVER_WEB_NOTICE_RESPONSE, GatewayModule.Server_WebNoticeResponse);
                // Event handlers
                m_GatewaySession.OnConnect += (s, e) =>
                {
                    ShowMessage("Gateway: Session established");

                };
                m_GatewaySession.OnDisconnect += (s, e) =>
                {
                    ShowMessage("Gateway: Session disconnected [" + e.Exception.Message + "]");
                };
                m_GatewaySession.Start(hostAddress, m_Gateport, 5000, out _);
                m_GatewaySession.OnConnect += M_GatewaySession_OnConnect;
            }
            else
            {
                // Not being able to connect to the server
                IsCheckingUpdates = false;
                IsUnderInspection = true;
                //rep to Event To Rung Here !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                ShowMessage(LauncherSettings.MSG_INSPECTION);
            }
        }

        private void M_GatewaySession_OnConnect(object sender, EventArgs e)
        {
            ShowMessage($"Gateway Session On Connect \" CanStartGame = {CanStartGame} & m_ClientArgs = {m_ClientArgs} \" ");
        }

        /// <summary>
        /// Exit from Launcher
        /// </summary>
        public void Exit()
        {
            //App.Current.Dispatcher.Invoke(() =>
            //{
            //    m_GatewaySession?.Stop();
            //    m_Window?.Close();
            //});
            this.ShowMessage("Exit CLinet !!!");
            m_GatewaySession.Stop();
            if (Instance != null)
                Instance = null;


        }
        public void StartClinet()
        {
            // Starts the game but only if is ready and exists
            if (CanStartGame && File.Exists(LauncherSettings.CLIENT_EXECUTABLE))
            {
                System.Diagnostics.Process.Start(LauncherSettings.CLIENT_EXECUTABLE, m_ClientArgs);
            }
        }
        #endregion


        #region Private Helpers
        /// <summary>
        /// Initialize all stuffs required for the connection and settings
        /// </summary>
        private void Initialize()
        {
            // Create mutex required to execute client
            CreateMutex(IntPtr.Zero, false, SilkroadLauncher.LauncherSettings.APP_TITLE);
            CreateMutex(IntPtr.Zero, false, "Ready");
            // Load Pk2 Data
            Pk2Reader pk2Reader = null;
            try
            {
                // Load pk2 reader
                pk2Reader = new Pk2Reader(LauncherSettings.CLIENT_MEDIA_PK2_PATH, LauncherSettings.CLIENT_BLOWFISH_KEY);

                // Load assets from client -> UI No Need here !!
                //   Assets = new LauncherAssets(pk2Reader);

                // Extract essential stuffs for the process
                if (pk2Reader.TryGetDivisionInfo(out m_DivisionInfo) && pk2Reader.TryGetGateport(out m_Gateport))
                {
                    // Abort operations if host or port is not verified
                    if (!VerifyHosts(m_DivisionInfo) || !VerifyPort(m_Gateport))
                        return;

                    // continue extracting
                    if (pk2Reader.TryGetVersion(out m_Version)
                    && pk2Reader.TryGetLocale(out m_Locale))
                    {
                        IsLoaded = true;
                        // Force string to be updated
                        Version = m_Version;
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("error.txt", DateTime.Now.ToString() + ":" + ex.Message);
                ShowMessage(ex.Message);
                // Forced shutdown
                //Application.Current.Shutdown();
            }
            finally
            {
                pk2Reader?.Close();
            }
        }
        /// <summary>
        /// Verify host used to start the game it's linked to launcher config
        /// </summary>
        private bool VerifyHosts(Dictionary<string, List<string>> divInfo)
        {
            // Verification not required
            if (LauncherSettings.CLIENT_VERIFY_HOST.Length == 0)
                return true;

            // Check every host from divisions
            foreach (var div in divInfo.Values)
            {
                foreach (var host in div)
                {
                    // Check if host is verified
                    foreach (var h in LauncherSettings.CLIENT_VERIFY_HOST)
                    {
                        if (h != host)
                            return false;
                    }
                }
            }

            // All host has been succeed
            return true;
        }
        /// <summary>
        /// Verify port used to start the game it's linked to launcher config
        /// </summary>
        private bool VerifyPort(int port)
        {
            return LauncherSettings.CLIENT_VERIFY_PORT == 0 || LauncherSettings.CLIENT_VERIFY_PORT == port;
        }
        #endregion

        public CheckUpdate()
        {
            Initialize();
            Instance = this;
        }





    }
}






