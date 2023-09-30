using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IAuthorsRepository : IBaseRepository<Authors>
    {
        // Métodos exclusivos de la entidad
    }
}