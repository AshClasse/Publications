using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public int DiscountID { get; set; }
        public string DiscountType { get; set; }
        public string? StoreID { get; set; }
        public int? LowQty { get; set; }
        public int? HighQty { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}