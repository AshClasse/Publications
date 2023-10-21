using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Modules.RoySched
{
	public class RoySchedUpdateModel : RoySchedBaseModel
	{
		public int? IDModifiedUser { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
