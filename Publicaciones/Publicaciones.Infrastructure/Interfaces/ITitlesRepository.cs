using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Models;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ITitlesRepository : IBaseRepository<Titles>
    {
		bool ExistsInPublishers(int pubId);
		List<TitlePublisherModel> GetTitlesByPublisherID(int pubId);
		List<TitlePublisherModel> GetTitlesPublishers();
		TitlePublisherModel TitlePublisher(int titleId);
		List<Titles> GetTitlesByPrice(decimal price);
		List<Titles> GetTitlesByType(string type);
	}
}
