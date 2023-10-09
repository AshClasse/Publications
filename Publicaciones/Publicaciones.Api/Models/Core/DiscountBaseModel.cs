namespace Publicaciones.Api.Models.Core
{
    public class DiscountBaseModel : ModelBase
    {
        public string? StoreID { get; set; }
        public string DiscountType { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
