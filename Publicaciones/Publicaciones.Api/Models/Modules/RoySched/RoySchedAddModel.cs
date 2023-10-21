using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Modules.RoySched
{
	public class RoySchedAddModel : RoySchedBaseModel
	{
		public int IDCreationUser { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
