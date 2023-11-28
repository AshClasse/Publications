namespace Publicaciones.Web.Models.Responses.Discount
{
    public class DiscountListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<DiscountViewResult> data { get; set; }
    }

    public class DiscountViewResult
    {
        public int discountID { get; set; }
        public int storeID { get; set; }
        public string storeName { get; set; }
        public string discountType { get; set; }
        public int lowQty { get; set; }
        public int highQty { get; set; }
        public double discountAmount { get; set; }
        public DateTime creationDate { get; set; }
    }
}
