using Publicaciones.Web.Models.Responses.Discount;

namespace Publicaciones.Web.Models.Responses.Store
{
    public class StoreDetailsResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public StoreViewResult data { get; set; }
    }
}
