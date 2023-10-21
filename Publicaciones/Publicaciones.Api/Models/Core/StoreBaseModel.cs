namespace Publicaciones.Api.Models.Core
{
    public abstract class StoreBaseModel : ModelBase
    {
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
    }
}
