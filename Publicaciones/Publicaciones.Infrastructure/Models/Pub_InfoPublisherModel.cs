using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Models
{
	public class Pub_InfoPublisherModel
	{
			public int PubInfoID { get; set; }
			public int PubID { get; set; }
			public string? PubName { get; set; }			
			public string? Pr_Info { get; set; }
			public byte[]? Logo { get; set; }
			public string? City { get; set; }
			public string? State { get; set; }
			public DateTime CreationDate { get; set; }
		
	}
}
