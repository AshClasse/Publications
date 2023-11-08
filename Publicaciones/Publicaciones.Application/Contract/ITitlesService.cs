using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Domain.Entities;
using System.Collections.Generic;

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
