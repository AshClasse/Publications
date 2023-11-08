using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Models;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IPub_InfoRepository : IBaseRepository<Pub_Info>
    {
		bool ExistsInPublishers(int pubId);
		Pub_InfoPublisherModel GetInfoPublisherByID(int pubInfoId);
		List<Pub_InfoPublisherModel> GetPub_InfosByPublisherID(int pubId);
		List<Pub_InfoPublisherModel> GetPublishersInfos();
	}
}
