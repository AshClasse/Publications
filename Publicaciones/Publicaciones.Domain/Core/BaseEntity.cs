using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Core
{
    public abstract class BaseEntity
    {
        public int IdCreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? IdModifiedUser { get; set; }
        public int? IdDeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}