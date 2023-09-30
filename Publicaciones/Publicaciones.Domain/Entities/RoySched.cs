using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class RoySched : BaseEntity
    {
        public string Title_ID { get; set; }
        public int? LoRange { get; set; }
        public int? HiRange { get; set; }
        public int? Royalty { get; set; }
    }
}
