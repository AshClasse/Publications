using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Modules.Pub_InfoModels
{
    public class Pub_InfoUpdateModel : Pub_InfoBaseModel
    {
		public int? IDModifiedUser { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
