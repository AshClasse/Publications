using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IRoySchedRepository : IBaseRepository<RoySched>
    {
		bool ExistsInTitles(int titleId);
		List<RoySched> GetRoySchedsByTitle(int titleId);
		List<RoySched> GetRoySchedsByRoyalty(int royalty);
	}
}
