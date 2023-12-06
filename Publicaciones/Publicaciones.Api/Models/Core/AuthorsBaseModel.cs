namespace Publicaciones.Api.Models.Core
{
	public class AuthorsBaseModel : BaseModel
	{
		public string? Au_FName { get; set; }		
		public string? Au_LName { get; set; }
		public string? Phone { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zip { get; set; }
		public int Contract { get; set; }
	}
}
