using System;

namespace Publicaciones.Application.Dtos.Discount
{
    public class DiscountDtoRemove : DtoBase
    {
        public int DiscountID { get; set; }
        public bool Deleted { get; set; }

        public string DiscountType { get; set; }
    }
}
