namespace Publicaciones.Web.Models.Responses.Discount
{
    public class DiscountDetailsResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public DiscountViewResult data { get; set; }
    }
}
