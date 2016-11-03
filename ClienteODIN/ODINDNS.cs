using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ClienteODIN
{
    public class ODINDNS
    {
        public string getHost()
        {
            WebClient client = new WebClient();
            string isp = client.DownloadString("http://servidorsocketasync.hol.es/isp.txt");
            return isp;
        }
    }
}
