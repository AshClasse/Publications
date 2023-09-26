using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Core
{
    public abstract class BaseBusiness : BaseLocation
    {
        public string? BusinessName { get; set; }
    }
}
