using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ITitlesRepository : IBaseRepository<Titles>
    {
		List<Titles> GetTitlesByPublisher(int pubId);
		List<Titles> GetTitlesByPrice(decimal price);
		List<Titles> GetTitlesByType(string type);
	}
}
