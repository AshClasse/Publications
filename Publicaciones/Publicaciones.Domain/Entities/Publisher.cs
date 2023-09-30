using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string PubID { get; set; }
        public string PubName { get; set; }
        public string? City { get; set; }
        public int? State { get; set; }
        public string? Country { get; set; }
    }
}
