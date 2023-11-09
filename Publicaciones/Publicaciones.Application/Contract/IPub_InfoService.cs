using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;

namespace Publicaciones.Application.Contract
{
	public interface IPub_InfoService : IBaseServices<Pub_InfoDtoAdd, Pub_InfoDtoUpdate, Pub_InfoDtoRemove>
	{
		ServiceResult ExistsInPublishers(int pubId);
		ServiceResult GetPub_InfosByPublisherID(int pubId);
	}
}
