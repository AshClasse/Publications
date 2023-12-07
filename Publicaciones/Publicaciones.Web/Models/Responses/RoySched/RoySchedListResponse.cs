namespace Publicaciones.Web.Models.Responses.RoySched
{
    public class RoySchedListResponse : BaseResponse<List<RoySchedViewResult>>
    {
    }
    public class RoySchedViewResult
    {
        public int RoySched_ID { get; set; }
        public int Title_ID { get; set; }
        public string? Title { get; set; }
        public int? Royalty { get; set; }
        public int? LoRange { get; set; }
        public int? HiRange { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
