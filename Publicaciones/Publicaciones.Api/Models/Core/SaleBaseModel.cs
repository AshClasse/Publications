namespace Publicaciones.Api.Models.Core
{
    public class SaleBaseModel : ModelBase
    {
        public string StoreID { get; set; }
        public DateTime OrdDate { get; set; }
        public string OrdNum { get; set; }
        public string TitleID { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
    }
}
