using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ITitleRepository : IBaseRepository<Title>
    {
        List<Title> GetTitleByPublisher(int pubID);
    }
}
