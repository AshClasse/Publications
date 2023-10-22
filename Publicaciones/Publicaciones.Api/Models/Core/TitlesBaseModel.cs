namespace Publicaciones.Api.Models.Core
{
	public class TitlesBaseModel : BaseModel
	{
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
