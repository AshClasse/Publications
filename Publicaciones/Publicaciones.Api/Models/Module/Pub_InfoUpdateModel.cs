using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Module
{
    public class Pub_InfoUpdateModel : Pub_InfoBaseModel
    {
        public int IdPub_Info { get; set; }
        public int ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
