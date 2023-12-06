namespace Publicaciones.Web.Models.Response.TitleAuthorResponse
{
    public class TitleAuthorListResponse : BaseResponse<List<TitleAuthorViewResult>>
    {
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
