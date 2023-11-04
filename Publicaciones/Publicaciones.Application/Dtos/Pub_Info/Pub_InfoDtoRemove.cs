using Publicaciones.Application.Dtos.Base;

namespace Publicaciones.Application.Dtos.Pub_Info
{
    public class Pub_InfoDtoRemove : DtoBase
	{
		public int Id { get; set; }
		public bool Deleted { get; set; }
	}
}
