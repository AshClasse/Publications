namespace Publicaciones.Application.Dtos.Store
{
    public class StoreDtoRemove : DtoBase
    {
        public int StoreID { get; set; }
        public bool Deleted { get; set; }
        public string StoreName { get; set; }
    }
}
