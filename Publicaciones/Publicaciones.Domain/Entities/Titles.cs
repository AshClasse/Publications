using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Titles : BaseEntity
    {
        public int Title_ID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int PubID { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? Ytd_Sales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PubDate { get; set; }
    }
}
