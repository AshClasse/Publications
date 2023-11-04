using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Titles;

namespace Publicaciones.Application.Contract
{
	public interface ITitlesService : IBaseServices<TitlesDtoAdd, TitlesDtoUpdate, TitlesDtoRemove>
	{
	}
}
