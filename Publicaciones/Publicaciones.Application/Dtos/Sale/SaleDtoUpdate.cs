namespace Publicaciones.Application.Dtos.Sale
{
    public class SaleDtoUpdate : SaleDtoBase
    {
        public int StoreID { get; set; }
        public string OrdNum { get; set; }
        public int TitleID { get; set; }
    }
}
