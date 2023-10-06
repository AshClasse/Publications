using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string DiscountType { get; set; }
        public string? StoreID { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}