namespace Publicaciones.Api.Models.Core
{
	public class RoySchedBaseModel : BaseModel
	{
		public string Title_ID { get; set; }
		public int? LoRange { get; set; }
		public int? HiRange { get; set; }
		public int? Royalty { get; set; }
	}
}
