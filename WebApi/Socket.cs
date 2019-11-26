using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using static System.Console;

namespace WebApi
{
    public class Socket
    {
        int port = 2000;
        string host = "127.0.0.1";
        string ipDomainName = "www.sogou.com";

        public IEnumerable<string> run()
        {
            var result = new List<string>();
            foreach (var address in Dns.GetHostEntry(ipDomainName).AddressList)
            {
                result.Add(address.ToString());
            }
            return result;
        }
    }
}
