namespace Publicaciones.Web.Models.Responses.Titles
{
    public class TitlesListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<TitlesViewResult> data { get; set; }
    }

    public class TitlesViewResult
    {
        public int titleID { get; set; }
        public int pubID { get; set; }
        public string? title { get; set; }
        public string? type { get; set; }
        public string? pubName { get; set; }
        public DateTime? pubDate { get; set; }
        public double? price { get; set; }
        public int? royalty { get; set; }
        public string? notes { get; set; }
        public DateTime creationDate { get; set; }
    }
}
