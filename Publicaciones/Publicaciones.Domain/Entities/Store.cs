using Publicaciones.Domain.Core;

namespace Publicaciones.Domain.Entities
{
    public class Store : BaseEntity
    {
        public int StoreID { get; set; }
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
    }
}
