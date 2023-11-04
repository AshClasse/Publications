
using Publicaciones.Application.Dtos.Base;

namespace Publicaciones.Application.Dtos.RoySched
{
    public class RoySchedDtoRemove : DtoBase
	{
		public int Id { get; set; }
		public bool Deleted { get; set; }
	}
}
