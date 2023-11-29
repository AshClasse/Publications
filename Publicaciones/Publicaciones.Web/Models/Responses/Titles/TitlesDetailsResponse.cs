namespace Publicaciones.Web.Models.Responses.Titles
{
    public class TitlesDetailsResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public TitlesViewResult data { get; set; }
    }
}
