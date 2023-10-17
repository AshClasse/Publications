using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Module_Sale
{
    public class SaleUpdateModel : SaleBaseModel
    {
        public int StoreID { get; set; }
        public string OrdNum { get; set; }
        public int TitleID { get; set; }
    }
}
