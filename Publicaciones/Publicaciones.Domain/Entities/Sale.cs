using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string Stor_id { get; set; }
        public string Ord_num { get; set; }
        public DateTime Ord_date { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
        public string Title_id { get; set; }
    }
}