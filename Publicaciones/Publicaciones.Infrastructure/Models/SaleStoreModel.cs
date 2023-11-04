using System;

namespace Publicaciones.Infrastructure.Models
{
    public class SaleStoreModel
    {
        public int StoreID { get; set; }
        public string OrdNum { get; set; }
        public int TitleID { get; set; }
        public string? StoreName { get; set; }
        public DateTime OrdDate { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
