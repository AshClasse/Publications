using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Titles : BaseEntity
    {
        public string Title_ID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string? PubID { get; set; }
        public double? Price { get; set; }
        public double? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? Ytd_Sales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PubDate { get; set; }
    }
}