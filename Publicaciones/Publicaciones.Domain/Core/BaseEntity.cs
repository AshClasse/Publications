using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Core
{
    public abstract class BaseEntity
    {
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}