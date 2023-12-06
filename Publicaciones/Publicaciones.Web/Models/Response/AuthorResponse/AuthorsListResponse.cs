namespace Publicaciones.Web.Models.Response
{
    public class AuthorsListResponse : BaseResponse<List<AuthorsViewResult>>
    {
    }
    public class AuthorsViewResult
    {
        public int au_ID { get; set; }
        public string au_FName { get; set; }
        public string au_LName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public int contract { get; set; }
        public int changeUser { get; set; }
        public DateTime changeDate { get; set; }
    }
}
