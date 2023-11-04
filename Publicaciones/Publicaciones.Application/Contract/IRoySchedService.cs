

using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Domain.Entities;
using System.Collections.Generic;

namespace Publicaciones.Application.Contract
{
	public interface IRoySchedService : IBaseServices<RoySchedDtoAdd, RoySchedDtoUpdate, RoySchedDtoRemove>
	{
		//ServiceResult ExistsInTitles(int titleId);
		//ServiceResult GetRoySchedsByTitle(int titleId);
		//ServiceResult GetRoySchedsByRoyalty(int royalty);
	}
}
