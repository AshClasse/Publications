namespace Publicaciones.Web.Models.Responses.Titles
{
    public class TitlesListResponse : BaseResponse<List<TitlesViewResult>>
    {
    }

    public class TitlesViewResult
    {
        public int Title_ID { get; set; }
        public int PubID { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? PubName { get; set; }
        public DateTime? PubDate { get; set; }
        public decimal? Price { get; set; }
        public int? Royalty { get; set; }
        public string? Notes { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
