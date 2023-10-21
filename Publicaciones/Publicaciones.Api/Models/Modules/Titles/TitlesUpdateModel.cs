using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Modules.Titles
{
	public class TitlesUpdateModel : TitlesBaseModel
	{
		public int? IDModifiedUser { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
