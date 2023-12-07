namespace Publicaciones.Web.Models.Responses.Pub_Info
{
    public class Pub_InfoListResponse : BaseResponse<List<Pub_InfoViewResult>>
    {
    }
    public class Pub_InfoViewResult
    {
        public int PubInfoID { get; set; }
        public int PubID { get; set; }
        public string? PubName { get; set; }
        public string? Pr_Info { get; set; }
        public byte[]? Logo { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

