using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.RoySched;

namespace Publicaciones.Application.Contract
{
	public interface IRoySchedService : IBaseServices<RoySchedDtoAdd, RoySchedDtoUpdate, RoySchedDtoRemove>
	{
		ServiceResult ExistsInTitles(int titleId);
		ServiceResult GetRoySchedsByRoyalty(int royalty);
		ServiceResult GetRoySchedsByTitleID(int titleId);
	}
}
