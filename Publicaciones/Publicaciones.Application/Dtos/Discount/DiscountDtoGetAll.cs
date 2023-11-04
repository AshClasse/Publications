using System;

namespace Publicaciones.Application.Dtos.Discount
{
    public class DiscountDtoGetAll
    {
        public int DiscountID { get; set; }
        public string DiscountType { get; set; }
        public int StoreID { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
