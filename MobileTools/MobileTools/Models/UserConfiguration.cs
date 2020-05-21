using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TableAttribute = SQLite.TableAttribute;

namespace MobileTools.Models
{
	[Table("UserConfiguration")]
	public class UserConfiguration
	{	
		[PrimaryKey]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public Guid Guid { get; set; }
		public string GoogleApiKey { get; set; }
		public string NasaApiKey { get; set; }

		public UserConfiguration()
		{
			Guid = Guid.NewGuid();
		}
	}
}
