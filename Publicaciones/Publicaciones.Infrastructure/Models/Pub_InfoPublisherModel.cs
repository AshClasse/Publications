using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Models
{
	public class Pub_InfoPublisherModel
	{
			public int Pub_InfoID { get; set; }
			public int PubID { get; set; }
			public string? PubName { get; set; }			
			public string? PrInfo { get; set; }
			public string? City { get; set; }
			public string? State { get; set; }
			public DateTime CreationDate { get; set; }
		
	}
}
