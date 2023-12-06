using Publicaciones.Application.Dtos.Base;
namespace Publicaciones.Application.Dtos.Authors
{
	public class AuthorsDtoGetAll : AuthorDtoBase
    {
        public int Au_ID { get; set; }
        public string Au_FName { get; set; }
        public string Au_LName { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public int Contract { get; set; }
    }
}
