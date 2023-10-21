namespace Publicaciones.Api.Models.Core
{
    public abstract class SaleBaseModel : ModelBase
    {
        public int StoreID { get; set; }
        public DateTime OrdDate { get; set; }
        public string OrdNum { get; set; }
        public int TitleID { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
    }
}
