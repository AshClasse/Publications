namespace Publicaciones.Web.Models.Responses.Sale
{
    public class SaleListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<SaleViewResult> data { get; set; }
    }

    public class SaleViewResult
    {
        public int storeID { get; set; }
        public string ordNum { get; set; }
        public DateTime ordDate { get; set; }
        public short qty { get; set; }
        public string payterms { get; set; }
        public int titleID { get; set; }
        public DateTime creationDate { get; set; }
    }
}
