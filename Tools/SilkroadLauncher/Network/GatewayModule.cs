using Pk2WriterAPI;
using SilkroadCommon;
using SilkroadCommon.Download;
using SilkroadSecurityApi;

using System.Collections.Generic;

namespace SilkroadLauncher.Network
{
    public static class GatewayModule
    {


        public static class Opcode
        {
            public const ushort
            CLIENT_PATCH_REQUEST = 0x6100,
            CLIENT_SHARD_LIST_REQUEST = 0x6101,
            CLIENT_LOGIN_REQUEST = 0x6102,
            CLIENT_WEB_NOTICE_REQUEST = 0x6104,
            CLIENT_SHARD_LIST_PING_REQUEST = 0x6106,
            CLIENT_CAPTCHA_SOLVED_REQUEST = 0x6323,

            SERVER_PATCH_RESPONSE = 0xA100,
            SERVER_SHARD_LIST_RESPONSE = 0xA101,
            SERVER_LOGIN_RESPONSE = 0xA102,
            SERVER_WEB_NOTICE_RESPONSE = 0xA104,
            SERVER_CAPTCHA_DATA = 0x2322,
            SERVER_CAPTCHA_SOLVED_RESPONSE = 0xA323,

            GLOBAL_HANDSHAKE = 0x5000,
            GLOBAL_HANDSHAKE_OK = 0x9000,
            GLOBAL_IDENTIFICATION = 0x2001,
            GLOBAL_PING = 0x2002;
        }
        public static void Server_GlobalIdentification(object sender, ClientMsgEventArgs e)
        {
            CheckUpdate.Instance.ShowMessage("GatewayModule::Server_GlobalIdentification");

            string service = e.Packet.ReadAscii();
            if (service == "GatewayServer")
            {
                // Send authentication
                Packet packet = new Packet(Opcode.CLIENT_PATCH_REQUEST, true);
                packet.WriteByte(CheckUpdate.Instance.Locale);
                packet.WriteAscii("SR_Client"); // Module Name
                packet.WriteUInt(CheckUpdate.Instance.Version);
                ((Client)sender).Send(packet);
            }
        }
        public static void Server_PatchResponse(object sender, ClientMsgEventArgs e)
        {
            CheckUpdate.Instance.ShowMessage("GatewayModule::Server_PatchResponse");

            var p = e.Packet;
            CheckUpdate.Instance.IsCheckingUpdates = false;
            // Analyze the patch
            switch (p.ReadByte())
            {
                case 1:
                    CheckUpdate.Instance.CanStartGame = true;
                    CheckUpdate.Instance.UpdatingPercentage = 100;
                    break;
                case 2:
                    byte errorCode = p.ReadByte();
                    switch (errorCode)
                    {
                        case 2:
                            {
                                string DownloadServerIP = p.ReadAscii();
                                ushort DownloadServerPort = p.ReadUShort();
                                DownloadModule.DownloadVersion = p.ReadUInt32();

                                CheckUpdate.Instance.ShowMessage("Version outdate. New version available (v" + DownloadModule.DownloadVersion + ")");
                                ulong bytesToDownload = 0;

                                while (p.ReadByte() == 1)
                                {
                                    FileEntry file = new FileEntry()
                                    {
                                        ID = p.ReadUInt(),
                                        Name = p.ReadAscii(),
                                        Path = p.ReadAscii(),
                                        Size = p.ReadUInt(),
                                        ImportToPk2 = p.ReadByte() == 1
                                    };

                                    DownloadModule.DownloadFiles.Add(file);

                                    bytesToDownload += file.Size;
                                }

                                // Set progress bar values
                                CheckUpdate.Instance.UpdatingBytesMaxDownloading = bytesToDownload;
                                CheckUpdate.Instance.UpdatingBytesDownloading = 0;

                                // Start downloader protocol
                                if (DownloadModule.DownloadFiles.Count > 0)
                                {
                                    // Try to load the GFXFileManager
                                    if (Pk2Writer.Initialize(LauncherSettings.CLIENTGFXFileManager_dll))
                                    {
                                        // Start downloading patch
                                        CheckUpdate.Instance.IsUpdating = true;
                                        CheckUpdate.Instance.ShowMessage("Downloading updates...");

                                        var downloadSession = new Client();
                                        // Packet handlers
                                        downloadSession.RegisterHandler(DownloadModule.Opcode.SERVER_READY, DownloadModule.Server_Ready);
                                        downloadSession.RegisterHandler(DownloadModule.Opcode.SERVER_FILE_CHUNK, DownloadModule.Server_FileChunk);
                                        downloadSession.RegisterHandler(DownloadModule.Opcode.SERVER_FILE_COMPLETED, DownloadModule.Server_FileCompleted);
                                        // Event handlers
                                        downloadSession.OnConnect += (_s, _e) =>
                                        {
                                            CheckUpdate.Instance.ShowMessage("Download: Session established");
                                        };
                                        downloadSession.OnDisconnect += (_s, _e) =>
                                        {
                                            CheckUpdate.Instance.ShowMessage("Download: Session disconnected [" + _e.Exception.Message + "]");
                                        };

                                        downloadSession.Start(DownloadServerIP, DownloadServerPort, 10000, out _);
                                    }
                                    else
                                    {
                                        SilkroadLauncher.CheckUpdate.Instance.ShowMessage(LauncherSettings.MSG_ERR_GFXDLL_NOT_FOUND);
                                    }
                                }
                            }
                            break;
                        case 4:
                            CheckUpdate.Instance.ShowMessage(LauncherSettings.MSG_PATCH_UNABLE);
                            break;
                        case 5:
                            CheckUpdate.Instance.ShowMessage(LauncherSettings.MSG_PATCH_TOO_OLD);
                            break;
                        case 1:
                            CheckUpdate.Instance.ShowMessage(LauncherSettings.MSG_PATCH_TOO_NEW);
                            break;
                        default:
                            CheckUpdate.Instance.ShowMessage("Unknown Error: [" + errorCode + "]");
                            break;
                    }
                    break;
            }

            var s = (Client)sender;
            // Request shard list just for fun c:
            CheckUpdate.Instance.ShowMessage("CLIENT_SHARD_LIST_REQUEST");
            s.Send(new Packet(Opcode.CLIENT_SHARD_LIST_REQUEST, true));
            s.Send(new Packet(Opcode.CLIENT_SHARD_LIST_PING_REQUEST, true)); // Not even sure what is this..
            // Request notice
            CheckUpdate.Instance.ShowMessage("CLIENT_WEB_NOTICE_REQUEST");
            Packet packet = new Packet(Opcode.CLIENT_WEB_NOTICE_REQUEST);
            packet.WriteByte(CheckUpdate.Instance.Locale);
            s.Send(packet);
        }
        public static void Server_WebNoticeResponse(object sender, ClientMsgEventArgs e)
        {
            CheckUpdate.Instance.ShowMessage("GatewayModule::Server_WebNoticeResponse");

            var p = e.Packet;
            byte noticeCount = p.ReadByte();
            // Reading notices
            List<WebNoticeViewModel> webNotices = new List<WebNoticeViewModel>(noticeCount);
            for (byte i = 0; i < noticeCount; i++)
            {
                webNotices.Add(new WebNoticeViewModel(new WebNotice()
                {
                    Subject = p.ReadAscii(),
                    Article = p.ReadAscii(),
                    Year = p.ReadUShort(),
                    Month = p.ReadUShort(),
                    Day = p.ReadUShort(),
                    Hour = p.ReadUShort(),
                    Minute = p.ReadUShort(),
                    Second = p.ReadUShort(),
                    MicroSecond = p.ReadUInt()
                }));
            }
            // Set the GUI
            // CheckUpdate.Instance.WebNotices = webNotices;

            //Select the first notice found as default

            //if (CheckUpdate.Instance.WebNotices.Count > 0)
            //    CheckUpdate.Instance.SelectedWebNotice = CheckUpdate.Instance.WebNotices[0];
        }

        public static void Server_ShardListResponse(object sender, ClientMsgEventArgs e)
        {
            CheckUpdate.Instance.ShowMessage("GatewayModule::Server_ShardListResponse");

            var p = e.Packet;
            while (p.ReadByte() == 1)
            {
                p.SkipRead(1); // farmID
                p.SkipRead(p.ReadUShort()); // farmName
            }
            while (p.ReadByte() == 1)
            {
                ushort serverID = p.ReadUShort();
                string serverName = p.ReadAscii();
                ushort playerCounter = p.ReadUShort();
                ushort playerLimit = p.ReadUShort();
                bool isAvailable = p.ReadByte() == 1;
                p.SkipRead(1); // farmID

                string MsgServer = $"#{serverID} {serverName} - {playerCounter}/{playerLimit} - " + (isAvailable ? "Online" : "Offline");

                CheckUpdate.Instance.ShowMessage(MsgServer);
                CheckUpdate.Instance.ShowMessage(MsgServer);
            
            }
        }
    }
}
