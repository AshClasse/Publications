
using Publicaciones.Application.Dtos.Base;

namespace Publicaciones.Application.Dtos.Pub_Info
{
	public class Pub_InfoDtoGetAll : DtoBase
	{
		public int PubID { get; set; }
		public byte[]? Logo { get; set; }
		public string? Pr_Info { get; set; }
	}
}
