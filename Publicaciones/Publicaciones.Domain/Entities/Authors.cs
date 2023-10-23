using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Numerics;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Authors : BaseEntity
    {
        public int Au_ID { get; set; }
        public string Au_LName { get; set; }
        public string Au_FName { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public int Contract { get; set; }
    }
}