using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones.Domain.Entities
{
    public class Jobs : BaseEntity
    {
        public int JobID { get; set; }
        public string JobDescirption { get; set; }
        public int Minlvl { get; set; }
        public int Maxlvl { get; set; }

    }
}