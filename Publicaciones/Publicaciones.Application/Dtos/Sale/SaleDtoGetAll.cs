using System;

namespace Publicaciones.Application.Dtos.Sale
{
    public class SaleDtoGetAll
    {
        public int StoreID { get; set; }
        public string OrdNum { get; set; }
        public DateTime OrdDate { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
        public int TitleID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
