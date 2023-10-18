using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Module
{
    public class Pub_InfoAddModel : Pub_InfoBaseModel
    {
        public int IDCreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
