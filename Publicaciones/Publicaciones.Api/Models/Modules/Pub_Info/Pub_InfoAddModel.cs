using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Modules.Pub_InfoModels
{
    public class Pub_InfoAddModel : Pub_InfoBaseModel
    {
		public int IDCreationUser { get; set; }
        public DateTime CreationDate { get; set; } 
    }
}
