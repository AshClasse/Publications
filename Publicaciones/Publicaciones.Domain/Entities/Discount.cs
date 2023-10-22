using Publicaciones.Domain.Core;

namespace Publicaciones.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public int DiscountID { get; set; }
        public string DiscountType { get; set; }
        public int StoreID { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}