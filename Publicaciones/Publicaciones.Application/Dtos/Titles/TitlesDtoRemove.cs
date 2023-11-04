
using Publicaciones.Application.Dtos.Base;

namespace Publicaciones.Application.Dtos.Titles
{
    public class TitlesDtoRemove : DtoBase
	{
		public int Id { get; set; }
		public bool Deleted { get; set; }
	}
}
