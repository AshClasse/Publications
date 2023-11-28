namespace Publicaciones.Web.Models.Responses.Sale
{
    public class SaleDetailsResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public SaleViewResult data { get; set; }
    }
}
