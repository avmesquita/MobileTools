using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileTools.Models
{
	public class PingModel
	{
		public string IP { get; set; }
		public string Address { get; set; }
		public string Status { get; set; } 		
		public string Delay { get; set; }

		public override string ToString()
		{			
			return $"PING TO {this.IP} [{this.Address}] | {this.Status} | {this.Delay} ms";
		}
	}
}
