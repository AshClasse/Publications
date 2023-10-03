using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string Stor_ID { get; set; }
        public string? Stor_Name { get; set; }
        public string? Stor_Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
    }
}
