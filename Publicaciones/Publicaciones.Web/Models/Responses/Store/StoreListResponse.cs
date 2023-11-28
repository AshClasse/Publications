namespace Publicaciones.Web.Models.Responses.Store
{
    public class StoreListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<StoreViewResult> data { get; set; }
    }

    public class StoreViewResult
    {
        public int storeID { get; set; }
        public string? storeName { get; set; }
        public string? storeAddress { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zip { get; set; }
        public DateTime creationDate { get; set; }
    }
}
