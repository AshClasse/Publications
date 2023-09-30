using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string StoreID { get; set; }
        public string OrdNum { get; set; }
        public DateTime OrdDate { get; set; }
        public int Qty { get; set; }
        public string Payterms { get; set; }
        public string TitleID { get; set; }
    }
}