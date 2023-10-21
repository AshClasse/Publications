using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Modules.Titles
{
	public class TitlesAddModel : TitlesBaseModel
	{
		public int IDCreationUser { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
