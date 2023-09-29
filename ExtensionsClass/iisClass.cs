using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.ExtensionsClass
{
    public static class iisClass
    {
        public static List<string> FilesIIS()
        {
            return new List<string>()
            {
                IIS.billing_serverstate,
                IIS.billing_serverstate_bk,
                IIS.billing_silkconsume,
                IIS.billing_silkdatacall,
                IIS.Class_MD5,
                IIS.DBConnect.RepValue(),
                IIS.Function,
                IIS.GetTotalSilk,
                IIS.PurchaseSilk,
                IIS.RefundSilk,
                IIS.test,
                ""
            };
        }

        public static void initializationFilesIIS(string Name, string IP = "", string Port = "9042")
        {
            var SetupIISUI = SetOrEditSite(Name, IP, Port);
            if (SetupIISUI)
            {
                var FileData = FilesIIS();
                var Pathname = new string[]
                {
                    $@"C:\inetpub\wwwroot\{Name}\billing_serverstate.asp",
                    $@"C:\inetpub\wwwroot\{Name}\billing_serverstate_bk.asp",
                    $@"C:\inetpub\wwwroot\{Name}\billing_silkconsume.asp",
                    $@"C:\inetpub\wwwroot\{Name}\billing_silkdatacall.asp",
                    $@"C:\inetpub\wwwroot\{Name}\Class_MD5.asp",
                    $@"C:\inetpub\wwwroot\{Name}\DBConnect.asp",
                    $@"C:\inetpub\wwwroot\{Name}\Function.asp",
                    $@"C:\inetpub\wwwroot\{Name}\GetTotalSilk.asp",
                    $@"C:\inetpub\wwwroot\{Name}\PurchaseSilk.asp",
                    $@"C:\inetpub\wwwroot\{Name}\RefundSilk.asp",
                    $@"C:\inetpub\wwwroot\{Name}\test.asp",
                    ""
                };

                Extensions.WriteMiltFiles(FileData.ToArray(), Pathname);
            }
//            FilesIIS
        }

        public static bool SetOrEditSite(string Name, string IP = "", string Port = "9042")
        {
            try
            {
                //LocalIP.GetLocalIPAddress()
                serverMgr = new ServerManager();
                string strWebsitename = Name; // abc

                string strApplicationPool = "DefaultAppPool";  // set your deafultpool :4.0 in IIS

                string strhostname = ""; //abc.com

                string stripaddress = IP;// ip address

                string bindinginfo = stripaddress + ":" + Port + ":" + strhostname;

                //check if website name already exists in IIS

                var bWebsite = IsWebsiteExists(strWebsitename);

                if (bWebsite == null)
                {
                    var strPathStie = $@"C:\inetpub\wwwroot\{Name}";

                    var StrPathStieLog = $@"C:\inetpub\customfolder\site";

                    System.IO.Directory.CreateDirectory(strPathStie);

                    Site mySite = serverMgr.Sites.Add(strWebsitename.ToString(), "http", bindinginfo, strPathStie);

                    mySite.ApplicationDefaults.ApplicationPoolName = strApplicationPool;

                    mySite.TraceFailedRequestsLogging.Enabled = true;

                    mySite.TraceFailedRequestsLogging.Directory = StrPathStieLog;

                    serverMgr.CommitChanges();

                    mySite.Start();
                }
                else
                {
                    bWebsite.Bindings[0].BindingInformation = bindinginfo;
                    serverMgr.CommitChanges();
                }

         

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static ServerManager serverMgr = null;

        public static Site IsWebsiteExists(string strWebsitename)
        {
            foreach (Site site in serverMgr.Sites)
            {
                if (site.Name == strWebsitename.ToString())
                {
                    //flagset = true;
                    return site;
                }
            }
            return null;
        }



    }
}
