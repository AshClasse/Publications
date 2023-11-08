using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
	public class Publisher : BaseEntity
	{
		public int PubID { get; set; }
		public string PubName { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Country { get; set; }
	}
}
