using System;

namespace Publicaciones.Infrastructure.Models
{
    public class DiscountStoreModel
    {
        public int DiscountID { get; set; }
        public int StoreID { get; set; }
        public string? StoreName { get; set; }
        public string DiscountType { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
