
using Publicaciones.Application.Dtos.Base;
using System;

namespace Publicaciones.Application.Dtos.Titles
{
	public class TitlesGetAll : DtoBase
	{
		public int Title_ID { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
		public int PubID { get; set; }
		public decimal? Price { get; set; }
		public decimal? Advance { get; set; }
		public int? Royalty { get; set; }
		public int? Ytd_Sales { get; set; }
		public string? Notes { get; set; }
		public DateTime? PubDate { get; set; }
	}
}
