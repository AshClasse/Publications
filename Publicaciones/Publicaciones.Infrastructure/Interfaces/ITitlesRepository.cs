using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    internal interface ITitlesRepository : IBaseRepository<Titles>
    {
        // Métodos exclusivos de la entidad
    }
}
