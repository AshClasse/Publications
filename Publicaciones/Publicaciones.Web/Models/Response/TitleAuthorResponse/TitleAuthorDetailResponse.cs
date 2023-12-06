namespace Publicaciones.Web.Models.Response.TitleAuthorResponse
{
    public class TitleAuthorDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public TitleAuthorViewResponse data { get; set; }
    }
    public class TitleAuthorViewResponse
    {
        public int au_ID { get; set; }
        public int title_ID { get; set; }
        public int au_Ord { get; set; }
        public int royaltyPer { get; set; }
        public int idModifiedUser { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}
