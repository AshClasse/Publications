namespace Publicaciones.Application.Dtos.Discount
{
    public abstract class DiscountDtoBase : DtoBase
    {
        public string DiscountType { get; set; }
        public int StoreID { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
