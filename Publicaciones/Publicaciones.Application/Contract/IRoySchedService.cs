

using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.RoySched;

namespace Publicaciones.Application.Contract
{
	public interface IRoySchedService : IBaseServices<RoySchedDtoAdd, RoySchedDtoUpdate, RoySchedDtoRemove>
	{
	}
}
