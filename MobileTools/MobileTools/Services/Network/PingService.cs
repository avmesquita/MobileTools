using MobileTools.Models;
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

        public IEnumerable<PingModel> Ping(string ip, int count)
		{            
            PingReply r;

            List<PingModel> list = new List<PingModel>();

            for (var i = 1; i <= count; i++)
            {
                r = p.Send(ip);
                
                if (r.Status == IPStatus.Success)
                {
                    list.Add(new PingModel()
                    {
                        IP = ip.ToString(),
                        Address = r.Address.ToString(),
                        Status = "OK",
                        Delay = r.RoundtripTime.ToString()
                    });
                }
                else
                {
                    list.Add(new PingModel()
                    {
                        IP = ip.ToString(),
                        Address = r.Address.ToString(),
                        Status = r.Status.ToString(),
                        Delay = r.RoundtripTime.ToString()
                    });                    
                }
            }
            return list;
        }
	}
}
