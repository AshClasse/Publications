using Publicaciones.Application.Dtos.Pub_Info;

namespace Publicaciones.Web.Models.Responses.Pub_Info
{
    public class Pub_InfoUpdateResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public Pub_InfoDtoUpdate data { get; set; }
    }
}
