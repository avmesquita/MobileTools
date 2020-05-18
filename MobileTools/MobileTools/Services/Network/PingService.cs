using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace MobileTools.Services.Network
{
	public class PingService : IDisposable
	{
        Ping p;        

        public PingService()
        {
            p = new Ping();
        }

        public void Dispose()
        {
            p.Dispose();            
        }

        public IEnumerable<string> Ping(string ip, int count)
		{            
            PingReply r;

            List<string> list = new List<string>();

            for (var i = 1; i <= count; i++)
            {
                r = p.Send(ip);
                if (r.Status == IPStatus.Success)
                {
                    list.Add($"Ping to {ip.ToString()} [{r.Address.ToString()}] - OK - Delay = {r.RoundtripTime.ToString()} ms");
                }
                else
                {                    
                    list.Add($"Ping to {ip.ToString()} [{r.Address.ToString()} - {r.Status.ToString()} ");
                }
            }
            return list;
        }
	}
}
