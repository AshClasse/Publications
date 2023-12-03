namespace Publicaciones.Web.Models.Responses.Pub_Info
{
    public class Pub_InfoListResponse : BaseResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<Pub_InfoViewResult> data { get; set; }
    }
    public class Pub_InfoViewResult
    {
        public int pub_InfoID { get; set; }
        public int pubID { get; set; }
        public string? pubName { get; set; }
        public string? prInfo { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public DateTime creationDate { get; set; }
    }
}
