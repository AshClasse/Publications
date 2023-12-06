namespace Publicaciones.Web.Models.Responses.Discount
{
    public class DiscountViewResult
    {
        public int DiscountID { get; set; }
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string DiscountType { get; set; }
        public int LowQty { get; set; }
        public int HighQty { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
