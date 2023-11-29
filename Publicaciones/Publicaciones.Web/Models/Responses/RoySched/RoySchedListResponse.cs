namespace Publicaciones.Web.Models.Responses.RoySched
{
    public class RoySchedListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<RoySchedViewResult> data { get; set; }
    }
    public class RoySchedViewResult
    {
        public int roySchedID { get; set; }
        public int titleID { get; set; }
        public string? title { get; set; }
        public int? royalty { get; set; }
        public int? loRange { get; set; }
        public int? hiRange { get; set; }
        public DateTime creationDate { get; set; }
    }
}
