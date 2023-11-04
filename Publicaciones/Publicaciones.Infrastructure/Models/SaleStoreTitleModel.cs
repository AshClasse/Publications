using System;

namespace Publicaciones.Infrastructure.Models
{
    public class SaleStoreTitleModel
    {
        public int StoreID { get; set; }
        public string OrdNum { get; set; }
        public int TitleID { get; set; }
        public string? StoreName { get; set; }
        public DateTime OrdDate { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
        public string TitleName { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
