using System;

namespace Publicaciones.Infrastructure.Models
{
    public class SaleTitleModel
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public DateTime OrdDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
