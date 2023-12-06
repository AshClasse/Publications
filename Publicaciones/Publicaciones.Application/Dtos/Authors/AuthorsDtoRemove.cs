using Publicaciones.Application.Dtos.Base;
namespace Publicaciones.Application.Dtos.Authors
{
	public class AuthorsDtoRemove : DtoBase
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

	}
}
