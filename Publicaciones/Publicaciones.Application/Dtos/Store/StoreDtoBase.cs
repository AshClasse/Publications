namespace Publicaciones.Application.Dtos.Store
{
    public abstract class StoreDtoBase : DtoBase
    {
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
    }
}
