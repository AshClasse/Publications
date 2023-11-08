using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Models
{
	public class RoySchedTitleModel
	{
			public int RoySchedID { get; set; }
			public int TitleID { get; set; }
			public string? Title { get; set; }
			public int? Royalty { get; set; }
			public int? LoRange { get; set; }
			public int? HiRange { get; set; }
			public DateTime CreationDate { get; set; }
		
	}
}
