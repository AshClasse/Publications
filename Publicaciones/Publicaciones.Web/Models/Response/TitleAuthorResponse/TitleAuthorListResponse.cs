namespace Publicaciones.Web.Models.Response.TitleAuthorResponse
{
    public class TitleAuthorListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<TitleAuthorViewResult> data { get; set; }
    }
    public class TitleAuthorViewResult
    {
        public int au_ID { get; set; }
        public int title_ID { get; set; }
        public int au_Ord { get; set; }
        public int royaltyPer { get; set; }
        public int changeUser { get; set; }
        public DateTime changeDate { get; set; }
    }
}
