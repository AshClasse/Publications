namespace Publicaciones.Web.Models.Responses.Pub_Info
{
    public class Pub_InfoDetailsResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public Pub_InfoViewResult data { get; set; }
    }
}
