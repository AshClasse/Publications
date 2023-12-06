namespace Publicaciones.Web.Models.Response.TitleAuthorResponse
{
    public class TitleAuthorEditResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public TitleAuthorEditViewResponse data { get; set; }
    }
    public class TitleAuthorEditViewResponse
    {
        public int au_ID { get; set; }
        public int title_ID { get; set; }
        public int au_Ord { get; set; }
        public int royaltyPer { get; set; }
        public int idModifiedUser { get; set; } = 1;
        public DateTime modifiedDate { get; set; } = DateTime.Now;
    }
}
