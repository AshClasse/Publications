using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Module_Sale
{
    public class SaleUpdateModel : SaleBaseModel
    {
        public string StoreID { get; set; }
        //public DateTime OrdDate { get; set; }
        public string OrdNum { get; set; }
        public string TitleID { get; set; }
    }
}
