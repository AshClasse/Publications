
using Publicaciones.Application.Dtos.Base;

namespace Publicaciones.Application.Dtos.RoySched
{
	public class RoySchedGetAll : DtoBase
	{
		public int RoySched_ID { get; set; }
		public int Title_ID { get; set; }
		public int? LoRange { get; set; }
		public int? HiRange { get; set; }
		public int? Royalty { get; set; }
	}
}
