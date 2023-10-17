using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IRoySchedRepository : IBaseRepository<RoySched>
    {
		bool ExistsInTitles(string titleId);
		List<RoySched> GetRoySchedsByTitle(string titleId);
		List<RoySched> GetRoySchedsByRoyalty(int royalty);
	}
}
