using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Core
{
     public abstract class BasePerson : BaseLocation
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
