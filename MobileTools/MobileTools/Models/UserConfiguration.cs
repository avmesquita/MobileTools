using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTools.Models
{
	public class UserConfiguration
	{
		public Guid Guid { get; set; }

		public UserConfiguration()
		{
			Guid = Guid.NewGuid();
		}
	}
}
