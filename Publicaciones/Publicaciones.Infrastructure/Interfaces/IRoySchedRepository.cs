using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Models;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IRoySchedRepository : IBaseRepository<RoySched>
    {
		bool ExistsInTitles(int titleId);
		List<RoySchedTitleModel> GetRoySchedsByTitleID(int titleId);
		List<RoySchedTitleModel> GetRoySchedsTitles();
		RoySchedTitleModel RoySchedTitle(int royID);
		List<RoySched> GetRoySchedsByRoyalty(int royalty);
	}
}
