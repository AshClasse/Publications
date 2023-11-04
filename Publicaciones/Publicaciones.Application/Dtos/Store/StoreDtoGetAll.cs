using System;

namespace Publicaciones.Application.Dtos.Store
{
    public class StoreDtoGetAll
    {
        public int StoreID { get; set; }
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
