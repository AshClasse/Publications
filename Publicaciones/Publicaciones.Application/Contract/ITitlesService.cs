using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Titles;	

namespace Publicaciones.Application.Contract
{
	public interface ITitlesService : IBaseServices<TitlesDtoAdd, TitlesDtoUpdate, TitlesDtoRemove>
	{
		ServiceResult ExistsInPublishers(int pubId);
		ServiceResult GetTitlesByPrice(decimal price);
		ServiceResult GetTitlesByType(string type);
		ServiceResult GetTitlesByPublisherID(int pubId);
	}
}
