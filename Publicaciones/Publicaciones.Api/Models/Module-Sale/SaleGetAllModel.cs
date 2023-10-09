using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Module_Sale
{
    public class SaleGetAllModel : SaleBaseModel
    {
        public string StoreID { get; set; }
        public string OrdNum { get; set; }
        public string TitleID { get; set; }
        public DateTime OrdDate { get; internal set; }
    }
}
