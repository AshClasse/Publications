using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string DiscountType { get; set; }
        public string? Stor_id { get; set; }
        public short? Lowqty { get; set; }
        public short? Highqty { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}