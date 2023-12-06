using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Models
{
    public class AuthorsTitleAuthorsTitlesModel
    {
        public int Au_ID { get; set; }
        public string Au_LName { get; set; }
        public string Au_FName { get; set; }
        public string? City { get; set; }
        public int Title_ID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PubDate { get; set; }
        public int PubID { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? Ytd_Sales { get; set; }
        public int Au_Ord {  get; set; }
        public int? RoyaltyPer {  get; set; }
        public DateTime CreationDate { get; set; } 
    }
}
