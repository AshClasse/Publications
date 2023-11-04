namespace Publicaciones.Application.Dtos.Sale
{
    public class SaleDtoRemove : DtoBase
    {
        public int StoreID { get; set; }
        public string OrdNum { get; set; }
        public int TitleID { get; set; }
        public bool Deleted { get; set; }
    }
}
