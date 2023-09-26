using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Core
{
    public abstract class BaseLocation : BaseEntity
    {
        public string Country { get; set; }
        public string? City { get; set; }
        public string State { get; set; }
        public string? Zip { get; set; }
        public string? Address { get; set; }
    }
}
